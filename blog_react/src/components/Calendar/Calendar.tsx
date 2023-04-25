import * as React from 'react';
import { Component } from 'react';
import Moment, { duration } from 'moment';
import Table from 'react-bootstrap/Table';
import { Duration } from './Duration';
import PropTypes from 'prop-types';
import moment from 'moment';
import CalendarEvent from './CalendarEvent';

export default class Calendar extends Component {
    events: [] = [];
    currentDate: Date = new Date();
    dayHeaders: boolean = true;
    weekends: boolean = true;
    soltDuration: Duration | string = new Duration("00:15:00");
    soltMinTime: Duration | string = new Duration("00:00:00");
    soltMaxTime: Duration | string = new Duration("24:00:00");
    constructor(props: {}) {
        super(props);
    }

    static propTypes = {
        Events: PropTypes.any,
        dayHeaders: PropTypes.bool,
        weekends: PropTypes.bool
    }

    render() {
        let day = Moment(this.currentDate)
        let starttime = Moment(new Date(this.currentDate))
        let headers: string[] = [];
        let times: Moment.Moment[] = [];
        let timeRows: number[] = [];
        for (let i = 0; i < (this.weekends ? 7 : 5); i++) {
            headers.push(day.day(i).format());
        }

        let min: Number = this.soltMaxTime. * 60
        while () {
            timeRows.push(i);
        }

        return (
            <Table>
                <Duration years={0} months={3} days={11}></Duration>
                <CalendarEvent ToDate={''} FromDate={''} Title={''}></CalendarEvent>
                <thead>
                    {
                        this.dayHeaders ?
                            <tr>
                                <td></td>
                                {
                                    headers.map((result, index) => {
                                        return (<td key={index}>{result}</td>);
                                    })
                                }
                            </tr>
                            : null
                    }
                </thead>
                <tbody>
                    {
                        timeRows.map((result, index) => {
                            return (
                                <tr key={index} >
                                    <td >{result.toString()}</td>
                                    {
                                        headers.map((result, index) => {
                                            return (<td></td>);
                                        })
                                    }
                                </tr>
                            );
                        })
                    }
                </tbody>
            </Table>
        );
    }
}
