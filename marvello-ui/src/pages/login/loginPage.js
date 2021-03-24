import React,{useContext, useEffect, useState} from 'react';
import useAuth from '../../hooks/useAuth';
import {useHistory,Redirect,Link} from 'react-router-dom';
import { Col, Container, Row } from 'react-bootstrap';
import loginModule from '../login/login.module.css';
import {observer, inject} from 'mobx-react';
import {StoreContext} from '../../store/storeProvider';
import AuthStore from '../../store/auth/authStore';
import Loader from '../../components/loader/loader';
import CommonStore from '../../store/common/commonStore';
import useStores from '../../hooks/useStores';


const LoginPage = () => {
    let history = useHistory();
    const authStore = new AuthStore();
    // const {signIn, isSuccess, message} = useAuth();
    // const {authStore:{signIn, isSuccess, message}} = useStores();
    const commonStore = new CommonStore();
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
        commonStore.changeApiState(true);
        await authStore.signIn(loginData);
        commonStore.changeApiState(false);
        setErrorMessage(authStore.message);
        if(authStore.isSuccess){
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
                        <Link to={"/register"}>
                            <p className = {loginModule.linkStyle}>You're not a part of Marvello Family yet?<br></br> Click here to register and become an one.</p>
                        </Link>
                        <p>{errorMessage}</p>
                        <div className = {loginModule.btnWrapper}>
                            <button onClick = {signInSubmit}>Sign in</button>
                        </div>
                    </div>
                    {authStore.message}                  
                </Col>
            </Row>          
        </Container>
           
    )

}

export default LoginPage;