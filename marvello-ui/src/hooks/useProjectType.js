import {apiCall} from '../utils/api';

const defaultUrl = "/api/projectTypes"

const useProjectType = () => {
    const getProjectTypes = async () => {
        var response = await apiCall(defaultUrl, "get");
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return [];
        }
    } 

    const getOneProjectType = async (id) => {
        var response = await apiCall(`${defaultUrl}/${id}`, "get");
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {};
        }
    }

    const saveProjectType = async(newType) => {
        var response = await apiCall(defaultUrl,"post", newType);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {};
        }
    }

    const updateProjectType = async(projectType) => {
        var response = await apiCall(`${defaultUrl}/${projectType.id}`, "put", projectType);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {};
        }
    }

    const deleteProjectType = async(projectType) => {
        var response = await apiCall(defaultUrl, "delete", projectType);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {};
        }
    }

    return {
        getProjectTypes,
        getOneProjectType,
        saveProjectType,
        updateProjectType,
        deleteProjectType
    }
}

export default useProjectType;