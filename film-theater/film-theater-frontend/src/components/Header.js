import React from 'react'
import Logo from '../images/logo.png'
import { Navbar, Container, Nav } from 'react-bootstrap'
import { useState } from 'react';
import { Modal, Button, Form} from 'react-bootstrap';
import Login from './Login'
import Register from './Register'
import Logout from './Logout'
import useToken from './useToken';
import { Link } from 'react-router-dom'

const Header = (props) => {

    if(props.loggedIn)
    {
        return (
            <Navbar className="navbar-custom" expand="lg">
                <Container>
                    <Navbar.Brand>
                        <img
                            src={Logo}
                            width="80"
                            height="80"
                            alt="filmTheaterLogo"
                        />
                    </Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="nav-custom topBotomBordersOut me-auto">
                        <Link className="nav-link" to="/">Home</Link> 
                        <Link className="nav-link" to="theaters">Theaters</Link>         
                    </Nav>
                    <Nav>
                        <Nav>
                            <Logout removeToken={props.removeToken} token={props.token}/>
                        </Nav>
                    </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
        )
    }
    
    return (
        <Navbar className="navbar-custom" expand="lg">
            <Container className="header">
                <Navbar.Brand>
                    <img
                        src={Logo}
                        width="80"
                        height="80"
                        alt="filmTheaterLogo"
                    />
                </Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                <Nav className="me-auto">
                    <Nav.Link>Home</Nav.Link>           
                </Nav>
                <Nav>
                    <Nav>
                        <Login setToken={props.setToken} />
                    </Nav>
                    <Nav>
                        <Register />
                    </Nav>             
                </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    )
    
    
}

export default Header
