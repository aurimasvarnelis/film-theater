import React, { Component } from 'react';
import { Image, Container } from 'react-bootstrap';
import theaterCover from "../../images/theater_cover.jpg"
class Home extends React.Component {
    render() { 
        return(
            //<Container style={{ height: "9000" }}>
            <div>
                <Image className="theater-cover" src={theaterCover} />
            </div>
                
            //</Container>
        );
    }
}
 
export default Home;