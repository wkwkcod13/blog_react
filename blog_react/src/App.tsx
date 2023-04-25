import './input.css';
import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import AppNav from './AppNav';
import AppContent from './AppContent';

interface app {
    forecasts: [],
    loading: boolean
}
export default class App extends Component {
    state: app;
    static displayName = App.name;

    constructor(props: app) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    render() {
        return (
            <Routes>
                {
                    AppRoutes.map((route, index) => {
                        const { element, ...rest } = route;
                        return (
                            <Route key={index} {...rest}
                                element={
                                    <div>
                                        <AppNav></AppNav>
                                        <AppContent>{element}</AppContent>
                                    </div>}
                            ></Route>
                        )
                    })
                }
            </Routes>
        );
    }
}
