import React, { Component } from 'react';
import FullCalendar from '@fullcalendar/react' // must go before plugins
import dayGridPlugin from '@fullcalendar/daygrid' // a plugin!
import ApiRoutes from '../ApiRoutes';


export class Dates extends Component {
    constructor() {
        super();
        this.state = {
            timeZone: 'UTC',
            events: []
        };
        this.fetchCalendarEvents();
    }

    fetchCalendarEvents() {
        fetch(ApiRoutes.ApiRoot + '/Calendar', { method: "GET" })
            .then(async (res) => {
                let json = await res.json()
                console.log(json);
                this.setState({
                    events: json
                });
                console.log(this.state);
            }).catch(res => {
                console.log(res);
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