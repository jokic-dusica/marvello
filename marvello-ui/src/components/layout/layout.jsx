import { observer } from 'mobx-react';
import React, { useEffect, useState } from 'react';
import AuthStore from '../../store/auth/authStore';
import AuthStoreTest from '../../store/auth/authStoreTest';
import PrivateRoutes from '../routes/privateRoutes';
import PublicRoutes from '../routes/publicRoutes';
// import makeInspectable from 'mobx-devtools-mst';


const Layout = ({authStore}) => {
    // makeInspectable(authStore);
    const [isAuth, setIsAuth] = useState(false);
    return (
        <>
            {authStore.isLogged == true && <PrivateRoutes authStore = {authStore}/>}
            {authStore.isLogged == false && <PublicRoutes authStore = {authStore}/>}
        </>
    )

}

export default observer(Layout);