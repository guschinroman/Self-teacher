import "reflect-metadata";
import * as React from "react";
import { render } from 'react-dom';

import { store } from './helpers';
import { App } from './components/MainPage';
import { Provider } from "react-redux";


render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.getElementById('app')
);
