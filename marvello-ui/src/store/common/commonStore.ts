import { action, observable } from 'mobx';
import React from 'react';


class CommonStore {
    @observable isApiSent = false;

    @action.bound
    changeApiState = (apiSent) => {
        this.isApiSent = apiSent;
    }
}

export default CommonStore;