import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Switch, Route,Link} from "react-router-dom";
import MainPage from './pages/mainPage/mainPage';
import LoginPage from '../src/pages/login/loginPage';
import RegisterPage from '../src/pages/register/registerPage';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import { AuthContextProvider } from './store/auth/authContext';

function App() {

  return (
    <AuthContextProvider>
      <Router>
        <div className="App">
          <Switch>         
              <Route path = "/dashboard" component = {MainPage}/>
              <Route exact path = "/" component = {LoginPage}/>
              <Route path = "/register" component = {RegisterPage}/>     
          </Switch>         
        </div>
      </Router>      
    </AuthContextProvider>
  );
}

export default App;
