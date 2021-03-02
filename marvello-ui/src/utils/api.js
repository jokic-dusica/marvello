import axios from 'axios';
import React from 'react';

axios.defaults.withCredentials = true;
export const api =  (url, method, data = null) => 
    new Promise((resolve, reject) => {
        axios({
            url: `${url}`,
            method: method,
            data: data,
            params: data,
        }).then(
            response => {
                resolve(response.data);
            },
            error => {
                reject(error.response.data.error);
            }
        )
    })
