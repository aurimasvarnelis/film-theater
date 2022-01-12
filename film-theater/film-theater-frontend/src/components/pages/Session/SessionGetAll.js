import React from 'react'
import useAxios from 'axios-hooks'
import { useState } from 'react';
import { Modal, Button, Form, Stack, Row, Col, Container, Table, Alert, Toast} from 'react-bootstrap';
import { SessionCreate } from './SessionCreate'
import { SessionDelete } from './SessionDelete';
import { SessionUpdate } from './SessionUpdate';
import { SessionGet } from './SessionGet';
import '../../../App.css';

export const SessionGetAll = ({token, theaterId, roomId}) => {
    const [show, setShow] = useState(true);
    
    const [{ data, loading, error }, manualGet] = useAxios(
        {
            method: `GET`,
            url: `http://localhost:5000/api/theaters/${theaterId}/rooms/${roomId}/sessions`,
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
                <Col><h1>Sessions</h1></Col>
                <Col md="auto"><SessionCreate token={token} theaterId={theaterId} roomId={roomId} manualGet={manualGet}/></Col>
            </Row> 
       
            <hr/>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th colSpan="4">Film name</th>
                        <th colSpan="4">Start time</th>
                        <th colSpan="4">End time</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                {         
                    data.map((session) => (
                        <tr key={session.id}>
                            <td colSpan="4">   
                                {session.filmName}                                     
                            </td>
                            <td colSpan="4">
                                {session.startTime}
                            </td>
                            <td colSpan="4">
                                {session.endTime}
                            </td>
    
                            <td style={{width:'1px',whiteSpace:'nowrap'}}>                                   
                                <SessionGet token={token} theaterId={theaterId} roomId={roomId} session={session} />
                                <SessionUpdate token={token} theaterId={theaterId} roomId={roomId} session={session} manualGet={manualGet} />           
                                <SessionDelete token={token} theaterId={theaterId} roomId={roomId} id={session.id} manualGet={manualGet} />
                            </td>
                        </tr>             
                    ))
                }
                </tbody>
            </Table>

            
        </>
    )
}
