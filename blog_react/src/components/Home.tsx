import React, { Component } from 'react';
import fnlogin from './function/fnLogin';
import jwtToken from './jwtToken';
import ApiRoutes from '../ApiRoutes';

interface home {
    forecasts: [],
    loading: boolean
}
export class Home extends Component {
    state: home;
    constructor(props: home) {
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
            // console.log(res);
        }).catch(error => {
            jwtToken.fnTokenClear();
        })
        const token = jwtToken.fnTokenGet();
        //console.log(token);
        if (token === null) {
            await fnlogin('1133', '44223');
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