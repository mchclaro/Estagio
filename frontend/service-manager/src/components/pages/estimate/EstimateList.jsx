import React from 'react'
import EstimateItem from './EstimateItem'

export default function EstimateList(props) {
    return (
      <>
      <div className='mt-3'>
        {props.estimates.map(c => (
          <EstimateItem
            key={c.id}
            c={c}
            editEstimate={props.editEstimate}
            handleConfirmModal={props.handleConfirmModal}
          />
        ))}
      </div>
    </>
    )
  }