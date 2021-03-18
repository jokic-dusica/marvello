import React, { useState } from 'react';
import useAuth from '../../hooks/useAuth';
import {useHistory} from 'react-router-dom';
import { Col, Container, Row } from 'react-bootstrap';
import registerStyle from '../register/register.module.css';
import AuthStore from '../../store/auth/authStore';
import UserStore from '../../store/user/userStore';

const RegisterPage = () => {
    const authStore = new AuthStore();
    const userStore = new UserStore();
    let history = useHistory();
    const[newUser, setNewUser] = useState(
        {
            name:"",
            email:"",
            username:"",
            password:""
        }
    )
    const [errorMessage, setErrorMessage] = useState("");
    const [repeatedPassword, setRepeatedPassword] = useState("");
    const [isFormInvalid, setIsFormInvalid] = useState(false);
    const inputChangeHandler = (e) => {
        setNewUser({...newUser,[e.target.name]:e.target.value});
    }
    const repeatedPasswordHandler = (e) => {
        setRepeatedPassword(e.target.value);
        if(newUser.password != e.target.value) {
            setIsFormInvalid(true);
        }
        else {
            setIsFormInvalid(false)
        }
    }
    const registerFormSubmit = async () => {
        authStore.signUp(newUser);
        if(authStore.isSuccess) {
            history.push("/");
        }
        else {
            setErrorMessage(authStore.message);
        }

    }
    return (
    <Container fluid>
        <Row>
            <Col md={7} className = {registerStyle.mainBanner}></Col>
            <Col md={5}>
                <div className = {registerStyle.mainWrapperTitle}>
                    <h4 className = {registerStyle.mainTitle}>Create Your Marvello Account</h4>
                </div>
                <div className = {registerStyle.formWrapper}>
                    <div className = {registerStyle.inputForm}>
                        <input type="text" name="name" onChange = {inputChangeHandler} placeholder = "name"/>
                    </div>
                    <div className = {registerStyle.inputForm}>
                        <input type="text" name="email" onChange = {inputChangeHandler} placeholder = "email"/>
                    </div>
                    <div className = {registerStyle.inputForm}>
                        <input type="text" name="username" onChange = {inputChangeHandler} placeholder = "username"/>
                    </div>
                    <div className = {registerStyle.inputForm}>
                        <input type="password" name="password" onChange = {inputChangeHandler} placeholder = "password"/>
                    </div>
                    <div className = {registerStyle.inputForm}>
                        <input type="password" name="confirmPassword" onChange = {repeatedPasswordHandler} placeholder = "confirm password"/>
                    </div>
                    <p>{errorMessage}</p>
                    <div className = {registerStyle.btnWrapper}>
                        <button onClick = {registerFormSubmit} disabled = {isFormInvalid}>Register</button>
                    </div>
                </div>
                
            </Col>
    </Row>
    </Container>
    )
}

export default RegisterPage;