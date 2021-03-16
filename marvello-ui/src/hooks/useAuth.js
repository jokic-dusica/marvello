import { useContext } from "react";
import { StoreContext } from "../store/storeProvider";




const useAuth = () => {
    const {
        auth:{
            isSuccess,
            token,
            signIn,
            signUp
        }
    } = useContext(StoreContext)
   
    return {
        isSuccess,
        token,
        signIn,
        signUp
    }
}


export default useAuth;