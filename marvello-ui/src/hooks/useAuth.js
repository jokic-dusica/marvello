import { apiCall } from "../utils/api";

const defaultUrl = "api/auth";
const useAuth = () => {
    const refreshToken = async () => {
        let response = await apiCall(`${defaultUrl}/refreshToken`,"post");
        if(response.isSuccess == true) {
           return response.data.token;
        }
        return;
    }
    const signIn = async(entity) => {
        let response = await apiCall(`${defaultUrl}/login`,"post", entity);
        if(response.isSuccess == true) {
            localStorage.setItem("accessToken",response.data.token);
            return response.data;
        }
        return;
    }
    const signUp = async(entity) => {
        let response = await apiCall(`${defaultUrl}/register`,"post",entity);
        if(response.isSuccess) {
            return response.data;
        }
        return;
    }

    return {
       refreshToken,
       signIn,
       signUp
    }
}


export default useAuth;