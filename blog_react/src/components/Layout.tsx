import React, { Component } from 'react';
import Calendar from './Calendar/Calendar';
import Container from 'react-bootstrap/Container';

interface layout {
    timeZone: string;
    events: [];
}

export class Layout extends Component {
    state: layout;
    constructor(props: layout) {
        super(props);
        this.state = props;
        this.setState({
            events: [
                {
                    title: "",
                    startTime: "",
                    endTime:""
                },
                {
                    title: "",
                    startTime: "",
                    endTime: ""
                },
                {
                    title: "",
                    startTime: "",
                    endTime: ""
                },
                {
                    title: "",
                    startTime: "",
                    endTime: ""
                }
            ]
        });
    }

    render() {
        return (
            <Container fluid="md">
                <div>Layout</div>
                <Calendar startTime="00:00:00" endTime="23:59:59" duration="00:15:00" events={this.state.events}></Calendar>
            </Container>
        );
    }
}