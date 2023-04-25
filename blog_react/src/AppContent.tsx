import React, { Component, ReactNode } from 'react';
import Container from 'react-bootstrap/Container';

interface appContent {
    children: ReactNode
}
export default class AppContent extends Component {
    state: appContent;
    constructor(props: appContent) {
        super(props);
        this.state = props;
    }
    render() {
        return (
            <div>
                {this.state.children}
            </div>
        )
    }
}