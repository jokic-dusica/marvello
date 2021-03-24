import React from 'react';
import CommonStore from '../../store/common/commonStore';
import loaderStyle from './loader.module.css';
const Loader = () => {
    const commonStore = new CommonStore();

     return (
        <>
        <div className ={loaderStyle.loaderWrapper}>
            <div className={loaderStyle.ldsSpinner}><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div></div>
        </div>
        </>
    ) 
    

}
// export const showProgress = () => {
//     commonStore.isApiSent = true;
// }
// export const hideProgress = () => {
//     commonStore.isApiSent = false;
// }
export default Loader;