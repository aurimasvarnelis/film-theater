import React from 'react'
import { useParams } from 'react-router';
import useAxios from 'axios-hooks'
import { Link } from 'react-router-dom'
import { Modal, Button, Form, Stack, Row, Col, Container} from 'react-bootstrap'
import { RoomGetAll } from '../Room/RoomGetAll'



export const TheaterGet = ({token}) => {
    const {id} = useParams();

    const [{ data, loading, error }] = useAxios(
        {
            method: `GET`,
            url: `http://localhost:5000/api/theaters/${id}`,
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
        <Container className="d-flex flex-column min-vh-100 my-3 px-3 py-2">     
            <Row >
                <Col><h1>Theater - {data.name}</h1></Col>
            </Row> 
            <hr/>
            <RoomGetAll token={token} theaterId={id}/>                
        </Container>
    )
}
