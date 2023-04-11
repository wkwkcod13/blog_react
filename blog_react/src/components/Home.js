import React, { Component } from 'react';
import MyComponent from './MyComponent';
import fnlogin from './function/fnLogin';
import jwtToken from './jwtToken';
import csrfToken from './csrfToken';
import ApiRoutes from '../ApiRoutes';

export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
        this.initAsync();
    }
    async initAsync() {
        await fetch(ApiRoutes.ApiRoot + '/Blog', {
            method: "HEAD",
            headers: {
                'Authorization': `Bearer ${jwtToken.fnTokenGet()}`
            }
        }).then((res) => {
            //console.log(res);
        }).catch(error => {
            jwtToken.fnTokenClear();
        })
        const token = jwtToken.fnTokenGet();
        //console.log(token);
        if (token === null) {
            await fnlogin('qwe', 'ewq');
            //console.log("after:" + jwtToken.fnTokenGet());
        }
        
    }

    render() {
        return (
            <div>
            </div>
        );
    }
}