// Calendar.jsx
import React, { useRef, useEffect } from 'react';
import { Calendar } from '@fullcalendar/core';
import timeGridPlugin from '@fullcalendar/timegrid';

const AdminCalendar = () => {
  const calendarRef = useRef(null);

  useEffect(() => {
    // Render the calendar after component mounts
    if (calendarRef.current) {
      const calendar = new Calendar(calendarRef.current, {
        plugins: [timeGridPlugin],
        initialView: 'timeGridWeek',
        dropAccept: true,
        events: [
    { // this object will be "parsed" into an Event Object
      title: 'The Title', // a property!
      start: '2024-10-24', // a property!
      end: '2024-10-26' // a property! ** see important note below about 'end' **
    }
  ],
        headerToolbar: {
        left: 'prev,next today',
        center: 'title',
        right: 'timeGridWeek,timeGridDay' // user can switch between the two
        }
      });
      calendar.render();
    }
  }, []);

  return <div id="calendar" ref={calendarRef}></div>;
};

export default AdminCalendar;
