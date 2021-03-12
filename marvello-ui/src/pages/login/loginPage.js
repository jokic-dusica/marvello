import React,{useContext, useState} from 'react';
import useAuth from '../../hooks/useAuth';
import {useHistory} from 'react-router-dom';
import { Col, Container, Row } from 'react-bootstrap';
import loginModule from '../login/login.module.css';
import { AuthContext } from '../../store/auth/authContext';


const LoginPage = () => {
    const {signIn} = useAuth(); 
    const [state, dispatch] = useContext(AuthContext);
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
        if(response.isSuccess == true){
            history.push('/dashboard');
        }
   }
    return (
        <Container fluid>
            <Row>
                <Col md = {7} className = {loginModule.loginBckg}>

                </Col>
                <Col md = {5} className = {loginModule.loginForm}>
                    <div className = {loginModule.mainWrapperTitle}>
                        <h4 className = {loginModule.mainTitle}>Welcome to Marvello!</h4>
                    </div>
                    <div className = {loginModule.formWrapper}>
                        <div className = {loginModule.inputForm}>
                            <input type="text" name="username" placeholder = "username" onChange = {inputChangeHandler}/>
                        </div>
                        <div className = {loginModule.inputForm}>
                            <input type="password" name="password" placeholder = "password" onChange = {inputChangeHandler}/>
                        </div>
                        <a href = "#">
                            <p className = {loginModule.linkStyle}>Forgot your password?</p>
                        </a>
                        <p>{errorMessage}</p>
                        <div className = {loginModule.btnWrapper}>
                            <button onClick = {signInSubmit}>Sign in</button>
                        </div>
                    </div>                  
                </Col>
            </Row>          
        </Container>
           
    )

}

export default LoginPage;