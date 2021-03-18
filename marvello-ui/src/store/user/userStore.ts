import { observable, action, makeAutoObservable } from "mobx";
import { apiCall } from "../../utils/api";

class UserStore {
    @observable users = [];


    @action.bound
    addUserToList = (user) => {
        this.users.push(user);
    }
}
export default UserStore;