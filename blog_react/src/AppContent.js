import React, { Component } from 'react';
import Container from 'react-bootstrap/Container';

export default class AppContent extends Component {
    render() {
        return (
            <div>
                <Container>
                    {this.props.children}
                </Container>
            </div>
        )
    }
}