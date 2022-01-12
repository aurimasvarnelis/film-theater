import React from 'react'
import { useParams } from 'react-router';
import useAxios from 'axios-hooks'
import { Link } from 'react-router-dom'
import { Modal, Button, Form, Stack, Row, Col, Container} from 'react-bootstrap'
import { SessionGetAll } from '../Session/SessionGetAll'

export const RoomGet = ({token}) => {
    const { theaterId, id } = useParams();

    const [{ data: theater, loading: theaterLoading, error: theaterError }] = useAxios(
        {
            method: `GET`,
            url: `http://localhost:5000/api/theaters/${theaterId}`,
            headers: {
                Authorization: `Bearer ${token}`,
            },
        },
        { useCache: false }
    );

    const [{ data: room, loading: roomLoading, error: roomError }] = useAxios(
        {
            method: `GET`,
            url: `http://localhost:5000/api/theaters/${theaterId}/rooms/${id}`,
            headers: {
                Authorization: `Bearer ${token}`,
            },
        },
        { useCache: false }
    );

   
    if (theaterLoading) {
        return <></>;
    }

    if (theaterError) {
        return <p>ERROR</p>;
    }

    if (roomLoading) {
        return <></>;
    }

    if (roomError) {
        return <p>ERROR</p>;
    }

    return (
        <Container className="d-flex flex-column min-vh-100 my-3 px-3 py-2">     
            <Row >
                <Col><h1>Theater - {theater.name}</h1></Col>
            </Row> 
            <hr/>
            <Row>
                <Col><h1>Room  - {room.name}</h1></Col>
            </Row> 
            <hr/>
            <SessionGetAll token={token} theaterId={theaterId} roomId={room.id} /> 

                        
        </Container>
    )
}
