import { Button } from 'react-bootstrap'
import { BsSearch } from 'react-icons/bs'
import Sidebar from '../../layouts/Sidebar'
import styles from './Balance.module.css'

export default function Balance() {
    return (
        <>
            <Sidebar />
            <div className="container">
                <div className={styles.container}>
                    <h3>Consultar Saldo</h3>
                    <div className="col-md-6">
                        <label className="form-label">Selecione o status do agendamento:</label>
                        <select
                            name="status"
                            id="status"
                            type="text"
                            className="form-select"
                        >
                            <option defaultValue="Não definido">Selecionar</option>
                            <option value="2">Pendente</option>
                            <option value="3">Concluído</option>
                        </select>
                        <br />
                    </div>
                    <Button
                        style={{ backgroundColor: '#00509d' }}>
                        <BsSearch size={22} weight="bold" />
                        <b className="p-1 me-1">Consultar Saldo</b>
                    </Button>
                    <hr />
                    <div className={styles.table_responsive}>
                        <table className="table table-responsive table-borderless table-light table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">Valor Total</th>
                                    <th scope="col">Quantidade de Agendamento</th>
                                </tr>
                            </thead>
                            <tbody>
                                {/* {data.map(b =>
                        <tr key={b.id}>
                            <td>{b.name}</td>
                            <td>{b.phone}</td>
                        </tr>
                    )} */}
                                <tr>
                                    <td>R$ 1850,00</td>
                                    <td>52 Agendamentos</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div >
            </div>
        </>
    )
}