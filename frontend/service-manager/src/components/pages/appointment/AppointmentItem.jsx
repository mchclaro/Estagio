import React from 'react'
import { PencilSimple, Trash } from "phosphor-react";

export default function AppointmentItem(props) {
  return (
    <div className="card mb-2 shadow-sm" >
      <div className="card-body">

        <div className="card-text">
          <strong>Descrição:</strong> {props.c.description} <br />
          <strong>Data Realizada:</strong>  {props.c.dataHeld} <br />
          <strong>Status</strong> {props.c.status}
          <strong>Orçamento</strong> {props.c.estimate}
          <strong>Cliente</strong> {props.c.client}
        </div>

        <div className='d-flex justify-content-end pt-2 m-0'>
          <button
            className="btn  btn-sm btn-outline-primary me-2"
            onClick={() => props.editAppointment(props.c.id)}>
            < PencilSimple size={18} weight="bold" />
          </button>
          <button
            className="btn btn-sm btn-outline-danger me-2"
            onClick={() => props.handleConfirmModal(props.c.id)}>
            < Trash size={18} weight="bold" />
          </button>
        </div>
      </div>
    </div>
  )
}