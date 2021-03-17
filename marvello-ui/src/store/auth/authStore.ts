import { observable, action, makeAutoObservable } from "mobx";
import { apiCall } from "../../utils/api";

class AuthStore {
    @observable token = "";
    @observable isAdmin = false;
    @observable currentUser = null;
    @observable isSuccess = false;
    @observable message = "";

    // constructor(){
    //     this.token = "";
    //     this.isSuccess = false;
        
    // }
    
    @action.bound
     signIn= async(entity) => {
        let response = await apiCall("/api/auth/login","post", entity);
        if(response.isSuccess == true) {
            this.token = response.data.token;
            this.isSuccess = true;
            this.isAdmin = response.data.isAdmin;
            this.message = "";
        }
        else {
            this.message = response.message;
        }
    }
    @action.bound
    async signUp(entity) {
        let response = await apiCall("/api/auth/register", "post", entity);
        if(response.isSuccess) {
            this.isSuccess = true;
        }
    }
}


export default AuthStore;