import React, {useState, useEffect} from 'react';
import NavBar from '../../components/navbar/navbar';
import useProjectType from '../../hooks/useProjectType';
import AddProject from '../../components/addproject/addProject';
import { Col, Container, Row } from 'react-bootstrap';
import {Route} from "react-router-dom";
const Dashboard = () => {
    const[projectTypes, setProjectTypes] = useState();
    const {getProjectTypes,getOneProjectType} = useProjectType();
    return <>
    <Container fluid>
        <Row>
           <Col md={2}>
          
           </Col>
           <Col md={9}>
  
            </Col>           
        </Row>
    </Container>
 
    </>
}

export default Dashboard;