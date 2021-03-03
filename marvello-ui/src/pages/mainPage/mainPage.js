import React, {useState, useEffect} from 'react';
import useProjectType from '../../hooks/useProjectType';
const MainPage = () => {
    const[projectTypes, setProjectTypes] = useState();
    const {getProjectTypes,getOneProjectType} = useProjectType();
    useEffect(async () => {
        var data = await getOneProjectType(2);
        setProjectTypes(data);
    }, [])
    return <>
        {/* {projectTypes?.map((item) => {
            return (
                <p key={item.id}>{item.name}</p>
            )
        })} */}
         <p>{projectTypes?.name}</p>
    </>
}

export default MainPage;