import React from 'react';
import ProjectInfo from '../projectInfo/projectInfo';
import navBarStyles from './navbar.module.css';


const NavBar = () => {
    return (
        <>
            <div>
                <div className={navBarStyles.navBarWrapper}>
                    <ProjectInfo/>
                   
                </div>
            </div>
            
        </>
    )
}

export default NavBar;