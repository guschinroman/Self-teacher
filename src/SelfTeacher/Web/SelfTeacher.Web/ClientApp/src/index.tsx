import "reflect-metadata";
import * as React from "react";
import { render } from 'react-dom';
import * as inversify from 'inversify';
import { Provider } from 'react-inversify';

import { store } from './helpers';
import { App } from './components/MainPage';
import { AppContainer } from "./services/ioc/container";


render(
    <Provider store={store} container={AppContainer}>
        <App />
    </Provider>,
    document.getElementById('app')
);
