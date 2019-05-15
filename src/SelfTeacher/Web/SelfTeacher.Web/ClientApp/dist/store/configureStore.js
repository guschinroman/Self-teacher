"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var redux_1 = require("redux");
var redux_thunk_1 = require("redux-thunk");
var redux_logger_1 = require("redux-logger");
var reducers_1 = require("../reducers");
var loggerMiddleware = redux_logger_1.createLogger();
exports.store = redux_1.createStore(reducers_1.rootReducer, redux_1.applyMiddleware(redux_thunk_1.default, loggerMiddleware));
//# sourceMappingURL=configureStore.js.map