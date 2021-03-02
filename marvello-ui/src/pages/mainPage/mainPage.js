import React, {useState, useEffect} from 'react';
import useProjectType from '../../hooks/useProjectType';
const MainPage = () => {
    const[projectTypes, setProjectTypes] = useState();
    const {getProjectTypes} = useProjectType();
    useEffect(() => {
        var data = getProjectTypes();
        setProjectTypes(data);
    }, [])
    return <>
        <p>Duska</p>
    </>
}

export default MainPage;