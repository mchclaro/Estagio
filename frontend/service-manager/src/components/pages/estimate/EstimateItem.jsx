import React from 'react'
import { PencilSimple, Trash } from 'phosphor-react'

export default function EstimateItem(props) {
    return (
      <>
        <table className='table table-striped' aria-labelledby="tabelLabel" >
        <thead>
          <tr>
            <th>Descrição</th>
            <th>Serviço</th>
            <th>Valor</th>
            <th>Data Realizada</th>
            <th>Cliente</th>
            <th>Ações</th>
          </tr>
        </thead>
        <tbody>
          <tr key={props.c.id}>
            <td>{props.c.description}</td>
            <td>{props.c.service}</td>
            <td>{props.c.value}</td>
            <td>{props.c.validateDate}</td>
            <td>{props.c.client}</td>

            <td>
              <button
                className="btn  btn-sm btn-outline-primary me-2"
                onClick={() => props.editClient(props.c.id)}>
                < PencilSimple size={18} weight="bold" />
              </button>
              <button
                className="btn btn-sm btn-outline-danger me-2"
                onClick={() => props.handleConfirmModal(props.c.id)}>
                < Trash size={18} weight="bold" />
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </>
    )
  }