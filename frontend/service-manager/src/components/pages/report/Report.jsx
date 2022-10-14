import { Button } from 'react-bootstrap'
import { BsFileEarmarkArrowDownFill } from 'react-icons/bs'

export default function Report() {
    return (
        <div className="container">
            <h3>Gerar Relatórios</h3>
            <div className="col-md-6">
                <label className="form-label">Selecione o tipo do relatório:</label>
                <select
                    name="status"
                    id="status"
                    type="text"
                    className="form-select"
                >
                    <option defaultValue="Não definido">Selecionar</option>
                    <option value="1">Diário</option>
                    <option value="2">Semanal</option>
                    <option value="3">Mensal</option>
                </select>
                <br />
            </div>
            <Button
                style={{ backgroundColor: '#00509d' }}>
                <BsFileEarmarkArrowDownFill size={22} weight="bold" />
                <b className="p-1 me-1">Gerar Relatório</b>
            </Button>
            <hr />
        </div >
    )
}