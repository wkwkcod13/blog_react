import React, { Component } from "react";
import PropTypes from 'prop-types';

interface duration {
    hours: number;
    minutes: number;
    seconds: number;
    milliseconds: number;
}

export class Duration extends React.Component {
    years: number = 0;
    months: number = 0;
    days: number = 0;
    hours: number = 0;
    minutes: number = 0;
    seconds: number = 0;
    milliseconds: number = 0;

    static propTypes = {
        hours: PropTypes.number,
        minutes: PropTypes.number,
        seconds: PropTypes.number,
        milliseconds: PropTypes.number,
    }

    constructor(prop: string | Readonly<Duration> | Readonly<duration>) {
        super(prop);
        if (typeof prop === 'string') {
            let baseDate: Date = new Date(0);
            const regex1 = /^(?<hh>(?<h1>[0-1]?[0-9])|(?<h2>2[0-3])):(?<mm>[0-5][0-9])$/;
            const regex2 = /^(?<hh>(?<h1>[0-1]?[0-9])|(?<h2>2[0-3])):(?<mm>[0-5][0-9]):(?<ss>[0-5][0-9])(.(?<sss>[0-9]{1,3})?)?$/;

            if (regex1.test(prop)) {
                const { hh, mm } = regex1.exec(prop)?.groups ?? {};
                const hour: number = hh !== undefined ? parseInt(hh) : 0;
                const min: number = mm !== undefined ? parseInt(mm) : 0;
                this.hours = hour;
                this.minutes = min;

            } else if (regex2.test(prop)) {
                const { hh, mm, ss, sss } = regex2.exec(prop)?.groups ?? {};
                const hour: number = hh !== undefined ? parseInt(hh) : 0;
                const min: number = mm !== undefined ? parseInt(mm) : 0;
                const sec: number = ss !== undefined ? parseInt(ss) : 0;
                const millisec: number = sss !== undefined ? parseFloat(sss) : 0;
                this.hours = hour;
                this.minutes = min;
                this.seconds = sec;
                this.milliseconds = millisec;

            }
        }
        else if (prop instanceof Duration) {
            this.years = prop.years ?? 0;
            this.months = prop.months ?? 0;
            this.days = prop.days ?? 0;
            this.hours = prop.hours ?? 0;
            this.minutes = prop.minutes ?? 0;
            this.seconds = prop.seconds ?? 0;
            this.milliseconds = prop.milliseconds ?? 0;

        } else if (typeof prop === typeof Duration.propTypes) {
            const { hours, minutes, seconds, milliseconds } = prop;
            this.hours = hours ?? 0;
            this.minutes = minutes ?? 0;
            this.seconds = seconds ?? 0;
            this.milliseconds = milliseconds ?? 0;
        }
        console.log(this);
    }
    getTotalMinutes(): number {
        let total: number = 0;
        total += (this.hours * 60);
        total += this.minutes;
        return total;
    }

    render() {
        return null;
    }
}
