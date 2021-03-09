import React, { useState } from 'react';
import useAuth from '../../hooks/useAuth';
import {useHistory} from 'react-router-dom';

const RegisterPage = () => {
    const {signUp} = useAuth();
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
       var response = await signUp(newUser);
        if(response.isSuccess) {
            history.push("/");
        }
        else {
            setErrorMessage(response.message);
        }

    }
    return (
    <>
    <div>
        <label>Your Name</label>
        <input type="text" name="name" onChange = {inputChangeHandler}/>
    </div>
    <div>
        <label>Your Email</label>
        <input type="text" name="email" onChange = {inputChangeHandler}/>
    </div>
    <div>
        <label>Your Username</label>
        <input type="text" name="username" onChange = {inputChangeHandler}/>
    </div>
    <div>
        <label>Your Password</label>
        <input type="password" name="password" onChange = {inputChangeHandler}/>
    </div>
    <div>
        <label>Confirm Your Password</label>
        <input type="password" name="confirmPassword" onChange = {repeatedPasswordHandler}/>
    </div>
    <p>{errorMessage}</p>
    <div>
        <button onClick = {registerFormSubmit} disabled = {isFormInvalid}>Register</button>
    </div>
    </>
    )
}

export default RegisterPage;