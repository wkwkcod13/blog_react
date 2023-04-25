import React, { Component } from "react";
import PropTypes from 'prop-types';

export class Duration extends Component {
    years: number = 0;
    months: number = 0;
    days: number = 0;
    hours: number = 0;
    minutes: number = 0;
    milliseconds: number = 0;
    static propTypes = {
        years: PropTypes.number,
        months: PropTypes.number,
        days: PropTypes.number,
        hours: PropTypes.number,
        minutes: PropTypes.number,
        seconds: PropTypes.number,
        milliseconds: PropTypes.number,
    }

    constructor(prop: string | Readonly<Duration>) {
        super(prop);
        if (typeof prop === 'string') {
            let baseDate: Date = new Date(0);
            const regex1 = /^(?<hh>(?<h1>[0-1]?[0-9])|(?<h2>2[0-3])):(?<mm>[0-5][0-9])$/;
            const regex2 = /^(?<hh>(?<h1>[0-1]?[0-9])|(?<h2>2[0-3])):(?<mm>[0-5][0-9]):(?<ss>[0-5][0-9])(.(?<sss>[0-9]{1,3})?)?$/;

            if (regex1.test(prop)) {
                const { hh, mm } = regex1.exec(prop)?.groups ?? {};
                const hour: number = hh !== undefined ? parseInt(hh) : 0;
                const min: number = mm !== undefined ? parseInt(mm) : 0;
                let temp = new Date(0);
                temp.setUTCHours(hour);
                temp.setUTCMinutes(min);
                const duration = temp.getTime() - new Date(0).getTime();
                this.milliseconds = duration;
            } else if (regex2.test(prop)) {
                const { hh, mm, ss, sss } = regex2.exec(prop)?.groups ?? {};
                const hour: number = hh !== undefined ? parseInt(hh) : 0;
                const min: number = mm !== undefined ? parseInt(mm) : 0;
                const sec: number = ss !== undefined ? parseInt(ss) : 0;
                const millisec: number = sss !== undefined ? parseFloat(sss) : 0;
                let temp = new Date(0);
                temp.setUTCHours(hour);
                temp.setUTCMinutes(min);
                temp.setUTCSeconds(sec);
                temp.setUTCMilliseconds(millisec);
                const duration = temp.getTime() - new Date(0).getTime()
                this.milliseconds = duration;
            }
        }
        else if (prop instanceof Duration) {
            this.years = prop.years;
            this.months = prop.months;
            this.days = prop.days;
            this.milliseconds = prop.milliseconds;
        }
        else if (typeof prop === typeof Duration.propTypes) {
            this.years = prop.years ?? 0;
            this.months = prop.months ?? 0;
            this.days = prop.days ?? 0;
            this.milliseconds = prop.milliseconds ?? 0;
        }
        console.log(this);
    }

    add(b: Duration): number {
        return this.milliseconds + b.milliseconds;
    }

    subtract(other: Duration): number {
        return this.milliseconds - other.milliseconds;
    }

    render() {
        return null;
    }
}