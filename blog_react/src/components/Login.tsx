import React, { ChangeEvent, ChangeEventHandler, Component, ReactEventHandler } from 'react';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Container from 'react-bootstrap/Container';
import fnlogin from './function/fnLogin';

interface login {
    account: string;
    password: string;
    rememberMe: boolean;
}

export class Login extends Component {
    state: login;
    constructor(props: login) {
        super(props);
        this.state = props;
        this.setState({ rememberMe: false });
        this.handleAccountChange = this.handleAccountChange.bind(this);
        this.handlePasswordChange = this.handlePasswordChange.bind(this);
        this.handleRememberMeChange = this.handleRememberMeChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleAccountChange(event: ChangeEvent<HTMLInputElement>) {
        this.setState({ account: event.target.value });
    };
    handlePasswordChange(event: ChangeEvent<HTMLInputElement>) {
        this.setState({ password: event.target.value });
    };
    handleRememberMeChange(event: ChangeEvent<HTMLInputElement>) {
        this.setState({ rememberMe: event.target.checked });
    }
    async handleSubmit() {
        await fnlogin(this.state.account, this.state.password);
        console.log("form submitted");
    };
    render() {
        return (
            <Container fluid="xl">
                <Form>
                    <Form.Group as={Row} md={{ offset: 0.5, span: 3 }}>
                        <Form.Group as={Col} xs={{ span: 11.5, offset: 0.5 }} md={6} controlId="formGroupEmail">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control type="email" placeholder="Enter email" onChange={this.handleAccountChange} value={this.state.account}></Form.Control>
                        </Form.Group>
                    </Form.Group>
                    <Form.Group as={Row} md={{ offset: 0.5, span: 3 }}>
                        <Form.Group as={Col} xs={{ span: 11.5, offset: 0.5 }} md={6} controlId="formGroupPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" placeholder="Password" onChange={this.handlePasswordChange} value={this.state.password}></Form.Control>
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
                            <Form.Check label="Remember me" onChange={this.handleRememberMeChange} checked={this.state.rememberMe} />
                        </Col>
                    </Form.Group>
                    <Button onClick={ this.handleSubmit}>
                        <span>Login</span>
                    </Button>
                </Form>
            </Container>
        );
    }
}