import React, { Component } from 'react';
import MyComponent from './MyComponent';

export class Home extends Component {
    static displayName = Home.name;
    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    render() {
        return (
            <div>
                <MyComponent></MyComponent>
            </div>
        );
    }
}