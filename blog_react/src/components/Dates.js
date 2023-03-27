import React, { Component } from 'react';
import FullCalendar from '@fullcalendar/react' // must go before plugins
import dayGridPlugin from '@fullcalendar/daygrid' // a plugin!

export class Dates extends Component {
    constructor() {
        super();
        this.state = {
            timeZone: 'UTC',
            events: this.fetchCalendarEvents,
            //events: [
            //    { title: 'event 1', date: '2023-03-27' },
            //    { title: 'event 2', date: '2023-03-28' }
            //]
        };
    }

    async fetchCalendarEvents() {
        await fetch('https://localhost:44372/Calendar').then(async res => {
            let jsonData = await res.json();
            return JSON.parse(jsonData);
        }).catch(res => {
            return [];
        });
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