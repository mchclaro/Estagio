import { useState, useEffect } from "react";
import AppointmentForm from "./AppointmentForm";
import AppointmentList from "./AppointmentList";
import api from "../../../api/servicemanager";
import { Button, Modal } from "react-bootstrap";
import { UserPlus, CheckCircle, XCircle } from "phosphor-react";

export default function Appointment() {
  const [showAppointmentModal, setShowAppointmentModal] = useState(false);
  const [smshowConfirmModal, setSmshowConfirmModal] = useState(false);
  const [appointments, setAppointments] = useState([]);
  const [appointment, setAppointment] = useState({ id: 0 });

  const handleAppointmentModal = () => setShowAppointmentModal(!showAppointmentModal);

  const handleConfirmModal = (id) => {
    if (id !== 0 && id !== undefined) {
      const appointment = appointments.filter((c) => c.id === id);
      setAppointment(appointment[0]);
    } else {
      setAppointment({ id: 0 });
    }
    setSmshowConfirmModal(!smshowConfirmModal);
  };

  const getAppointments = async () => {
    const response = await api.get("Appointment/read/all");
    return response.data;
  };

  const newAppointment = () => {
    setAppointment({ id: 0 });
    handleAppointmentModal();
  };

  useEffect(() => {
    const catchAppointments = async () => {
      const all = await getAppointments();
      if (all) setAppointments(all);
    };
    catchAppointments();
  }, []);

  const addAppointment = async (c) => {
    handleAppointmentModal();
    const response = await api.post("Appointment/create", c);
    setAppointments([...appointments, response.data]);
  };

  const deleteAppointment = async (id) => {
    handleConfirmModal(0);
    if (await api.delete(`Appointment/delete/${id}`)) {
      const appointmentsFilter = appointments.filter((c) => c.id !== id);
      setAppointments([...appointmentsFilter]);
    }
  };

  const cancelAppointment = () => {
    setAppointment({ id: 0 });
    handleAppointmentModal();
  };

  const updateAppointment = async (c) => {
    handleAppointmentModal();
    const response = await api.put("Appointment/update/", c);
    const { id } = response.data;
    setAppointments(appointments.map((item) => (item.id === id ? response.data : item)));
    setAppointment({ id: 0 });
  };

  const editAppointment = (id) => {
    const appointment = appointments.filter((c) => c.id === id);
    setAppointment(appointment[0]);
    handleAppointmentModal();
  };

  return (
    <>
      <div>
        <h1>Todos agendamentos</h1>
        <Button variant="primary" onClick={newAppointment}>
          <UserPlus size={22} weight="bold" />
        </Button>
      </div>

      <AppointmentList
        appointments={appointments}
        editAppointment={editAppointment}
        handleConfirmModal={handleConfirmModal}
      />

      <Modal size="lg" show={showAppointmentModal} onHide={handleAppointmentModal}>
        <Modal.Header closeButton>
          <Modal.Title>Novo Agendamento</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <AppointmentForm
            addAppointment={addAppointment}
            cancelAppointment={cancelAppointment}
            updateAppointment={updateAppointment}
            appointmentSelected={appointment}
            appointments={appointments}
          />
        </Modal.Body>
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
    </>
  )
}