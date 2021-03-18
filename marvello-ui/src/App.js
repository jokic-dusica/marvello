import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Switch, Route,Link} from "react-router-dom";
import Dashboard from './pages/dashboard/dashboard';
import LoginPage from '../src/pages/login/loginPage';
import RegisterPage from '../src/pages/register/registerPage';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import { StoreProvider } from './store/storeProvider';
import AuthStore from '../src/store/auth/authStore'; 
import Loader from './components/loader/loader';
import CommonStore from './store/common/commonStore';
import { observer } from 'mobx-react';


function App() {
  var authStore = new AuthStore();
  var commonStore = new CommonStore();
  return (
    <StoreProvider>
      <Router>
        <div className="App">
          <Switch>         
              <Route path = "/dashboard" component = {Dashboard}/>
              {authStore.isLogged == false && 
                <Route exact path = "/" component = {LoginPage}/>              
              }
              <Route path = "/register" component = {RegisterPage}/> 
              {commonStore.isApiSent == true &&                 
                <Loader/> 
              }
          </Switch>         
        </div>
      </Router>      
    </StoreProvider>
  );
}

export default observer(App);
