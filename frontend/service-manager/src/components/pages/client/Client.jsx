import { useState, useEffect } from "react";
import ClientForm from "./ClientForm";
import ClientList from "./ClientList";
import api from "../../../api/servicemanager";
import { Button, Modal } from "react-bootstrap";
import { UserPlus, CheckCircle, XCircle } from "phosphor-react";

function Client() {
  const [showClientModal, setShowClientModal] = useState(false);
  const [smshowConfirmModal, setSmshowConfirmModal] = useState(false);
  const [clients, setClients] = useState([]);
  const [client, setClient] = useState({ id: 0 });

  const handleClientModal = () => setShowClientModal(!showClientModal);

  const handleConfirmModal = (id) => {
    if (id !== 0 && id !== undefined) {
      const client = clients.filter((c) => c.id === id);
      setClient(client[0]);
    } else {
      setClient({ id: 0 });
    }
    setSmshowConfirmModal(!smshowConfirmModal);
  };

  const getClients = async () => {
    const response = await api.get("Client/read/all");
    return response.data;
  };

  const newClient = () => {
    setClient({ id: 0 });
    handleClientModal();
  };

  useEffect(() => {
    const catchClients = async () => {
      const all = await getClients();
      if (all) setClients(all);
    };
    catchClients();
  }, []);

  const addClient = async (c) => {
    handleClientModal();
    const response = await api.post("Client/create", c);
    setClients([...clients, response.data]);
  };

  const deleteClient = async (id) => {
    handleConfirmModal(0);
    if (await api.delete(`Client/delete/${id}`)) {
      const clientsFilter = clients.filter((c) => c.id !== id);
      setClients([...clientsFilter]);
    }
  };

  const cancelClient = () => {
    setClient({ id: 0 });
    handleClientModal();
  };

  const updateClient = async (c) => {
    handleClientModal();
    const response = await api.put("Client/update/", c);
    const { id } = response.data;
    setClients(clients.map((item) => (item.id === id ? response.data : item)));
    setClient({ id: 0 });
  };

  const editClient = (id) => {
    const client = clients.filter((c) => c.id === id);
    setClient(client[0]);
    handleClientModal();
  };

  return (
    <>
      <div>
        <h1>Todos clientes</h1>
        <Button variant="primary" onClick={newClient}>
          <UserPlus size={22} weight="bold" />
        </Button>
      </div>

      <ClientList
        clients={clients}
        editClient={editClient}
        handleConfirmModal={handleConfirmModal}
      />

      <Modal size="lg" show={showClientModal} onHide={handleClientModal}>
        <Modal.Header closeButton>
          <Modal.Title>Novo Cliente</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <ClientForm
            addClient={addClient}
            cancelClient={cancelClient}
            updateClient={updateClient}
            clientSelected={client}
            clients={clients}
          />
        </Modal.Body>
      </Modal>

      <Modal size="sm" show={smshowConfirmModal} onHide={handleConfirmModal}>
        <Modal.Header closeButton>
          <Modal.Title>Excluir Cliente</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Tem certeza que deseja excluir o cliente {client.name}?
        </Modal.Body>
        <Modal.Footer className="d-flex justify-content-between">
          <button
            className="btn btn-outline-success me-2"
            onClick={() => deleteClient(client.id)}
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
  );
}

export default Client;