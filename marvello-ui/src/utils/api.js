import axios from 'axios';
import React from 'react';
import {refreshToken} from '../utils/util';


const defaultUrl = "localhost:8080";
axios.defaults.withCredentials = true;
axios.interceptors.request.use(function(config){
    let token = localStorage.getItem("accessToken");
    if(token) {
        config.headers = {
            'Authorization' : `Bearer ${token}`
        }
    }
    return config;
},
function(error) {
    return Promise.reject(error);
})

axios.interceptors.response.use(function(response) {
   return response;
}, async function(err){
    const originalRequest = err.config;
    if(err.response.status == 401 ){
        let token = await refreshToken();
        localStorage.setItem("accessToken",token);
        originalRequest.headers['Authorization'] = 'Bearer' + token;
        return axios(originalRequest);
    }
    return Promise.reject(err.response);
})

export const apiCall =  async (url, method, data = null) => {
    try {
        var response = await axios({
            url: url,
            method: method,
            params: data,
            data: data
        })
    return {
        isSuccess: true,
        data: response.data.responseData
    }
    } catch (error) {
        return {
            isSuccess: false,
            message: error.data.errorMessage
        }
    }
}
