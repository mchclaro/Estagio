import { useEffect, useState } from 'react'

const initialAppointment = {
  id: 0,
  description: '',
  dataHeld: '',
  status: '',
  estimate: '',
  client: ''
}

export default function AppointmentForm(props) {
  const [appointment, setAppointment] = useState(currentAppointment());


  useEffect(() => {
    if (props.appointmentSelected.id !== 0)
      setAppointment(props.appointmentSelected);
  }, [props.appointmentSelected]);

  const inputTextHandler = (e) => {
    const { name, value } = e.target;

    setAppointment({ ...appointment, [name]: value })
  }

  function currentAppointment() {
    if (props.appointmentSelected.id !== 0) {
      return props.appointmentSelected;
    }
    else {
      return initialAppointment;
    }
  }

  const handleSubmit = (e) => {
    e.preventDefault();

    if (props.appointmentSelected.id !== 0)
      props.updateAppointment(appointment)
    else
      props.addAppointment(appointment);

    setAppointment(initialAppointment);
  }

  const handleCancel = (e) => {
    e.preventDefault();
    props.cancelAppointment();

    setAppointment(initialAppointment);
  }

  return (
    <>
      <form className='row g-3' onSubmit={handleSubmit}>
        <div className="col-md-6">
          <label className="form-label">Descrição</label>
          <input
            name="description"
            value={appointment.description}
            onChange={inputTextHandler}
            id="description"
            type="text"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Data Realizada</label>
          <input
            name="dataheld"
            value={appointment.dataheld}
            onChange={inputTextHandler}
            id="dataheld"
            type="date"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Status</label>
          <select
            name="status"
            value={appointment.status}
            onChange={inputTextHandler}
            id="status"
            type="text"
            className="form-select"
          >
            <option defaultValue="Não definido">Selecionar</option>
            <option value="Canceled">Cancelado</option>
            <option value="Pending">Pendente</option>
            <option value="Concluded">Concluído</option>
          </select>
          <br />
        </div>

        <div className="col-md-6">
          <label className="form-label">Orçamento</label>
          <input
            name="estimate"
            value={appointment.estimate}
            onChange={inputTextHandler}
            id="estimate"
            type="text"
            className="form-control"
          />
          <br />
        </div>

        <div className="col-md-6">
          <label className="form-label">Cliente</label>
          <input
            name="client"
            value={appointment.client}
            onChange={inputTextHandler}
            id="client"
            type="text"
            className="form-control"
          />
          <br />
        </div>

        <div className="col-12 mt-0">
          {
            appointment.id === 0 ?
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