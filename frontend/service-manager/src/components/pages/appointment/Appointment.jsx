import axios from "axios";
import { useEffect, useState } from "react";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "react-bootstrap";
import styles from './Appointment.module.css'
import { PencilSimple, Trash, Plus, CheckCircle, XCircle } from 'phosphor-react'
import api from "../../../api/servicemanager";

export default function Appointment() {

  const baseUrl = "https://localhost:5001/api/Appointment/";
  const [data, setData] = useState([]);
  const [smshowConfirmModal, setSmshowConfirmModal] = useState(false);
  const [showAppointmentModal, setShowAppointmentModal] = useState(false);
  const handleAppointmentModal = () => setShowAppointmentModal(!showAppointmentModal);
  const [appointment, setAppointment] = useState({ id: 0 });

  const newAppointment = () => {
    setAppointment({ id: 0 });
    handleAppointmentModal();
  };

  const addAppointment = async () => {
    handleAppointmentModal();
    const response = await axios.post(`${baseUrl}create`, appointmentSelected)
    setData([...data, response.data.data]);
  };

  // const  addAppointment = async () => {
  //   delete appointmentSelected.id;
  //   await axios.post(`${baseUrl}create`, appointmentSelected)
  //   .then(response => {
  //     setData(data.concat(response.data.data));
  //   }).catch(error => {
  //     console.log(error);
  //   })
  // }

  const editAppointment = (id) => {
    const appoint = data.filter((c) => c.id === id);
    setAppointment(appoint[0]);
    handleAppointmentModal();
  };

  const cancelAppointment = () => {
    setAppointment({ id: 0 });
    handleAppointmentModal();
  };

  const handleConfirmModal = (id) => {
    if (id !== 0 && id !== undefined) {
      const appoint = data.filter((c) => c.id === id);
      setAppointment(appoint[0]);
    } else {
      setAppointment({ id: 0 });
    }
    setSmshowConfirmModal(!smshowConfirmModal);
  };

  const [appointmentSelected, setAppointmentSelected] = useState({
    id: '',
    description: '',
    dataHeld: '',
    status: '',
    estimateId: '',
    clientId: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setAppointmentSelected({
      ...appointmentSelected,
      [name]: value
    });
  }

  const getAppointments = async () => {
    await axios.get(`${baseUrl}read/all`).then(response => {
      setData(response.data.data);
    }).catch(error => {
      console.log(error);
    })
  };

  const deleteAppointment = async (id) => {
    handleConfirmModal(0);
    if (await api.delete(`Appointment/delete/${id}`)) {
      const clientsFilter = data.filter((c) => c.id !== id);
      setData([...clientsFilter]);
    }
  };

  // const addAppointment = async () => {
  //   delete appointmentSelected.id;
  //   await axios.post(`${baseUrl}create`, appointmentSelected)
  //     .then(response => {
  //       setData(data.concat(response.data.data));
  //       openCloseModalInclude();
  //     }).catch(error => {
  //       console.log(error);
  //     })
  // }

  useEffect(() => {
    getAppointments();
  }, [])

  return (
    <>
      <div className="container">
        <div className={styles.container}>
          <h3>Agendamentos</h3>
          <div className="form-outline" style={{ width: "500px" }}>
            <input type="search" id="search" className="form-control" placeholder="Buscar agendamento" aria-label="Search" />
          </div>
          <header>
            <Button
              className="mb-2"
              onClick={newAppointment}
              style={{ backgroundColor: '#00509d' }}>
              <Plus size={22} weight="bold" />
              <b className="p-1 me-1">Novo Agendamento</b>
            </Button>
          </header>
          <hr />
        </div >
        <div className={styles.table_responsive}>
          <table className={"table table-responsive table-borderless table-light table-striped"}>
            <thead>
              <tr>
                <th scope="col">Id</th>
                <th scope="col">Descrição</th>
                <th scope="col">Data Realizada</th>
                <th scope="col">Status</th>
                <th scope="col">EstimateId</th>
                <th scope="col">ClientId</th>
                <th scope="col">Ações</th>
              </tr>
            </thead>
            <tbody>
              {data.map(app =>
                <tr key={app.id}>
                  <td>{app.id}</td>
                  <td>{app.description}</td>
                  <td>{app.dataHeld}</td>
                  <td>{app.status}</td>
                  <td>{app.estimateId}</td>
                  <td>{app.clientId}</td>

                  <td>
                    <button
                      className="btn  btn-sm btn-outline-primary me-2"
                      onClick={() => editAppointment(app.id)}
                    >
                      <PencilSimple size={18} weight="bold" />
                    </button>
                    <button
                      className="btn btn-sm btn-outline-danger me-2"
                      onClick={() => handleConfirmModal(app.id)}
                    >
                      <Trash size={18} weight="bold" />
                    </button>
                  </td>
                </tr>
              )}
            </tbody>
          </table>
        </div >

        <Modal size="lg" show={showAppointmentModal} onHide={handleAppointmentModal}>
          <ModalHeader> Adicionar Agendamento </ModalHeader>
          <ModalBody>
            <div className="col-md-6">
              <label className="form-label">Descrição</label>
              <input
                name="description"
                onChange={handleChange}
                id="description"
                type="text"
                className="form-control"
              />
            </div>

            <div className="col-md-6">
              <label className="form-label">Data Realizada</label>
              <input
                name="dataheld"
                onChange={handleChange}
                id="dataheld"
                type="date"
                className="form-control"
              />
            </div>

            <div className="col-md-6">
              <label className="form-label">Status</label>
              <select
                name="status"
                onChange={handleChange}
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
                name="estimateId"
                onChange={handleChange}
                id="estimateId"
                type="text"
                className="form-control"
              />
              <br />
            </div>

            <div className="col-md-6">
              <label className="form-label">Cliente</label>
              <input
                name="clientId"
                onChange={handleChange}
                id="clientId"
                type="text"
                className="form-control"
              />
              <br />
            </div>
          </ModalBody>

          <ModalFooter>
            <div className="col-12 mt-0">
              <button
                className="btn btn-outline-success position: relative me-2"
                type='submit'
                onClick={() => addAppointment()}
              >
                Salvar
              </button>
              <button
                className="btn btn-outline-danger position: relative me-2"
                onClick={cancelAppointment}
              >
                Cancelar
              </button>
            </div>
          </ModalFooter>
        </Modal>

        <Modal size="sm" show={smshowConfirmModal} onHide={handleConfirmModal}>
          <Modal.Header closeButton>
            <Modal.Title>Excluir Agendamento</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            Tem certeza que deseja excluir o agendamento {appointment.id}?
          </Modal.Body>
          <Modal.Footer className="d-flex justify-content-between">
            <button
              className="btn btn-outline-success me-2"
              onClick={() => deleteAppointment(appointment.id)}
            >
              <CheckCircle size={20} weight="bold" />
            </button>

            <button
              className="btn btn-danger me-2"
              onClick={() => handleConfirmModal(0)}
            >
              <XCircle size={20} weight="bold" />
            </button>
          </Modal.Footer>
        </Modal>
      </div>
    </>
  )
}