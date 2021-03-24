
import React,{useEffect, useState} from 'react';
import ProjectStore from '../../store/project/projectStore';
import {observer} from 'mobx-react';

const ProjectInfo = (props) => {
    const projectStore = new ProjectStore();
    const [selectedState, setSelectedState] = useState();
    useEffect(() => {(
        async ()=>{
        await projectStore.getProjectById(1);
        setSelectedState(projectStore.selectedProject);
    })()
       
    },[])
    return (<>
        <p>{selectedState?.name}</p>
        <a>Add Project</a>
    </>)
}

export default observer(ProjectInfo);