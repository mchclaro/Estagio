import { useState, useEffect } from "react";

const initialEstimate = {
  id: 0,
  descricao: '',
  servico: '',
  valor: '',
  datavalidade: '',
  cliente: ''
}


export default function EstimateForm(props) {
  const [estimate, setEstimate] = useState(estimateAtual());

  useEffect(() => {
    if (props.estSelecionado.id !== 0)
      setEstimate(props.estSelecionado);
  }, [props.estSelecionado]);

  const inputTextHandler = (e) => {
    const { name, value } = e.target;

    setEstimate({ ...estimate, [name]: value })
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (props.estSelecionado.id !== 0)
      props.updateEstimate(estimate)
    else
      props.addEstimate(estimate);

    setEstimate(initialEstimate);
  }

  const handleCancel = (e) => {
    e.preventDefault();
    props.cancelEstimate();

    setEstimate(initialEstimate);
  }

  function estimateAtual() {
    if (props.estSelecionado.id !== 0) {
      return props.estSelecionado;
    }
    else {
      return initialEstimate;
    }
  }

  return (
    <>
      <form className="row g-3" onSubmit={handleSubmit}>
        <div className="col-md-6">
          <label className="form-label">Descricao</label>
          <input
            name="descricao"
            id="descricao"
            type="text"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Serviço</label>
          <input
            name="service"
            id="service"
            onChange={inputTextHandler}
            type="text"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Valor</label>
          <input
            name="value"
            onChange={inputTextHandler}
            id="value"
            type="text"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Data de Validade</label>
          <input
            name="validateDate"
            onChange={inputTextHandler}
            id="validateDate"
            type="date"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Cliente</label>
          <input
            name="client"
            onChange={inputTextHandler}
            id="client"
            type="text"
            className="form-control"
          />
          <br />
        </div>
        <hr />
        <div className="col-12 mt-0">
          <button
            className="btn btn-outline-success position: relative"
            type='submit'
          >
            Salvar
          </button>
        </div>
      </form>
    </>
  )
}