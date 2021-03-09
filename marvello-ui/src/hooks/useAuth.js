import { apiCall } from "../utils/api";

const defaultUrl = "api/auth";
const useAuth = () => {

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

    return {
       signIn,
       signUp
    }
}


export default useAuth;