import { useContext } from "react";
import { AuthContext } from "../store/auth/authContext";
import { apiCall } from "../utils/api";

const defaultUrl = "api/auth";


const useAuth = () => {
    const [state, dispatch] = useContext(AuthContext);

    const signIn = async(entity) => {
        let response = await apiCall(`${defaultUrl}/login`,"post", entity);
        dispatch ({
            type: "LOGIN",
            response: response
         })
      return response;
    }
    const signUp = async(entity) => {
        let response = await apiCall(`${defaultUrl}/register`,"post",entity);
        dispatch ({
            type:"REGISTER",
            newUser: response
        })
        return response;
    }

    return {
       signIn,
       signUp
    }
}


export default useAuth;