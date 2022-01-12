import React from 'react'
import { useState } from 'react';
import { Modal, Button, Form} from 'react-bootstrap';
import { useNavigate } from "react-router";

export default function Logout ({removeToken}) {
    const [show, setShow] = useState(false);

    const navigate = useNavigate();

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    
    const handleLogout = () => {
        handleClose();
        localStorage.clear();
        navigate("/");
        //window.location.reload();
        //window.location.reload(false);
    };

    return (
        <>
            <Button variant="dark" onClick={handleShow}>
                Logout
            </Button>
    
            <Modal centered show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Confirm</Modal.Title>
                </Modal.Header>
                    <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={handleLogout}>
                        Logout
                    </Button>
                    </Modal.Footer>
            </Modal>
        </>
    )   
}

//Logout.propTypes = {
//    removeToken: PropTypes.func.isRequired
//}
