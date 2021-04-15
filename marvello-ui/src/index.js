import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import AuthStore from './store/auth/authStore';
import CommonStore from './store/common/commonStore';
import { Provider,Observer } from 'mobx-react';
import AuthStoreTest from './store/auth/authStoreTest';

const authStore = new AuthStore();
ReactDOM.render(

    <Provider>
      <App  authStore = {authStore}/>
    </Provider>,

  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
