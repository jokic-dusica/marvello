import React, {useState, useEffect} from 'react';
import NavBar from '../../components/navbar/navbar';
import useProjectType from '../../hooks/useProjectType';
const Dashboard = () => {
    const[projectTypes, setProjectTypes] = useState();
    const {getProjectTypes,getOneProjectType} = useProjectType();
    return <>
        <NavBar/>
    </>
}

export default Dashboard;