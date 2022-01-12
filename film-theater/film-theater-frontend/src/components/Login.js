import React from 'react'
import { useState } from 'react';
import { Modal, Button, Form} from 'react-bootstrap';
import PropTypes from 'prop-types';


async function loginUser(credentials) {
    return fetch('http://localhost:5000/api/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(credentials)
    }).then(data => data.json())
}

export default function Login({setToken}) {
    const [show, setShow] = useState(false);
  
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [username, setUserName] = useState();
    const [password, setPassword] = useState();

    const handleSubmit = async e => {
        e.preventDefault();
        const token = await loginUser({
            username,
            password
        });
        setToken(token);
    }
  
    return (
        <>
            <Button className="mx-3" variant="dark" onClick={handleShow}>
                Login
            </Button>
    
            <Modal centered show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Login</Modal.Title>
                </Modal.Header>
                <Form onSubmit={handleSubmit}>
                    <Modal.Body>
                        <Form.Group className="mb-3" controlId="formBasicUsername">
                            <Form.Label>User name</Form.Label>
                            <Form.Control type="text" placeholder="Enter user name" onChange={e => setUserName(e.target.value)} />
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" placeholder="Password" onChange={e => setPassword(e.target.value)} />
                        </Form.Group>
                    </Modal.Body>
                    <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" type="submit" onClick={handleClose}>
                        Sign in
                    </Button>
                    </Modal.Footer>
                </Form>
            </Modal>
        </>
    );
}

Login.propTypes = {
    setToken: PropTypes.func.isRequired
}
