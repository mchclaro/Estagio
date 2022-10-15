import axios from 'axios';
import { PencilSimple, Plus, Trash } from 'phosphor-react'
import { useEffect, useState } from 'react';
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from 'react-bootstrap'
import Sidebar from '../../layouts/Sidebar'
import styles from './User.module.css'
import api from "../../../api/servicemanager";

export default function User() {

    const baseUrl = "https://localhost:5001/User/";
    const [data, setData] = useState([]);
    const [smshowConfirmModal, setSmshowConfirmModal] = useState(false);
    const [showUserModal, setShowUserModal] = useState(false);
    const handleUserModal = () => setShowUserModal(!showUserModal);
    const [user, setUser] = useState({ id: 0 });

    const [userSelected, setUserSelected] = useState({
        id: '',
        name: '',
        phone: '',
        email: '',
        photoUrl: '',
        role: ''
    });

    const newUser = () => {
        setUser({ id: 0 });
        handleUserModal();
    };

    const addUser = async () => {
        // userSelected.status=parseInt(userSelected.status);
        handleUserModal();
        const response = await axios.post(`${baseUrl}create`, userSelected)
        setData([...data, response.data.data]);
        console.log(data);
    };

    const editUser = (id) => {
        const cli = data.filter((c) => c.id === id);
        setUser(cli[0]);
        handleUserModal();
    };

    const cancelUser = () => {
        setUser({ id: 0 });
        handleUserModal();
    };

    const handleConfirmModal = (id) => {
        if (id !== 0 && id !== undefined) {
            const cli = data.filter((c) => c.id === id);
            setUser(cli[0]);
        } else {
            setUser({ id: 0 });
        }
        setSmshowConfirmModal(!smshowConfirmModal);
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUserSelected({
            ...userSelected,
            [name]: value
        });
    }

    const getUsers = async () => {
        await axios.get(`${baseUrl}read/all`).then(response => {
            setData(response.data.data);
            console.log(response.data.data.id);
        }).catch(error => {
            console.log(error);
        })
    };

    const getUserId = async () => {
        await axios.get(`${baseUrl}read/${data.id}`).then(response => {
            setData(response.data.data);
        }).catch(error => {
            console.log(error);
        })
    };

    const updateUser = async (c) => {
        handleUserModal();
        const response = await axios.put(`${baseUrl}update`, userSelected)
        const { id } = response.data;
        setData(data.map((item) => (item.id === id ? response.data : item)));
        setUser({ id: 0 });
    };

    const deleteUser = async (id) => {
        handleConfirmModal(0);
        if (await api.delete(`User/delete/${id}`)) {
            const clientsFilter = data.filter((c) => c.id !== id);
            setData([...clientsFilter]);
        }
    };

    useEffect(() => {
        getUsers();
    }, [])


    return (
        <>
            <Sidebar />
            <div className="container">
                <div className={styles.container}>
                    <h3>Perfil</h3>
                    <header>
                        <Button
                            className="mb-2"
                            onClick={newUser}
                            style={{ backgroundColor: '#00509d' }}>
                            <Plus size={22} weight="bold" />
                            <b className="p-1 me-1">Novo Usuário</b>
                        </Button>
                    </header>
                    <div className={styles.table_responsive_profile}>
                        <table className="table table-responsive table-hover">
                            <thead>
                                <tr>
                                    <th scope="col">Id</th>
                                    <th scope="col">Nome</th>
                                    <th scope="col">Telefone</th>
                                    <th scope="col">Email</th>
                                    <th scope="col">Perfil</th>
                                </tr>
                            </thead>
                            <tbody>
                                {data.map(u =>
                                    <tr key={u.id}>
                                        <td>{u.id}</td>
                                        <td>{u.name}</td>
                                        <td>{u.phone}</td>
                                        <td>{u.email}</td>
                                        <td>{u.role}</td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </div >

                    <div className={styles.table_responsive}>
                        <table className="table table-responsive table-borderless table-light table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">Id</th>
                                    <th scope="col">Nome</th>
                                    <th scope="col">Telefone</th>
                                    <th scope="col">Email</th>
                                    <th scope="col">Perfil</th>
                                    <th scope="col">Ações</th>
                                </tr>
                            </thead>
                            <tbody>
                                {data.map(u =>
                                    <tr key={u.id}>
                                        <td>{u.id}</td>
                                        <td>{u.name}</td>
                                        <td>{u.phone}</td>
                                        <td>{u.email}</td>
                                        <td>{u.role}</td>
                                        <td>
                                            <button
                                                className="btn  btn-sm btn-outline-primary me-2"
                                                onClick={() => editUser(u.id)}
                                            >
                                                <PencilSimple size={18} weight="bold" />
                                            </button>
                                            <button
                                                className="btn  btn-sm btn-outline-danger me-2"
                                                onClick={() => deleteUser(u.id)}
                                            >
                                                <Trash size={18} weight="bold" />
                                            </button>
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </div >

                    <Modal size="lg" show={showUserModal} onHide={handleUserModal}>
                        <ModalHeader> Adicionar Usuário </ModalHeader>
                        <ModalBody>
                            <div className="col-md-6">
                                <label className="form-label">Nome</label>
                                <input
                                    name="name"
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
                                    onChange={handleChange}
                                    id="phone"
                                    type="text"
                                    className="form-control"
                                />
                            </div>

                            <div className="col-md-6">
                                <label className="form-label">Email</label>
                                <input
                                    name="email"
                                    onChange={handleChange}
                                    id="email"
                                    type="text"
                                    className="form-control"
                                />
                            </div>

                            <div className="col-md-6">
                                <label className="form-label">Senha</label>
                                <input
                                    name="password"
                                    onChange={handleChange}
                                    id="password"
                                    type="password"
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

                            <div className="col-md-6">
                                <label className="form-label">Perfil</label>
                                <select
                                    name="role"
                                    onChange={handleChange}
                                    id="role"
                                    type="text"
                                    className="form-select"
                                >
                                    <option defaultValue="Não definido">Selecionar</option>
                                    <option value="1">Admin</option>
                                    <option value="2">Funcionário</option>
                                </select>
                                <br />
                            </div>
                        </ModalBody>

                        <ModalFooter>
                            <div className="col-12 mt-0">
                                <button
                                    className="btn btn-outline-success position: relative me-2"
                                    type='submit'
                                    onClick={() => addUser()}
                                >
                                    Salvar
                                </button>
                                <button
                                    className="btn btn-outline-danger position: relative me-2"
                                    onClick={cancelUser}
                                >
                                    Cancelar
                                </button>
                            </div>
                        </ModalFooter>
                    </Modal>
                </div >
            </div>
        </>
    )
}