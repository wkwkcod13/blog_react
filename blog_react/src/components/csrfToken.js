import ApiRoutes from '../ApiRoutes';
export default async function csrfToken() {
    let token = '';
    await fetch(`${ApiRoutes.ApiRoot}/Auth/AntiForgeryToken`, {
        method: "GET"
    })
        .then(async (res) => {
            let json = await res.json();
            console.log(json);
            token = json.requestToken;
            console.log(token);
        }).catch((err) => {
            console.log(err);
        });
    return token;
}
