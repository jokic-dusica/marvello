import { createContext, useContext } from "react";
import AuthStore from "../store/auth/authStore";

const context = createContext({
    authStore: new AuthStore()
});

const useStores = () => useContext(context);

export default useStores;