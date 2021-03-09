import axios from 'axios';
import React from 'react';

const defaultUrl = "localhost:8080";
axios.defaults.withCredentials = true;
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
        data: response.data
    }
    } catch (error) {
        return {
            isSuccess: false,
            message: error
        }
    }
}
