import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Switch, Route,Link} from "react-router-dom";
import MainPage from './pages/mainPage/mainPage';
import axios from 'axios';

function App() {

  return (
    <Router>
      <div className="App">
        <Switch>
          <Route path = "/" component = {MainPage}/>
        </Switch>
        
      </div>
    </Router>
  );
}

export default App;
