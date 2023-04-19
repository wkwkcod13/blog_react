import React, { Component } from 'react';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Container from 'react-bootstrap/Container';

export class Login extends Component {
    render() {
        return (
            <Container fluid="xl">
                <Form class="" fluid="md">
                    <Form.Group as={Row} md={{ offset: 0.5, span: 3 }}>
                        <Form.Group as={Col} xs={{ span: 11.5, offset: 0.5 }} md={6} controlId="formGroupEmail">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control type="email" placeholder="Enter email"></Form.Control>
                        </Form.Group>
                    </Form.Group>
                    <Form.Group as={Row} md={{ offset: 0.5, span: 3 }}>
                        <Form.Group as={Col} xs={{ span: 11.5, offset: 0.5 }} md={6} controlId="formGroupPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" placeholder="Password"></Form.Control>
                        </Form.Group>
                    </Form.Group>
                    <fieldset>
                        <Form.Group as={Row}>
                            <Form.Label as="legend" column xs={{ span: 3, offset: 0.5 }} sm={{ span: 3, offset: 0.5 }}>
                                Radios
                            </Form.Label>
                            <Col xs={true} sm={true}>
                                <Form.Check type="radio" label="first radio" name="formHorizontalRadios" id="formHorizontalRadios1" />
                                <Form.Check type="radio" label="second radio" name="formHorizontalRadios" id="formHorizontalRadios2" />
                                <Form.Check type="radio" label="third radio" name="formHorizontalRadios" id="formHorizontalRadios3" />
                            </Col>
                            <Col xs={0.5} sm={0.5}></Col>
                        </Form.Group>
                    </fieldset>
                    <Form.Group as={Row} md={{ offset: 0.5, span: 3 }} controlId="formHorizontalCheck">
                        <Col sm={{ span: 11.5, offset: 0.5 }}>
                            <Form.Check label="Remember me" />
                        </Col>
                    </Form.Group>
                    <Button type="submit"></Button>
                </Form>
            </Container>
        );
    }
}