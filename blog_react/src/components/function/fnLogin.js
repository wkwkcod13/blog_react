import ApiRoutes, { } from "../../ApiRoutes";
import React from 'react';
import jwtToken from '../jwtToken';
import csrfToken from "../csrfToken";

/**
 * @param {any} account
 * @param {any} password
 */
async function fnLogin(account, password) {
    await fetch(`${ApiRoutes.ApiRoot}/Auth/loginE`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-CSRF-TOKEN': await csrfToken()
        },
        body: JSON.stringify({
            account: `${account}`,
            password: `${password}`
        })
    }).then(async res => {
        if (res.ok) {
            let text = await res.text();
            jwtToken.fnTokenSet(text);
        }
    }).catch(res => {
        console.log(res);
    });
}
export default fnLogin;
