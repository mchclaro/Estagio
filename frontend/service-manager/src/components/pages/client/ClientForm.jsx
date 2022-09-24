import { useEffect, useState } from 'react'

const initialClient = {
  id: 0,
  name: '',
  phone: '',
  photoUrl: '',
  addressStreet: '',
  addressStreetNumber: '',
  addressDistrict: '',
  addressComplement: '',
  zipcode: '',
  addressState: '',
  addressCity: ''
}

export default function ClientForm(props) {
  const [client, setClient] = useState(currentClient());


  useEffect(() => {
    if (props.clientSelected.id !== 0)
      setClient(props.clientSelected);
  }, [props.clientSelected]);

  const inputTextHandler = (e) => {
    const { name, value } = e.target;

    setClient({ ...client, [name]: value })
  }

  function currentClient() {
    if (props.clientSelected.id !== 0) {
      return props.clientSelected;
    }
    else {
      return initialClient;
    }
  }

  const handleSubmit = (e) => {
    e.preventDefault();

    if (props.clientSelected.id !== 0)
      props.updateClient(client)
    else
      props.addClient(client);

    setClient(initialClient);
  }

  const handleCancel = (e) => {
    e.preventDefault();
    props.cancelClient();

    setClient(initialClient);
  }

  return (
    <>
      <form className='row g-3' onSubmit={handleSubmit}>
        <div className="col-md-6">
          <label className="form-label">Nome</label>
          <input
            name="name"
            value={client.name}
            onChange={inputTextHandler}
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
            onChange={inputTextHandler}
            id="phone"
            type="text"
            className="form-control"
          />
        </div>

        <div className="col-md-10">
          <label className="form-label">Foto</label>
          <input
            name="photoUrl"
            value={client.photoUrl}
            onChange={inputTextHandler}
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
            value={client.addressStreet}
            onChange={inputTextHandler}
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
            value={client.addressStreetNumber}
            onChange={inputTextHandler}
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
            value={client.addressDistrict}
            onChange={inputTextHandler}
            id="addressDistrict"
            type="text"
            className="form-control"
          />
          <br />
        </div>

        <div className="col-md-6">
          <label className="form-label">Complemento</label>
          <input
            name="addressComplement"
            value={client.addressComplement}
            onChange={inputTextHandler}
            id="addressComplement"
            type="text"
            className="form-control"
          />
          <br />
        </div>

        <div className="col-md-6">
          <label className="form-label">CEP</label>
          <input
            name="zipcode"
            value={client.zipcode}
            onChange={inputTextHandler}
            id="zipcode"
            type="text"
            className="form-control"
          />
          <br />
        </div>

        <div className="col-md-6">
          <label className="form-label">Estado</label>
          <input
            name="addressState"
            value={client.addressState}
            onChange={inputTextHandler}
            id="addressState"
            type="text"
            className="form-control"
          />
          <br />
        </div>

        <div className="col-md-6">
          <label className="form-label">Cidade</label>
          <input
            name="addressCity"
            value={client.addressCity}
            onChange={inputTextHandler}
            id="addressCity"
            type="text"
            className="form-control"
          />
          <br />
        </div>

        <div className="col-12 mt-0">
          {
            client.id === 0 ?
              <button
                className="btn btn-outline-success position: relative"
                type='submit'
              >
                Salvar
              </button>
              :
              <>
                <button
                  className="btn btn-outline-success position: relative me-2"
                  type='submit'
                >
                  Salvar
                </button>
                <button
                  className="btn btn-outline-warning position: relative me-2"
                  onClick={handleCancel}
                >
                  Cancelar
                </button>
              </>
          }
        </div>

      </form>
    </>
  )
}
