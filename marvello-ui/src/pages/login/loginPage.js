import React,{useState} from 'react';
import useAuth from '../../hooks/useAuth';
import {useHistory} from 'react-router-dom';
import { Col, Container, Row } from 'react-bootstrap';
import loginModule from '../login/login.module.css';


const LoginPage = () => {
    const {signIn} = useAuth();
    let history = useHistory();
    const[loginData, setLoginData] = useState(
    {
        username:"",
        password:""
   })
   const[errorMessage, setErrorMessage] = useState("");
   const inputChangeHandler = (e) => {
        setLoginData({...loginData,[e.target.name]:e.target.value})
   }
   const signInSubmit = async () => {
        var response = await signIn(loginData);
        if(response.isSuccess) {
            history.push("/dashboard");
        }
        else {
            setErrorMessage(response.message);
        }
   }
    return (
        <Container fluid>
            <Row>
                <Col md = {5} className = {loginModule.loginBckg}>

                </Col>
                <Col md = {7}>
                    <div className = {loginModule.formWrapper}>
                        <h3>Welcome to Marvello! Please Sign in</h3>
                        <div>
                            <input type="text" name="username" placeholder = "Username" onChange = {inputChangeHandler}/>
                        </div>
                        <div>
                            <input type="password" name="password" placeholder = "Password" onChange = {inputChangeHandler}/>
                        </div>
                        <p>{errorMessage}</p>
                        <button onClick = {signInSubmit}>Sign in</button>
                    </div>                  
                </Col>
            </Row>          
        </Container>
           
    )

}

export default LoginPage;