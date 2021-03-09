import React,{useState} from 'react';
import useAuth from '../../hooks/useAuth';
import {useHistory} from 'react-router-dom';


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
        <>
            <div>
                <label>Your Username</label>
                <input type="text" name="username" onChange = {inputChangeHandler}/>
            </div>
            <div>
                <label>Your Password</label>
                <input type="password" name="password" onChange = {inputChangeHandler}/>
            </div>
            <p>{errorMessage}</p>
            <button onClick = {signInSubmit}>Sign in</button>
        </>
    )

}

export default LoginPage;