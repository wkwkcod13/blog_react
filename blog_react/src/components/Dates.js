import React, { Component } from 'react';
import FullCalendar from '@fullcalendar/react' // must go before plugins
import dayGridPlugin from '@fullcalendar/daygrid' // a plugin!

export class Dates extends Component {
    constructor() {
        super();
        this.state = {
            events: [
                { title: 'event 1', date: '2023-03-27' },
                { title: 'event 2', date: '2023-03-28' }
            ]
        };
    }

    render() {
        return (
            <FullCalendar plugins={[dayGridPlugin]}
                initialView="dayGridMonth"
                events={this.state.events}
            />
        )
    }
}