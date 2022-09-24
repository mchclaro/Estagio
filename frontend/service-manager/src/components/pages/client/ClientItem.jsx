import React from 'react'
import { PencilSimple, Trash } from 'phosphor-react'

export default function ClientItem(props) {
  return (
    <>
      <table className='table table-striped' aria-labelledby="tabelLabel" >
        <thead>
          <tr>
            <th>Nome</th>
            <th>Telefone</th>
            <th>Foto</th>
            {/* <th>Rua</th>
              <th>Número</th> */}
            <th>Ações</th>
          </tr>
        </thead>
        <tbody>
          <tr key={props.c.id}>
            <td>{props.c.name}</td>
            <td>{props.c.phone}</td>
            <td>{props.c.photoUrl}</td>

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