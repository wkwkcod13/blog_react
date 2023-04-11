import ApiRoutes from '../ApiRoutes';
export default async function csrfToken() {
    let token = 'qweqwe';
    await fetch(`${ApiRoutes.ApiRoot}/Auth/AntiForgeryToken`, {
        method: "GET"
    })
        .then(async (res) => {
            let json = await res.json();
            /*console.log(res.headers.get('X-CSRF-TOKEN'));*/
            //console.log(json.requestToken);
            token = json.requestToken;
        }).catch((err) => {
            console.log(err);
        });
    return token;
}
