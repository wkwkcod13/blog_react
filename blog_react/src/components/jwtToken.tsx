import React, { Component } from 'react';
const tokenName = 'jwtToken';

export default class jwtToken extends Component {
    static fnTokenGet() { return localStorage.getItem(tokenName) }
    static fnTokenSet(token: string) { localStorage.setItem(tokenName, token); }
    static fnTokenClear() { localStorage.removeItem(tokenName); }
    render() { return null; }
}