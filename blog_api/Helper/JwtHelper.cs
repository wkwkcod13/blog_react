using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace blog_api.Helper
{
    public class JwtHelper
    {
        /// <summary>
        /// https://jasonwatmore.com/post/2021/06/15/net-5-api-jwt-authentication-with-refresh-tokens
        /// </summary>
        private readonly IConfiguration config;
        public JwtHelper(IConfiguration config)
        {
            this.config = config;
        }

        public string GenerateToken(string userName, string device, List<string>? roles, Dictionary<string, object>? claimKeys, int expireMinutes = 60)
        {
            var issuer = config.GetValue<string>("JwtSettings:Issuer");

            // 設定要加入到 JWT Token 中的聲明資訊(Claims)
            var claims = new List<Claim>();

            // *** 新增自訂的User資訊
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); // JWT ID

            if (!string.IsNullOrWhiteSpace(device))
            {
                claims.Add(new Claim("device", device, ClaimValueTypes.String, issuer));
            }
            if (claimKeys is Dictionary<string, object> keys)
            {
                foreach (var key in keys)
                {
                    claims.Add(new Claim(key.Key, key.Value.ToString()));
                }
            }

            if (roles is List<string> list)
            {
                foreach (var role in list)
                {
                    claims.Add(new Claim("roles", role));//// 你可以自行擴充 "roles" 加入登入者該有的角色
                }
            }
            return GenerateToken(claims, expireMinutes);
        }

        public string GenerateToken(List<Claim> items, int expireMinutes = 60)
        {
            var issuer = config.GetValue<string>("JwtSettings:Issuer");
            var signKey = config.GetValue<string>("JwtSettings:SignKey");

            List<Claim> claims = items ?? new List<Claim>();
            // 建立一組對稱式加密的金鑰，主要用於 JWT 簽章之用
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha384Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(expireMinutes),
                SigningCredentials = signingCredentials,
                Audience = string.Empty
            };

            // 產出所需要的 JWT securityToken 物件，並取得序列化後的 Token 結果(字串格式)
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var serializeToken = tokenHandler.WriteToken(securityToken);

            return serializeToken;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="authorization"></param>
        /// <param name="device"></param>
        /// <param name="claimKeys"></param>
        /// <param name="expireMinutes"></param>
        /// <returns></returns>
        public string GenerateEncryptionToken(string userName, string device, List<string>? roles, Dictionary<string, object>? claimKeys, int expireMinutes = 60)
        {
            var issuer = config.GetValue<string>("JwtSettings:Issuer");

            // 設定要加入到 JWT Token 中的聲明資訊(Claims)
            var claims = new List<Claim>();

            // *** 新增自訂的User資訊
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, userName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); // JWT ID

            if (!string.IsNullOrWhiteSpace(device))
            {
                claims.Add(new Claim("device", device, ClaimValueTypes.String, issuer));
            }

            if (claimKeys is Dictionary<string, object> keys)
            {
                foreach (var key in keys)
                {
                    claims.Add(new Claim(key.Key, key.Value.ToString(), ClaimValueTypes.String, issuer));
                }
            }

            if (roles is List<string> list)
            {
                foreach (var role in list)
                {
                    claims.Add(new Claim("roles", role)); //// 你可以自行擴充 "roles" 加入登入者該有的角色
                }
            }
            return GenerateEnvryptionToken(userName, issuer, claims, expireMinutes);
        }

        public string GenerateEnvryptionToken(string userName, string issuer, List<Claim>? items, int expireMinutes = 60)
        {
            var signKey = config.GetValue<string>("JwtSettings:SignKey");
            var encryKey = config.GetValue<string>("JwtSettings:EncryKey");

            List<Claim> claims = items ?? new List<Claim>();
            var userClaimsIdentity = new ClaimsIdentity(claims, "Bearer");
            // 建立一組對稱式加密的金鑰，主要用於 JWT 簽章之用
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));
            var securityKey2 = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(encryKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha384Signature);
            var encryptingCredentials = new EncryptingCredentials(securityKey2, SecurityAlgorithms.Aes128KW,
                SecurityAlgorithms.Aes128CbcHmacSha256);

            // 產出所需要的 JWT securityToken 物件，並取得序列化後的 Token 結果(字串格式)
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateJwtSecurityToken(issuer, null,
                userClaimsIdentity, null, DateTime.Now.AddMinutes(expireMinutes),
                null, signingCredentials, encryptingCredentials);
            var serializeToken = tokenHandler.WriteToken(securityToken);

            return serializeToken;
        }
    }
}
