import "reflect-metadata";
import * as React from "react";
import { render } from 'react-dom';

import { store } from './helpers';
import { App } from './components/MainPage';
import { Provider } from "react-redux";
import { LocalizeProvider } from "react-localize-redux";


render(
    <Provider store={store}>
        <LocalizeProvider>
            <App />
        </LocalizeProvider>
    </Provider>,
    document.getElementById('app')
);
