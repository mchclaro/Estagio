import axios from 'axios';
import { useState } from 'react';
import { Button } from 'react-bootstrap'
import { FaCalendar, FaCalendarDay, FaCalendarWeek } from 'react-icons/fa'
import Sidebar from '../../layouts/Sidebar'
import styles from './Report.module.css'

export default function Report() {
    const baseUrl = "https://localhost:5001/api/Appointment/";
    const [data, setData] = useState([]);

    const reportDaily = async () => {
        await axios.get(`${baseUrl}report/daily`).then(response => {
            setData(response.data.data);
        }).catch(error => {
            console.log(error);
        })
    };

    const reportWeekly = async () => {
        await axios.get(`${baseUrl}report/weekly`).then(response => {
            setData(response.data.data);
        }).catch(error => {
            console.log(error);
        })
    };

    const reportMonth = async () => {
        await axios.get(`${baseUrl}report/month`).then(response => {
            setData(response.data.data);
        }).catch(error => {
            console.log(error);
        })
    };

    return (
        <>
            <Sidebar />
            <div className="container">
                <h3>Gerar Relatórios</h3>
                <div className="col-md-6">
                    <label className="form-label">Escolha o tipo do relatório que deseja consultar:</label>
                    <br />
                </div>
                <Button
                    style={{ backgroundColor: '#00509d' }}
                    onClick={reportDaily}>
                    <FaCalendarDay size={22} weight="bold" />
                    <b className="p-1 me-1 mx-2">Diário</b>
                </Button>
                <span className={styles.space}></span>
                <Button
                    style={{ backgroundColor: '#00509d' }}
                    onClick={reportWeekly}>
                    <FaCalendarWeek size={22} weight="bold" />
                    <b className="p-1 me-1 mx-2">Semanal</b>
                </Button>
                <span className={styles.space}></span>
                <Button
                    style={{ backgroundColor: '#00509d' }}
                    onClick={reportMonth}>
                    <FaCalendar size={22} weight="bold" />
                    <b className="p-1 me-1 mx-2">Mensal</b>
                </Button>
                <hr />
                <div className={styles.container}>
                    {data.map(re =>
                        <div className="card mb-2 shadow-sm border-dark" >
                            <div className="card-body">
                                <div className="card-text">
                                    <div>
                                        <h6>Agendamento</h6>
                                    </div>
                                    <p>
                                        <strong>Id: </strong>{re.id} |
                                        <strong> Descrição: </strong>{re.description} |
                                        <strong> Data Realizada: </strong>{re.dataHeld} |
                                        <strong> Status: </strong>{re.status == '1' ? 'Cancelado' : re.status == '2' ? 'Pendente' : 'Concluído'}
                                    </p>
                                    <div>
                                        <h6>Orçamento</h6>
                                    </div>
                                    <p>
                                        <strong>Id: </strong>{re.estimate.id} |
                                        <strong> Serviço: </strong>{re.estimate.service} |
                                        <strong> Descrição: </strong>{re.estimate.description} |
                                        <strong> Valor: R$ </strong>{re.estimate.value} |
                                        <strong> Data de Validade: </strong>{re.estimate.validateDate}
                                    </p>
                                    <div>
                                        <h6>Cliente</h6>
                                    </div>
                                    <p>
                                        <strong>Nome: </strong>{re.client.name} |
                                        <strong> Telefone: </strong>{re.client.phone}
                                    </p>
                                    <div>
                                        <h6>Pagamento</h6>
                                    </div>
                                    <p>
                                        <strong>É Sinal?: </strong> {re.appointmentPayments.map(x => x.isSignal == '1' ? 'Sinal' : 'Total')} |
                                        <strong> Data do Pagamento: </strong> {re.appointmentPayments.map(x => x.datePayment)} |
                                        <strong> Valor: R$ </strong> {re.appointmentPayments.map(x => x.value)} |
                                        <strong> Status do Pagamento: </strong> {re.appointmentPayments.map(x => x.paymentStatus == '1' ? 'Pendente' : 'Pago')} |
                                        <strong> Tipo do Pagamento: </strong> {re.appointmentPayments.map(x => x.paymentMethodName)}
                                    </p>
                                </div>
                            </div>
                        </div>
                    )}
                </div>
            </div>
        </>
    )
}