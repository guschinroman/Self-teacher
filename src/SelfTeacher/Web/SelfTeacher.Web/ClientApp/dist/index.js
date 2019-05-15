"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("reflect-metadata");
var React = require("react");
var react_dom_1 = require("react-dom");
var react_inversify_1 = require("react-inversify");
var helpers_1 = require("./helpers");
var MainPage_1 = require("./components/MainPage");
var container_1 = require("./services/ioc/container");
react_dom_1.render(React.createElement(react_inversify_1.Provider, { store: helpers_1.store, container: container_1.AppContainer },
    React.createElement(MainPage_1.App, null)), document.getElementById('app'));
//# sourceMappingURL=index.js.map