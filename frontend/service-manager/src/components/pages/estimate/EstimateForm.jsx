import { useEffect, useState } from 'react'

const initialEstimate = {
  id: 0,
  description: '',
  service: '',
  value: '',
  validateDate: '',
  client: ''
}



export default function EstimateForm(props) {
  const [estimate, setEstimate] = useState(currentEstimate());


  useEffect(() => {
    if (props.estimateSelected.id !== 0)
      setEstimate(props.estimateSelected);
  }, [props.estimateSelected]);

  const inputTextHandler = (e) => {
    const { name, value } = e.target;

    setEstimate({ ...estimate, [name]: value })
  }

  function currentEstimate() {
    if (props.estimateSelected.id !== 0) {
      return props.estimateSelected;
    }
    else {
      return initialEstimate;
    }
  }

  const handleSubmit = (e) => {
    e.preventDefault();

    if (props.estimateSelected.id !== 0)
      props.updateEstimate(estimate)
    else
      props.addEstimate(estimate);

    setEstimate(initialEstimate);
  }

  const handleCancel = (e) => {
    e.preventDefault();
    props.cancelEstimate();

    setEstimate(initialEstimate);
  }

  return (
    <>
      <form className='row g-3' onSubmit={handleSubmit}>
        <div className="col-md-6">
          <label className="form-label">Descrição</label>
          <input
            name="description"
            value={estimate.description}
            onChange={inputTextHandler}
            id="description"
            type="text"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Serviço</label>
          <input
            name="service"
            value={estimate.service}
            onChange={inputTextHandler}
            id="service"
            type="text"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Valor</label>
          <input
            name="value"
            value={estimate.value}
            onChange={inputTextHandler}
            id="value"
            type="text"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Data de Validade</label>
          <input
            name="validateDate"
            value={estimate.validateDate}
            onChange={inputTextHandler}
            id="validateDate"
            type="date"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Cliente</label>
          <input
            name="client"
            value={estimate.client}
            onChange={inputTextHandler}
            id="client"
            type="text"
            className="form-control"
          />
          <br />
        </div>

        <div className="col-12 mt-0">
          {
            estimate.id === 0 ?
              <button
                className="btn btn-outline-success position: relative"
                type='submit'
              >
                Salvar
              </button>
              :
              <>
                <button
                  className="btn btn-outline-success position: relative me-2"
                  type='submit'
                >
                  Salvar
                </button>
                <button
                  className="btn btn-outline-warning position: relative me-2"
                  onClick={handleCancel}
                >
                  Cancelar
                </button>
              </>
          }
        </div>

      </form>
    </>
  )
}