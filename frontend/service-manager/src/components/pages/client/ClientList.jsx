import React from 'react'
import ClientItem from './ClientItem'

export default function ClientList(props) {
    return (
      <>
      <div className='mt-3'>
        {props.clients.map(c => (
          <ClientItem
            key={c.id}
            c={c}
            editClient={props.editClient}
            handleConfirmModal={props.handleConfirmModal}
          />
        ))}
      </div>
    </>
    )
  }