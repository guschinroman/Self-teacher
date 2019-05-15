"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var inversify_1 = require("inversify");
var authenticate_http_1 = require("./../communication/authenticate-http");
var user_service_1 = require("./../user.service");
exports.AppContainer = new inversify_1.Container();
exports.AppContainer.bind("authenticate-http").to(authenticate_http_1.AuthenticateHttp);
exports.AppContainer.bind("user-service").to(user_service_1.UserService);
//# sourceMappingURL=container.js.map