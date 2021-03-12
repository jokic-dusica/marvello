import React, { useState, createContext, useReducer } from "react";
import {authReducer} from '../../store/auth/authReducer';

export const AuthContext = createContext();

export const AuthContextProvider = props => {
    const [state, dispatch] = useReducer(authReducer)
    return (
        <AuthContext.Provider value = {[state, dispatch]}>
            {props.children}
        </AuthContext.Provider>
    )
}