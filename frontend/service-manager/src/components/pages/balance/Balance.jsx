import axios from 'axios';
import { useState } from 'react';
import { Button } from 'react-bootstrap'
import { BsCheckCircleFill } from 'react-icons/bs'
import { FaHourglassHalf } from 'react-icons/fa'
import Sidebar from '../../layouts/Sidebar'
import styles from './Balance.module.css'

export default function Balance() {
    const baseUrl = "https://localhost:5001/api/AppointmentPayment/";
    const [data, setData] = useState([]);

    const checkBalanceConcluded = async () => {
        await axios.get(`${baseUrl}balance/concluded`).then(response => {
            setData(response.data.data);
        }).catch(error => {
            console.log(error);
        })
    };

    const checkBalancePending = async () => {
        await axios.get(`${baseUrl}balance/pending`).then(response => {
            setData(response.data.data);
        }).catch(error => {
            console.log(error);
        })
    };


    return (
        <>
            <Sidebar />
            <div className="container">
                <div className={styles.container}>
                    <h3>Consultar Saldo</h3>
                    <div className="col-md-6">
                        <label className="form-label">Escolha de acordo com o status do agendamento que deseja consultar:</label>
                        <br />
                    </div>
                    <Button
                        style={{ backgroundColor: '#00509d' }}
                        onClick={checkBalanceConcluded}>
                        <FaHourglassHalf size={22} weight="bold" />
                        <b className="p-1 me-1 mx-2">Pendentes</b>
                    </Button>
                    <span className={styles.space}></span>
                    <Button
                        style={{ backgroundColor: '#00509d' }}
                        onClick={checkBalancePending}>
                        <BsCheckCircleFill size={22} weight="bold" />
                        <b className="p-1 me-1 mx-2">Concluídos</b>
                    </Button>
                    <hr />
                    <div className={styles.table_responsive}>
                        <table className="table table-responsive table-borderless table-light table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">Valor Total</th>
                                    <th scope="col">Quantidade de Agendamentos</th>
                                </tr>
                            </thead>
                            <tbody>
                                    <tr>
                                        <td>R$ {data.sum}</td>
                                        <td>{data.number}</td>
                                    </tr>
                            </tbody>
                        </table>
                    </div>
                </div >
            </div>
        </>
    )
}