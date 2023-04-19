import React, { Component } from 'react';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

export class Pages extends Component {
    render() {
        return (
            <Container fluid>
                <Row>
                    <Col xss={1} xs={ 2} sm={3} md={ 3} >1 of 3</Col>
                    <Col md>2 of 3</Col>
                    <Col sm={ 2} lg="2">3 of 3</Col>
                </Row>
                <Row>
                    <Col>1 of 3</Col>
                    <Col md={true}>2 of 3</Col>
                    <Col sm={ 2} lg="2">3 of 3</Col>
                </Row>
            </Container>
        );
    }
}