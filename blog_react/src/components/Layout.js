import React, { Component } from 'react';
import Calendar from './Calendar/Calendar';

export class Layout extends Component {
    render() {
        return (<div>
            <div>Layout</div>
            <Calendar ></Calendar>
        </div>);
    }
}