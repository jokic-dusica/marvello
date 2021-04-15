
import React,{useEffect, useState} from 'react';
import ProjectStore from '../../store/project/projectStore';
import {observer} from 'mobx-react';
import {Link} from "react-router-dom";
import { NavLink } from 'react-bootstrap';

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
        <NavLink exact="true" href="/add-project" to="/add-project">Add Project</NavLink>
    </>)
}

export default observer(ProjectInfo);