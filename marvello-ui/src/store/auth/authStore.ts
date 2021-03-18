import { observable, action, makeAutoObservable } from "mobx";
import { threadId } from "node:worker_threads";
import { apiCall } from "../../utils/api";

class AuthStore {
    @observable token = "";
    @observable isAdmin = false;
    @observable currentUser = null;
    @observable isSuccess = false;
    @observable message = "";
    @observable createdUser = null;
    @observable isLogged = false;
    @observable isApiSent = false;

    // constructor(){
    //     this.token = "";
    //     this.isSuccess = false;
        
    // }
    
    @action.bound
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
    @action.bound
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


export default AuthStore;