import moment, { Moment } from 'moment';
import React from 'react';
import PropTypes from 'prop-types';

function CalendarEvent(
    obj: {
        FromDate?: Moment | Date | string,
        ToDate?: Moment | Date | string,
        Title?: string,
        Description?: string | undefined | any,
        Name?: string | undefined
    }) {
    return (
        <p>Hello world!</p>
    );
}

export default CalendarEvent;