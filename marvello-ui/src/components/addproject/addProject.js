
import { observer } from 'mobx-react';
import React,{useEffect, useState} from 'react';
import ProjectStore from '../../store/project/projectStore';
import ProjectType from '../../store/projectType/projectTypeStore';

const AddProject = () => {
    const projectStore = new ProjectStore();
    const projectTypeStore = new ProjectType();
    const [projectTypeList, setProjectTypeList] = useState([]);
    useEffect(() => {
        (
            async() => {
                await projectTypeStore.getAllProjectType();
                setProjectTypeList(projectTypeStore.projectTypeList);
            }
        )()
    }, [])
    const[error, setErrorMessage] = useState();
    const[project, setProject] = useState(
        {
            name:"",
            typeId: 0,
            description:""
        }
    );
    const inputChangeHandler = (e) => {
        if(e.target.name == "typeId"){
            setProject({...project,[e.target.name]:parseInt(e.target.value)})
        }
        else {
            setProject({...project,[e.target.name]:e.target.value})
        }
       
    }
    const saveProject = async () => {
        await projectStore.saveProject(project);
        if(projectStore.isSuccess == true) {
            setErrorMessage("Saved successfully");
        }
        else {
            setErrorMessage(projectStore.message);
        }
    }
    
    return (
        <>
        <div>
            <div>
                <label>Project Name</label>
                <input type="text" name="name" onChange = {inputChangeHandler}/>
            </div>
            <div>
                <label>Type of Project</label>
                <select onChange = {inputChangeHandler} name="typeId">
                    {projectTypeList.map((item) => {
                        return <option key={item.id} value={item.id}>{item.name}</option>
                    })}
                </select>
            </div>
            <div>
                <label>Description</label>
                <textarea onChange = {inputChangeHandler} name="description">

                </textarea>
            </div>
        </div>
        <button onClick = {saveProject}>Save Changes</button>
        
        </>
    )
}

export default observer(AddProject);