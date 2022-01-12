import React from 'react'
import useAxios from 'axios-hooks'
import { useState } from 'react';
import { Link } from 'react-router-dom'
import { Modal, Button, Form, Stack, Row, Col, Container, Table, Alert, Toast} from 'react-bootstrap';
import '../../../App.css';
import { RoomCreate } from './RoomCreate'
import { RoomUpdate } from './RoomUpdate'
import { RoomDelete } from './RoomDelete';

export const RoomGetAll = ({token, theaterId}) => {
    const [show, setShow] = useState(true);
    //const {id} = useParams();
    
    const [{ data, loading, error }, manualGet] = useAxios(
        {
            method: `GET`,
            url: `http://localhost:5000/api/theaters/${theaterId}/rooms`,
            headers: {
                Authorization: `Bearer ${token}`,
            },
        },
        { useCache: false }
    );

    if (loading) {
        return <></>;
    }

    if (error) {
        return <p>ERROR</p>;
    }

    return (
        <>
            <Row>
                <Col><h1>Rooms</h1></Col>
                <Col md="auto"><RoomCreate token={token} theaterId={theaterId}/></Col>
            </Row> 
            <hr/>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Capacity</th>
                        <th>Room type</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                {         
                    data.map((room) => (
                        <tr key={room.id}>
                            <td>   
                                {room.name}                                     
                            </td>
                            <td>
                                {room.capacity}
                            </td>
                            <td>
                                {room.roomType}
                            </td>
                            <td style={{width:'1px',whiteSpace:'nowrap'}}>                                   
                                <Link to={`rooms/${room.id}`} >
                                    <Button variant="outline-info" className="me-2">                   
                                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" viewBox="0 0 16 16">
                                            <path d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1h12zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z"/>
                                            <path d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533L8.93 6.588zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0z"/>
                                        </svg>                                   
                                    </Button>
                                </Link>

                                <RoomUpdate token={token} theaterId={theaterId} room={room} manualGet={manualGet} />
                                    
                                <RoomDelete token={token} theaterId={theaterId} id={room.id} manualGet={manualGet} />
                            </td>
                        </tr>             
                    ))
                }
                </tbody>
            </Table>

            
        </>
    )
}
