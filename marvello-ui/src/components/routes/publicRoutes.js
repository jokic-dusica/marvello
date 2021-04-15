import React from 'react';
import { Container } from 'react-bootstrap';
import { BrowserRouter as Router, Switch, Route,Link, Redirect} from "react-router-dom";
import LoginPage from '../../pages/login/loginPage';
import RegisterPage from '../../pages/register/registerPage';

const PublicRoutes = ({authStore}) => {
return (<>
    <Route exact path = "/"  component={() => <LoginPage authStore={authStore}/>}/>
    <Route exact path="/register" component={() => <RegisterPage authStore={authStore}/>}/>
</>)
}

export default PublicRoutes;