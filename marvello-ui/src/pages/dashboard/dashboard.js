import React, {useState, useEffect} from 'react';
import NavBar from '../../components/navbar/navbar';
import useProjectType from '../../hooks/useProjectType';
import AddProject from '../../components/addproject/addProject';
import { Col, Container, Row } from 'react-bootstrap';
const Dashboard = () => {
    const[projectTypes, setProjectTypes] = useState();
    const {getProjectTypes,getOneProjectType} = useProjectType();
    return <>
    <Container fluid>
        <Row>
           <Col md={2}>
           <NavBar/>
           </Col>
           <Col md={9}><AddProject/></Col>           
        </Row>
    </Container>
 
    </>
}

export default Dashboard;