import React,{useContext, useState} from 'react';
import useAuth from '../../hooks/useAuth';
import {useHistory,Redirect} from 'react-router-dom';
import { Col, Container, Row } from 'react-bootstrap';
import loginModule from '../login/login.module.css';
import {observer} from 'mobx-react';
import {StoreContext} from '../../store/storeProvider';
import AuthStore from '../../store/auth/authStore';


const LoginPage = (props) => {
    // const {signIn,isSuccess, message} = useAuth(); 
    let history = useHistory();
    const auth = new AuthStore();
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
        await auth.signIn(loginData);
        setErrorMessage(auth.message);
        if(auth.isSuccess){
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
                    {auth.message}                  
                </Col>
            </Row>          
        </Container>
           
    )

}

export default observer(LoginPage);