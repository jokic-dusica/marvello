import {apiCall} from '../utils/api';

const defaultUrl = "/api/tasks";

const useTask = () => {

    const getAllTask = async () => {
        var response = await apiCall(defaultUrl,"get");
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const getTaskById = async (id) => {
        var response = await apiCall(`${defaultUrl}/${id}`, "get");
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const createTask = async (task) => {
        var response = await apiCall(defaultUrl,"post", task);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const updateTask = async (task) => {
        var response = await apiCall(`${defaultUrl}/${task.id}`, "put", task);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const deleteTask = async (task) => {
        var response = await apiCall(defaultUrl, "delete", task);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    return {
        getAllTask,
        getTaskById,
        createTask,
        updateTask,
        deleteTask
    }
}

export default useTask;