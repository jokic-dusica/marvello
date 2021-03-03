import {apiCall} from '../utils/api';

const defaultUrl = "api/users";

const useUser = () => {
    const getAllUsers = async () => {
        var response = await apiCall(defaultUrl,"get");
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const getUserById = async (id) => {
        var response = await apiCall(`${defaultUrl}/${id}`, "get");
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const createUser = async (user) => {
        var response = await apiCall(defaultUrl, "post", user);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const updateUser = async (user) => {
        var response = await apiCall(`${defaultUrl}/${user.id}`, "put", user);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const deleteUser = async (user) => {
        var response = await apiCall(defaultUrl, "delete", user);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    return {
        getAllUsers,
        getUserById,
        createUser,
        updateUser,
        deleteUser
    }
}

export default useUser;