import { useState, useEffect } from "react";
import EstimateForm from "./EstimateForm";
import EstimateList from "./EstimateList";
import api from "../../../api/servicemanager";
import { Button, Modal } from "react-bootstrap";
import { UserPlus, CheckCircle, XCircle } from "phosphor-react";

export default function Estimate() {
    const [showEstimateModal, setShowEstimateModal] = useState(false);
    const [smshowConfirmModal, setSmshowConfirmModal] = useState(false);
    const [estimates, setEstimates] = useState([]);
    const [estimate, setEstimate] = useState({ id: 0 });

    const handleEstimateModal = () => setShowEstimateModal(!showEstimateModal);

    const handleConfirmModal = (id) => {
        if (id !== 0 && id !== undefined) {
            const estimate = estimates.filter((c) => c.id === id);
            setEstimate(estimate[0]);
        } else {
            setEstimate({ id: 0 });
        }
        setSmshowConfirmModal(!smshowConfirmModal);
    };

    const getEstimates = async () => {
        const response = await api.get("Estimate/read/all");
        return response.data;
    };

    const newEstimate = () => {
        setEstimate({ id: 0 });
        handleEstimateModal();
    };

    useEffect(() => {
        const catchEstimates = async () => {
            const all = await getEstimates();
            if (all) setEstimates(all);
        };
        catchEstimates();
    }, []);

    const addEstimate = async (c) => {
        handleEstimateModal();
        const response = await api.post("Estimate/create", c);
        setEstimates([...estimates, response.data]);
    };

    const deleteEstimate = async (id) => {
        handleConfirmModal(0);
        if (await api.delete(`Estimate/delete/${id}`)) {
            const estimatesFilter = estimates.filter((c) => c.id !== id);
            setEstimates([...estimatesFilter]);
        }
    };

    const cancelEstimate = () => {
        setEstimate({ id: 0 });
        handleEstimateModal();
    };

    const updateEstimate = async (c) => {
        handleEstimateModal();
        const response = await api.put("Estimate/update/", c);
        const { id } = response.data;
        setEstimates(estimates.map((item) => (item.id === id ? response.data : item)));
        setEstimate({ id: 0 });
    };

    const editEstimate = (id) => {
        const estimate = estimates.filter((c) => c.id === id);
        setEstimate(estimate[0]);
        handleEstimateModal();
    };

    return (
        <>
            <div>
                <h1>Todos os orçamentos</h1>
                <Button variant="primary" onClick={newEstimate}>
                    <UserPlus size={22} weight="bold" />
                </Button>
            </div>

            <EstimateList
                estimates={estimates}
                editEstimate={editEstimate}
                handleConfirmModal={handleConfirmModal}
            />

            <Modal size="lg" show={showEstimateModal} onHide={handleEstimateModal}>
                <Modal.Header closeButton>
                    <Modal.Title>Novo orçamento</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <EstimateForm
                        addEstimate={addEstimate}
                        cancelEstimate={cancelEstimate}
                        updateEstimate={updateEstimate}
                        estimateSelected={estimate}
                        estimates={estimates}
                    />
                </Modal.Body>
            </Modal>

            <Modal size="sm" show={smshowConfirmModal} onHide={handleConfirmModal}>
                <Modal.Header closeButton>
                    <Modal.Title>Excluir Orçamento</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    Tem certeza que deseja excluir o orçamento {estimate.name}?
                </Modal.Body>
                <Modal.Footer className="d-flex justify-content-between">
                    <button
                        className="btn btn-outline-success me-2"
                        onClick={() => deleteEstimate(estimate.id)}
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