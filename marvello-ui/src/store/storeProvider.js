import { useLocalObservable, useLocalStore } from "mobx-react";
import  { createContext } from "react";
import AuthStore from "./auth/authStore";

export const StoreContext = createContext();

export const StoreProvider = (props) => {
    const auth = new AuthStore();
    return (
        <StoreContext.Provider value = {useLocalObservable(() =>(
        {
            auth
        }
        ))}>
            {props.children}
        </StoreContext.Provider>
    )
}
