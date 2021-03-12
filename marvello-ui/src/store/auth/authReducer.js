import React, { useReducer, createContext } from "react";
import { apiCall } from "../../utils/api";

const defaultUrl = "api/auth";

const signIn = async(entity) => {
    let response = await apiCall(`${defaultUrl}/login`,"post", entity);
    if(response.isSuccess == true) {
        localStorage.setItem("accessToken",response.data.token);
        
    }
    return response;
}

const signUp = async(entity) => {
    let response = await apiCall(`${defaultUrl}/register`,"post",entity);
   return response;
}

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
        var response = await signIn(action.userDTO);
        return {
            ...state,
            token: response.data?.token,
            isSuccess: response.isSuccess,
            message: response.message
        }
        case "REGISTER":
        var response = await signUp(action.newUser);
        return {
            ...state,
            isSuccess: response.isSuccess,
            message: response.message
        }
    }
}

