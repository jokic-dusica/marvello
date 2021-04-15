import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Switch, Route,Link, Redirect} from "react-router-dom";
import Dashboard from './pages/dashboard/dashboard';
import LoginPage from '../src/pages/login/loginPage';
import RegisterPage from '../src/pages/register/registerPage';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import { StoreProvider } from './store/storeProvider';
import AuthStore from '../src/store/auth/authStore'; 
import Loader from './components/loader/loader';
import CommonStore from './store/common/commonStore';
import { observer, inject, Observer } from 'mobx-react';
import React,{useEffect, useState} from 'react';
import NavBar from './components/navbar/navbar';
import AddProject from './components/addproject/addProject';
import PrivateRoutes from './components/routes/privateRoutes';
import PublicRoutes from './components/routes/publicRoutes';
import Layout from './components/layout/layout';



const App = ({authStore})  => {
  return (  
    <div>
      
        <Router>
          <div className="App">
            <Switch>  

                  <Layout authStore ={authStore}/>          
            </Switch>         
          </div>
        </Router>  
      </div>    
   
  );
}

export default observer(App) ;
