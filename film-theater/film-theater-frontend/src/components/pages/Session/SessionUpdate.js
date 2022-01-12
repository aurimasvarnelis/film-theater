import React from 'react'
import { useForm } from "react-hook-form";
import { Modal, Button, Form} from 'react-bootstrap';
import { useState } from 'react';
import useAxios from 'axios-hooks'

export const SessionUpdate = ({token, theaterId, roomId, session, manualGet}) => {
    const [show, setShow] = useState(false);
  
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const { register, handleSubmit, setValue } = useForm()

    const [{ data, loading, error, response}, doPut] = useAxios(
        {
            method: `PUT`,
            url: `http://localhost:5000/api/theaters/${theaterId}/rooms/${roomId}/sessions/${session.id}`,
            headers: {
                Authorization: `Bearer ${token}`,
            },
        },
        { manual: true }
    );
    
    const onSubmit = (data) => {
        doPut({
            data: {
                filmName: data.filmName,
                startTime: data.startTime,
                endTime: data.endTime,
            },
        });
        handleClose();
       // alert(`Theater ${data.name} has been updated.`)
    };
    if(session)
    {
        setValue("startTime", session.startTime);
        setValue("endTime", session.startTime);
    }

    if (loading) {
        return <></>;
      }

    if (response) {
        manualGet();
    }

    return (
        <>
            <Button variant="outline-warning" className="me-2" onClick={handleShow}>
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" viewBox="0 0 16 16">
                    <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                    <path d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                </svg>
            </Button>
            
            <Modal show={show} onHide={handleClose} centered>
                <Modal.Header closeButton>
                    <Modal.Title>Edit session</Modal.Title>
                </Modal.Header>
                <Modal.Body> 
                    <Form id="hook-form" onSubmit={handleSubmit(onSubmit)}>               
                        <Form.Group className="mb-3" >
                            <Form.Label>Film name</Form.Label>
                            <Form.Control required type="text" placeholder="Enter film name" defaultValue={session.filmName} {...register("filmName", { required: true })}/>
                        </Form.Group>
                        <Form.Group className="mb-3" >
                            <Form.Label>Start time</Form.Label>
                            <Form.Control required type="datetime-local" placeholder="Enter film start time" {...register("startTime")}/>
                        </Form.Group>
                        <Form.Group className="mb-3" >
                            <Form.Label>End time</Form.Label>
                            <Form.Control required type="datetime-local" placeholder="Enter film end time"  {...register("endTime")}/>
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Cancel
                    </Button>
                    <Button variant="primary" type="submit" form="hook-form">
                        Update
                    </Button>
                </Modal.Footer>
            </Modal>
        </>   
    )
}
