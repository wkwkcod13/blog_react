import * as React from 'react';
import { Component } from 'react';
import Moment, { duration } from 'moment';
import Table from 'react-bootstrap/Table';
import { Duration } from './Duration';
import PropTypes from 'prop-types';
import moment from 'moment';
import CalendarEvent from './CalendarEvent';

interface calendar {
    events: [];
    currentDate: Date;
    dayHeaders: boolean;
    weekends: boolean;
    startTime: string;
    endTime: string;
    duration: string;
}

export default class Calendar extends Component {
    events: [] = [];
    currentDate: Date = new Date();
    dayHeaders: boolean = true;
    weekends: boolean = true;
    duration: Duration = new Duration("00:15:00");
    startTime: Duration = new Duration("00:00:00");
    endTime: Duration = new Duration("23:59:59");

    static propTypes = {
        events: PropTypes.array,
        dayHeaders: PropTypes.bool,
        weekends: PropTypes.bool,
        startTime: PropTypes.string,
        endTime: PropTypes.string,
        duration: PropTypes.string
    }

    constructor(prop: Readonly<calendar> | Readonly<Calendar>) {
        super(prop);
        if (prop instanceof Calendar) {

        } else if (typeof prop === typeof Calendar.propTypes) {
            const { events, currentDate, dayHeaders, weekends, startTime, endTime, duration } = prop;
            this.events = events;
            this.currentDate = currentDate;
            this.dayHeaders = dayHeaders;
            this.weekends = weekends;
            this.startTime = new Duration(startTime);
            this.endTime = new Duration(endTime);
            this.duration = new Duration(duration);
        }
    }

    getTimeList(startTime: Duration, endTime: Duration, timeSpan: Duration): string[] {
        let frequency: number = (endTime.getTotalMinutes() - startTime.getTotalMinutes()) / timeSpan.getTotalMinutes();
        let time: string[] = [];
        let aaa = [endTime.getTotalMinutes(), startTime.getTotalMinutes(), timeSpan.getTotalMinutes()];
        frequency = parseInt(frequency.toString());
        for (let i = 0; i <= frequency; i++) {
            let temp = new Date('1970-01-01 00:00:00.000');
            temp.setMinutes(timeSpan.getTotalMinutes() * i);
            time.push(moment(temp).format("HH:mm"));
        }
        return time;
    }

    render() {
        let day = Moment(this.currentDate)
        let starttime = Moment(new Date(this.currentDate))
        let headers: string[] = [];
        let times: Moment.Moment[] = [];
        let timeRows: string[] = this.getTimeList(this.startTime, this.endTime, this.duration);
        for (let i = 0; i < (this.weekends ? 7 : 5); i++) {
            headers.push(day.day(i).format());
        }

        return (
            <div className="c-time-grid">
                <div className="c-bg">
                    <Table striped bordered hover>
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
                                        <tr key={index}>
                                            <td>{result.toString()}</td>
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
                </div>
                <div className="c-slats">
                </div>
                <div className="c-skeleton">
                    <Table>
                        <tbody>
                            {
                                headers.map((result, index) => {
                                    return (
                                        <td key={index}>
                                            {result}
                                        </td>
                                    );
                                })
                            }
                        </tbody>
                    </Table>
                </div>
            </div>
        );
    }
}

