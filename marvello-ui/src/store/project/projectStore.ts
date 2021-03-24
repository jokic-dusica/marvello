import React from 'react';
import { action, observable } from "mobx";
import { apiCall } from '../../utils/api';

class ProjectStore {
    @observable projects = [];
    @observable selectedProject = null;
    @observable isSuccess = false;
    @observable message = "";

    @action.bound
    getProjectById = async(id) => {
        let response =  await apiCall(`/api/projects/${id}`);
        if(response.isSuccess == true) {
            this.selectedProject = response.data;
            this.isSuccess = true;
            this.message = response.message;            
        }
        else {
            this.isSuccess = false;
            this.message = response.message;
        }
    }   

    @action.bound
    saveProject = async(entity) => {
        let response = await apiCall(`/api/projects`,"post",entity);
        if(response.isSuccess == true) {
            this.isSuccess = true;
            this.message = response.message;
            this.projects.push(response.data);
        }
        else {
            this.isSuccess = false;
            this.message = response.message;
        }
    }
}

export default ProjectStore;
