import { useContext } from "react";
import { AuthContext } from "../store/auth/authContext";
import { apiCall } from "../utils/api";

// const defaultUrl = "api/auth";
const useAuth = () => {
    const [state, dispatch] = useContext(AuthContext);

    const signIn = async(entity) => {
      await dispatch ({
        type: "LOGIN",
        userDTO: entity
      })

      return {
        isSuccess:state?.isSuccess,
        message: state?.message
        }
    }
    const signUp = async(entity) => {
       await dispatch ({
           type:"REGISTER",
           newUser: entity
       })
       return {
           isSuccess: state.isSuccess,
           message: state.message
       }
    }

    return {
       signIn,
       signUp
    }
}


export default useAuth;