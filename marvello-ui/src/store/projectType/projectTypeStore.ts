import React from 'react';
import { action, observable } from "mobx";
import { apiCall } from '../../utils/api';

class ProjectType {
    @observable projectTypeList = [];
    @observable isSuccess = false;
    @observable message = "";

    @action.bound
    getAllProjectType = async () => {
        let response = await apiCall("api/projectTypes","get");
        if(response.isSuccess == true) {
            this.projectTypeList = response.data;
        }
        else {
            this.isSuccess = false;
            this.message = response.message;
        }
    }
}

export default ProjectType;