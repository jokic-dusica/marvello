import React, { useReducer, createContext } from "react";
import { apiCall } from "../../utils/api";

const initialState = {
    token:"",
    isAdmin: false,
    currentUser: null,
    isLogged: false,
    isSuccess: true,
    message: ""
}

export const authReducer = async (state = initialState, action) => {
    switch(action.type) {
        case "LOGIN" : 
        var response = action.response;
        return {
            ...state,
            token: response.data?.token,
            isSuccess: response.isSuccess,
            message: response.message
        }
        case "REGISTER":
        var response = action.newUser;
        return {
            ...state,
            isSuccess: response.isSuccess,
            message: response.message
        }
    }
}

