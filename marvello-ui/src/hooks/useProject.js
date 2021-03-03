import {apiCall} from '../utils/api';

const defaultUrl = "/api/projects";
const useProject = () => {

    const getAllProjects = async () => {
        var response = await apiCall(defaultUrl,"get");
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const getProjectById = async (id) => {
        var response = await apiCall(`${defaultUrl}/${id}`,"get");
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const createProject = async (project) => {
        var response = await apiCall(defaultUrl, "post", project);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const updateProject = async (project) => {
        var response = await apiCall(`${defaultUrl}/${project.id}`, "put", project);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }
    
    const deleteProject = async (project) => {
        var response = await apiCall(defaultUrl,"delete", project);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    return {
        getAllProjects,
        getProjectById,
        createProject,
        updateProject,
        deleteProject
    }
}

export default useProject;
