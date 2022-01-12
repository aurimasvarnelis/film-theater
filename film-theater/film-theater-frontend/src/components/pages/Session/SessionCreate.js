import React from 'react'
import { useForm } from "react-hook-form";
import { Modal, Button, Form} from 'react-bootstrap';
import { useState } from 'react';
import useAxios from 'axios-hooks'
import { useNavigate } from 'react-router-dom';

export const SessionCreate = ({token, theaterId, roomId, manualGet}) => {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const navigate = useNavigate();
    const { register, handleSubmit } = useForm();

    const [{response}, doPost] = useAxios(
        {
            method: `POST`,
            url: `http://localhost:5000/api/theaters/${theaterId}/rooms/${roomId}/sessions`,
            headers: {
                Authorization: `Bearer ${token}`,
            },
        },
        { manual: true }
    );
    
    const onSubmit = (data) => {
        doPost({
            data: {
                filmName: data.filmName,
                startTime: data.startTime,
                endTime: data.endTime,
            },
        });
        handleClose()
        //alert(`Theater ${data.name} has been added.`)
    };

    if (response) {
        //navigate(`/theaters/${theaterId}/rooms/${roomId}/sessions/${response.data.id}`);
        manualGet();
    }

    return (
        <>
            <Button variant="success" onClick={handleShow}>
                <div className="p-1 d-inline">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-square" viewBox="0 0 16 16">
                        <path d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1h12zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z"/>
                        <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"/>
                    </svg>
                </div>
                <div className="p-1 d-inline">
                    Create session
                </div>
            </Button>

            
            <Modal show={show} onHide={handleClose} centered>
                <Modal.Header closeButton>
                    <Modal.Title>Create session</Modal.Title>
                </Modal.Header>
                <Modal.Body> 
                    <Form id="hook-form" onSubmit={handleSubmit(onSubmit)}>               
                        <Form.Group className="mb-3" >
                            <Form.Label htmlFor="filmName">Film name</Form.Label>
                            <Form.Control required type="text" placeholder="Enter film name" {...register("filmName")}/>
                        </Form.Group>
                        <Form.Group className="mb-3" >
                            <Form.Label htmlFor="startTime">Start time</Form.Label>
                            <Form.Control required type="datetime-local" placeholder="Enter film start time" {...register("startTime")}/>
                        </Form.Group>
                        <Form.Group className="mb-3" >
                            <Form.Label htmlFor="endTime">End time</Form.Label>
                            <Form.Control required type="datetime-local" placeholder="Enter film end time" {...register("endTime")}/>
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Cancel
                    </Button>
                    <Button variant="primary" type="submit" form="hook-form">
                        Create
                    </Button>
                </Modal.Footer>
            </Modal>        
        </>   
    )
}
