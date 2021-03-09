import { apiCall } from "./api";
const defaultUrl = "api/auth";

export const refreshToken = async () => {
    let response = await apiCall(`${defaultUrl}/refreshToken`,"post");
    if(response.isSuccess == true) {
       return response.data.token;
    }
    return;
}