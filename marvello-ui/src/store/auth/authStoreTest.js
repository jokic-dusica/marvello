import { action, makeObservable, observable } from "mobx";
import { apiCall } from "../../utils/api";

class AuthStoreTest {
    token = "";
    isAdmin = false;
    currentUser = null;
    isSuccess = false;
    message = "";
    createdUser = null;
    isLogged = false;
    isApiSent = false;

    constructor() {
        makeObservable(this,{
            token: observable,
            isAdmin: observable,
            currentUser: observable,
            isSuccess: observable,
            message: observable,
            createdUser: observable,
            isLogged: observable,
            isApiSent: observable,
            signIn: action,
            signUp:action
        })
    }

    signIn = async(entity) => {
        let response = await apiCall("/api/auth/login","post", entity);
        if(response.isSuccess == true) {
            this.token = response.data.token;
            this.isSuccess = true;
            this.isAdmin = response.data.isAdmin;
            this.message = "";
            this.isLogged = true;
            this.isApiSent = false;
        }
        else {
            this.message = response.message;
            this.isApiSent = false;
        }
    }

    async signUp(entity) {
        let response = await apiCall("/api/auth/register", "post", entity);
        if(response.isSuccess ==  true) {
            this.isSuccess = true;
            this.createdUser = response.data.createdUser
        }
        else {
            this.isSuccess = false;
            this.message = response.message
        }
    }
}
export default AuthStoreTest;