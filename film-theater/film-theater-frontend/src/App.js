import './App.css';
import React from 'react';
import Header from './components/Header';
import Footer from './components/Footer';
import {
	BrowserRouter,
	Routes,
	Route
} from "react-router-dom";
import Home from './components/pages/Home';
import useToken from './components/useToken';
import { TheaterGetAll } from './components/pages/Theater/TheaterGetAll';
import { TheaterGet } from './components/pages/Theater/TheaterGet';
import { RoomGetAll } from './components/pages/Room/RoomGetAll';
import { RoomGet } from './components/pages/Room/RoomGet';
import { SessionGetAll } from './components/pages/Session/SessionGetAll';
import { SessionGet } from './components/pages/Session/SessionGet';


function App() {
	const { token, setToken, getToken, removeToken } = useToken();

	const loggedIn = token ? true : false;
	const userToken = getToken();

	if(!token) {
		return (
			<>
				<BrowserRouter>
					<Header loggedIn={loggedIn} setToken={setToken} removeToken={removeToken} token={userToken}/>
					<Routes>
						<Route path="/" element={<Home />} />
					</Routes>
					<Footer />
				</BrowserRouter>
			</> 
		);

	}

	if(token) {
		return (
			<>
				<BrowserRouter>
					<Header loggedIn={loggedIn}/>
					<Routes>		
						<Route path="/" element={<Home />} />

						{/* Theater */}
						<Route path="/theaters" element={<TheaterGetAll token={userToken}/>} />
						<Route path="/theaters/:id" element={<TheaterGet token={userToken}/>} />

						{/* Room */}
						<Route path="/theaters/:theaterId/rooms" element={<RoomGetAll token={userToken}/>} />
						<Route path="/theaters/:theaterId/rooms/:id" element={<RoomGet token={userToken}/>} />
						
						{/* Session */}
						<Route path="/theaters/:theaterId/rooms/:roomId/sessions" element={<SessionGetAll token={userToken}/>} />
						<Route path="/theaters/:theaterId/rooms/:roomId/sessions/:id" element={<SessionGet token={userToken}/>} />
						
					</Routes>
					<Footer />
				</BrowserRouter>
			</> 
		);
	}

	
}

export default App;
