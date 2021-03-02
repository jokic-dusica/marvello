import axios from 'axios';
import React from 'react';

const defaultUrl = "localhost:8080";
export const api =  (url, method, data = null) => 
    new Promise((resolve, reject) => {
        axios({
            url: `${defaultUrl}${url}`,
            method: method,
            data: data,
            params: data
        }).then(
            response => {
                resolve(response.data);
            },
            error => {
                reject(error.response.data.error);
            }
        )
    })
