import React from 'react'
import AppointmentItem from './AppointmentItem'

export default function AppointmentList(props) {
    return (
      <>
      <div className='mt-3'>
        {props.appointments.map(c => (
          <AppointmentItem
            key={c.id}
            c={c}
            editAppointment={props.editAppointment}
            handleConfirmModal={props.handleConfirmModal}
          />
        ))}
      </div>
    </>
    )
  }