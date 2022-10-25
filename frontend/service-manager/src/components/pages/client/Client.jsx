import axios from "axios";
import { useEffect, useState } from "react";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "react-bootstrap";
import styles from './Client.module.css'
import { PencilSimple, Trash, Plus, CheckCircle, XCircle } from 'phosphor-react'
import api from "../../../api/servicemanager";
import Sidebar from "../../layouts/Sidebar";

export default function Client() {

  const baseUrl = "https://localhost:5001/api/Client/";
  const [data, setData] = useState([]);
  const [smshowConfirmModal, setSmshowConfirmModal] = useState(false);
  const [showClientModal, setShowClientModal] = useState(false);
  const handleClientModal = () => setShowClientModal(!showClientModal);
  const [client, setClient] = useState({ id: 0 });

  const [street, setStreet] = useState("");
  const [streetNumber, setStreetNumber] = useState("");
  const [zipCode, setZipcode] = useState("");
  const [district, setDistrict] = useState("");
  const [city, setCity] = useState("");
  const [state, setState] = useState("");

  const [clientSelected, setClientSelected] = useState({
    name: '',
    phone: '',
    photoUrl: '',
    addressStreet: '',
    addressStreetNumber: '',
    addressDistrict: '',
    zipcode: '',
    addressState: '',
    addressCity: ''
  });

  const newClient = () => {
    setClient({ id: 0 });
    handleClientModal();
  };

  const addClient = async () => {
    handleClientModal();
    const response = await axios.post(`${baseUrl}create`, clientSelected)
    setData([...data, response.data.data]);
    console.log(data);
  };

  const editClient = (id) => {
    const client = data.filter((c) => c.id === id)[0];
    
    setStreet(client.address.street);
    setStreetNumber(client.address.streetNumber);
    setZipcode(client.address.zipCode);
    setDistrict(client.address.district);
    setCity(client.address.city);
    setState(client.address.state);
    setClient(client);
    handleClientModal();
  };

  const cancelClient = () => {
    setClient({ id: 0 });
    handleClientModal();
  };

  const handleConfirmModal = (id) => {
    if (id !== 0 && id !== undefined) {
      const cli = data.filter((c) => c.id === id);
      setClient(cli[0]);
    } else {
      setClient({ id: 0 });
    }
    setSmshowConfirmModal(!smshowConfirmModal);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setClient({
      ...client,
      [name]: value
    });
  }

  const getClients = async () => {
    await axios.get(`${baseUrl}read/all`).then(response => {
      setData(response.data.data);
    }).catch(error => {
      console.log(error);
    })
  };

  const deleteClient = async (id) => {
    handleConfirmModal(0);
    if (await api.delete(`Client/delete/${id}`)) {
      const clientsFilter = data.filter((c) => c.id !== id);
      setData([...clientsFilter]);
    }
  };

  // const updateClient = async (c) => {
  //   handleClientModal();
  //   const response = await axios.put(`${baseUrl}update`, clientSelected)
  //   const { id } = response.data;
  //   setData(data.map((item) => (item.id === id ? response.data : item)));
  //   setClient({ id: 0 });
  // };

  useEffect(() => {
    getClients();
  }, [])

  return (
    <>
      <Sidebar />
      <div className="container">
        <div className={styles.container}>
          <h3>Clientes</h3>
          <div className="form-outline" style={{ width: "500px" }}>
            <input type="search" id="search" className="form-control" placeholder="Buscar clientes" aria-label="Search" />
          </div>
          <header>
            <Button
              className="mb-2"
              onClick={newClient}
              style={{ backgroundColor: '#00509d' }}>
              <Plus size={22} weight="bold" />
              <b className="p-1 me-1">Novo Cliente</b>
            </Button>
          </header>
          <hr />
        </div >
        <div className={styles.table_responsive}>
          <table className="table table-responsive table-borderless table-light table-striped">
            <thead>
              <tr>
                <th scope="col">Id</th>
                <th scope="col">Nome</th>
                <th scope="col">Telefone</th>
                <th scope="col">Endereço</th>
                <th scope="col">Cidade</th>
                <th scope="col">Estado</th>
                <th scope="col">Ações</th>
              </tr>
            </thead>
            <tbody>
              {data.map(cli =>
                <tr key={cli.id}>
                  <td>{cli.id}</td>
                  <td>{cli.name}</td>
                  <td>{cli.phone}</td>
                  <td>{cli.address.street}, {cli.address.streetNumber}, {cli.address.district}, {cli.address.zipCode}
                  </td>
                  <td>{cli.address.city}</td>
                  <td>{cli.address.state}</td>
                  <td>
                    <button
                      className="btn  btn-sm btn-outline-primary me-2"
                      onClick={() => editClient(cli.id)}
                    >
                      <PencilSimple size={18} weight="bold" />
                    </button>
                    <button
                      className="btn  btn-sm btn-outline-danger me-2"
                      onClick={() => deleteClient(cli.id)}
                    >
                      <Trash size={18} weight="bold" />
                    </button>
                  </td>
                </tr>
              )}
            </tbody>
          </table>
        </div >
        <Modal size="lg" show={showClientModal} onHide={handleClientModal}>
          <ModalHeader> Adicionar Cliente </ModalHeader>
          <ModalBody>
            <form encType="multipart/form-data">
              <div className="col-md-6">
                <label className="form-label">Nome</label>
                <input
                  name="name"
                  value={client.name}
                  onChange={handleChange}
                  id="name"
                  type="text"
                  className="form-control"
                />
              </div>

              <div className="col-md-6">
                <label className="form-label">Telefone</label>
                <input
                  name="phone"
                  value={client.phone}
                  onChange={handleChange}
                  id="phone"
                  type="text"
                  className="form-control"
                />
              </div>

              <div className="col-md-10">
                <label className="form-label">Foto</label>
                <input
                  name="photoUrl"
                  onChange={handleChange}
                  id="photoUrl"
                  type="file"
                  className="form-control"
                />
                <br />
              </div>

              <h4>Endereço do cliente</h4>
              <div className="col-md-6">
                <label className="form-label">Rua</label>
                <input
                  name="addressStreet"
                  value={street}
                  onChange={e => {
                    setStreet(e.target.value)
                  }}
                  id="addressStreet"
                  type="text"
                  className="form-control"
                />
                <br />
              </div>

              <div className="col-md-6">
                <label className="form-label">Número</label>
                <input
                  name="addressStreetNumber"
                  value={streetNumber}
                  onChange={e => {
                    setStreetNumber(e.target.value)
                  }}
                  id="addressStreetNumber"
                  type="text"
                  className="form-control"
                />
                <br />
              </div>

              <div className="col-md-6">
                <label className="form-label">Bairro</label>
                <input
                  name="addressDistrict"
                  value={district}
                  onChange={e => {
                    setDistrict(e.target.value)
                  }}
                  id="addressDistrict"
                  type="text"
                  className="form-control"
                />
                <br />
              </div>

              <div className="col-md-6">
                <label className="form-label">CEP</label>
                <input
                  name="zipcode"
                  value={zipCode}
                  onChange={e => {
                    setZipcode(e.target.value)
                  }}
                  id="zipcode"
                  type="text"
                  className="form-control"
                />
                <br />
              </div>

              <div className="col-md-6">
                <label className="form-label">Estado</label>
                <select
                  name="addressState"
                  value={state}
                  onChange={e => {
                    setState(e.target.value)
                  }}
                  id="addressState"
                  type="text"
                  className="form-select"
                >
                  <option defaultValue="Não definido">Selecionar</option>
                  <option value="São Paulo">São Paulo</option>
                  <option value="Acre">Acre</option>
                  <option value="Alagoas">Alagoas</option>
                  <option value="Amapá">Amapá</option>
                  <option value="Amazonas">Amazonas</option>
                  <option value="Bahia">Bahia</option>
                  <option value="Ceará">Ceará</option>
                  <option value="Distrito Federal">Distrito Federal</option>
                  <option value="Espírito Santo">Espírito Santo</option>
                  <option value="Goiás">Goiás</option>
                  <option value="Maranhão">Maranhão</option>
                  <option value="Mato Grosso">Mato Grosso</option>
                  <option value="Mato Grosso do Sul">Mato Grosso do Sul</option>
                  <option value="Minas Gerais">Minas Gerais</option>
                  <option value="Pará">Pará</option>
                  <option value="Paraíba">Paraíba</option>
                  <option value="Paraná">Paraná</option>
                  <option value="Pernambuco">Pernambuco</option>
                  <option value="Piauí">Piauí</option>
                  <option value="Rio de Janeiro">Rio de Janeiro</option>
                  <option value="Rio Grande do Norte">Rio Grande do Norte</option>
                  <option value="Rio Grande do Sul">Rio Grande do Sul</option>
                  <option value="Rondônia">Rondônia</option>
                  <option value="Roraima">Roraima</option>
                  <option value="Santa Catarina">Santa Catarina</option>
                  <option value="Sergipe">Sergipe</option>
                  <option value="Tocantins">Tocantins</option>
                </select>
                <br />
              </div>

              <div className="col-md-6">
                <label className="form-label">Cidade</label>
                <input
                  name="addressCity"
                  value={city}
                  onChange={e=> {
                    setCity(e.target.value)
                  }}
                  id="addressCity"
                  type="text"
                  className="form-control"
                />
                <br />
              </div>
            </form>
          </ModalBody>

          <ModalFooter>
            <div className="col-12 mt-0">
              <button
                className="btn btn-outline-success position: relative me-2"
                type='submit'
                onClick={() => addClient()}
              >
                Salvar
              </button>
              <button
                className="btn btn-outline-danger position: relative me-2"
                onClick={cancelClient}
              >
                Cancelar
              </button>
            </div>
          </ModalFooter>
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

      </div>
    </>
  );
}