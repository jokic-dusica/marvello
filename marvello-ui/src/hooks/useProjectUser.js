import {apiCall} from '../utils/api';

const defaultUrl = "/api/projectUsers";

const useProjectUser = () => {

    const getAllProjectUser = async () => {
        var response = await apiCall(defaultUrl,"get");
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const getProjectUserById = async (id) => {
        var response = await apiCall(`${defaultUrl}/${id}`, "get");
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const createProjectUser = async (projectUser) => {
        var response = await apiCall(defaultUrl, "post", projectUser);
        if(response.isSuccess){
            return response.data;
        }
        else {
            return {}
        }
    }

    const updateProjectUser = async (projectUser) => {
        var response = await apiCall(`${defaultUrl}/${projectUser.id}`, "put", projectUser);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const deleteProjectUser = async (projectUser) => {
        var response = await apiCall(defaultUrl,"delete", projectUser);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    return {
        getAllProjectUser,
        getProjectUserById,
        createProjectUser,
        updateProjectUser,
        deleteProjectUser
    }
}

export default useProjectUser;