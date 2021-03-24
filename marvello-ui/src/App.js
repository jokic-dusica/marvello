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
import { observer, inject } from 'mobx-react';
import React,{useEffect, useState} from 'react';


const App = ()  => {
  const commonStore = new CommonStore();
  const authStore = new AuthStore();
  const[loader, setLoader] = useState(false);
  useEffect(() => {
    setLoader(commonStore.isApiSent);
  },[commonStore.isApiSent])
  return (  
      <Router>
        <div className="App">
        {(loader == true) &&
          <Loader/>  
        }
          <Switch>         
              <Route exact path = "/dashboard" component = {Dashboard}/>
             
                <Route exact path = "/">
                  {authStore.isLogged == true ? <Redirect to ="/dashboard"/> : <LoginPage/>}
                </Route>              
              
              <Route exact path = "/register" component = {RegisterPage}/>                
          </Switch>         
        </div>
      </Router>      
   
  );
}

export default observer(App) ;
