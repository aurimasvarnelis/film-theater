import React from 'react'
import { useParams } from 'react-router';
import useAxios from 'axios-hooks'
import { Link } from 'react-router-dom'
import { Modal, Button, Form, Stack, Row, Col, Container} from 'react-bootstrap'
import { RoomGetAll } from '../Room/RoomGetAll'
import { useState } from 'react';
//import { RoomCreate } from '../Room/RoomCreate'
//import { RoomUpdate } from '../Room/RoomUpdate'
//import { RoomDelete } from '../Room/Delete';


export const SessionGet = ({token, theaterId, roomId, session}) => {
    const [show, setShow] = useState(false);
  
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [{ data, loading, error }] = useAxios(
        {
            method: `GET`,
            url: `http://localhost:5000/api/theaters/${theaterId}/rooms/${roomId}/sessions/${session.id}`,
            headers: {
                Authorization: `Bearer ${token}`,
            },
        },
        { useCache: false }
    );

    // const [{ data: room, loading: roomLoading, error: roomError }] = useAxios(
    //     {
    //         url: `http://localhost:5000/api/theaters/${id}/rooms/${id}`,
    //         headers: {
    //             Authorization: `Bearer ${token}`,
    //         },
    //     },
    //     { useCache: false }
    // );

    // const [{ data: session, loading: sessionLoading, error: sessionError }] = useAxios(
    //     {
    //         url: `http://localhost:5000/api/theaters/${id}/rooms/${id}/sessions/${id}`,
    //         headers: {
    //             Authorization: `Bearer ${token}`,
    //         },
    //     },
    //     { useCache: false }
    // );

    if (loading) {
        return <></>;
    }

    if (error) {
        return <p>ERROR</p>;
    }

    // if (roomError) {
    //     return <p>ERROR</p>;
    // }

    // if (sessionError) {
    //     return <p>ERROR</p>;
    // }

    return (
        <>     
            <Button variant="outline-info" className="me-2" onClick={handleShow}>
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" viewBox="0 0 16 16">
                    <path d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1h12zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z"/>
                    <path d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533L8.93 6.588zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0z"/>
                </svg>    
            </Button>
            
            <Modal show={show} onHide={handleClose} centered>
                <Modal.Header closeButton>
                    <Modal.Title>Session info</Modal.Title>
                </Modal.Header>
                <Modal.Body> 
                    <Form id="hook-form">               
                        <Form.Group className="mb-3" >
                            <Form.Label>Film name</Form.Label>
                            <Form.Control disabled type="text" defaultValue={session.filmName}/>
                        </Form.Group>
                        <Form.Group className="mb-3" >
                            <Form.Label>Start time</Form.Label>
                            <Form.Control disabled defaultValue={session.startTime} />
                        </Form.Group>
                        <Form.Group className="mb-3" >
                            <Form.Label>End time</Form.Label>
                            <Form.Control disabled defaultValue={session.endTime}/>
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal>
          
        </>
    )
}
