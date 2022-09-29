import axios from "axios";
import { Plus } from "phosphor-react";
import { useEffect, useState } from "react";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "react-bootstrap";
import api from "../../../api/servicemanager";
import styles from './Estimate.module.css'

export default function Estimate(props) {
  const baseUrl = "https://localhost:5001/api/Estimate/";
  const [data, setData] = useState([]);
  const [showEstimateModal, setShowEstimateModal] = useState(false);
  const handleEstimateModal = () => setShowEstimateModal(!showEstimateModal);
  const [estimate, setEstimate] = useState({ id: 0 });


  const newEstimate = () => {
    setEstimate({ id: 0 });
    handleEstimateModal();
  };

  const addEstimate = async (c) => {
    handleEstimateModal();
    const response = await axios.post(`${baseUrl}create`, c)
    setData([...data, response.data.data]);
    console.log(data);
  };

  const cancelEstimate = () => {
    setEstimate({ id: 0 });
    handleEstimateModal();
  };

  const [estimateSelected, setEstimateSelected] = useState({
    id: '',
    description: '',
    service: '',
    value: '',
    validateDate: '',
    client: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEstimateSelected({
      ...estimateSelected,
      [name]: value
    });
  };

  const getEstimate = async () => {
    await axios.get(`${baseUrl}read/all`).then(response => {
      setData(response.data.data);
    }).catch(error => {
      console.log(error);
    })
  };

  useEffect(() => {
    getEstimate();
  }, [])

  return (
    <>
      <div className={styles.container}>
        <h3>Orçamentos</h3>
        <div className="form-outline" style={{ width: "500px" }}>
          <input type="search" id="form1" className="form-control" placeholder="Buscar orçamento" aria-label="Search" />
        </div>
        <header>
          <Button
            className="mb-2"
            onClick={newEstimate}
            style={{ backgroundColor: '#00509d' }}>
            <Plus size={22} weight="bold" />
            <b className="p-1 me-1">Novo Orçamento</b>
          </Button>
        </header>
        <hr />
      </div>
      <div className={styles.table_responsive}>
        <table className={"table table-responsive table-borderless table-light table-striped"}>
          <thead className="table-dark">
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Serviço</th>
              <th scope="col">Descrição</th>
              <th scope="col">Valor</th>
              <th scope="col">Data de Validade</th>
              <th scope="col">Cliente</th>
            </tr>
          </thead>
          <tbody className={styles.tbody}>
            {data.map(est =>
              <tr key={est.id}>
                <td>{est.id}</td>
                <td>{est.service}</td>
                <td>{est.description}</td>
                <td>R$ {est.value}</td>
                <td>{est.validateDate}</td>
                <td>{est.clientId}</td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      <Modal size="lg" show={showEstimateModal} onHide={handleEstimateModal}>
        <ModalHeader> Adicionar Orçamento </ModalHeader>
        <ModalBody>
        <div className="col-md-6">
            <label className="form-label">Serviço</label>
            <input
              name="service"
              onChange={handleChange}
              id="service"
              type="text"
              className="form-control"
            />
          </div>

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
            <label className="form-label">Valor</label>
            <input
              name="value"
              onChange={handleChange}
              id="value"
              type="text"
              className="form-control"
            />
            <br />
          </div>

          <div className="col-md-6">
            <label className="form-label">Data de Validade</label>
            <input
              name="validateDate"
              onChange={handleChange}
              id="validateDate"
              type="date"
              className="form-control"
            />
            <br />
          </div>

          <div className="col-md-6">
            <label className="form-label">Cliente</label>
            <input
              name="client"
              onChange={handleChange}
              id="client"
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
              onClick={() => addEstimate()}
            >
              Salvar
            </button>
            <button
              className="btn btn-outline-danger position: relative me-2"
              onClick={cancelEstimate}
            >
              Cancelar
            </button>
          </div>
        </ModalFooter>
      </Modal>
    </>
  );
}

