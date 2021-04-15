import React from 'react';
import { Container, Col} from 'react-bootstrap';
import NavBar from '../navbar/navbar';
import { BrowserRouter as Router, Switch, Route,Link, Redirect} from "react-router-dom";
import AddProject from '../addproject/addProject';
import Dashboard from '../../pages/dashboard/dashboard';

const PrivateRoutes = ({authStore}) => {
    return (<>
        <Container fluid>
            <Col md={2}>
                <NavBar/>
            </Col>
            <Col md={10}>
                <Route exact path = "/dashboard" component = {Dashboard}/>
                <Route path="/add-project" component = {AddProject}/>  
            </Col>
        </Container>
    </>)
}

export default PrivateRoutes;