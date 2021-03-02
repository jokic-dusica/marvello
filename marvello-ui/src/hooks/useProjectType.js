import {api} from '../utils/api';

const useProjectType = () => {
    const getProjectTypes = () => {
        var listProjectTypes = [];
        api("/api/projectTypes", "get").then(response => {
            listProjectTypes = response.data;
            return listProjectTypes;
        })
    } 
    return {
        getProjectTypes
    }
}

export default useProjectType;