import { useContext } from "react";
import { StoreContext } from "../store/storeProvider";




const useAuth = () => {
    const {
        auth
    } = useContext(StoreContext)
   
    return auth;
}


export default useAuth;