"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var __1 = require("..");
var ApiPathService = /** @class */ (function () {
    function ApiPathService() {
    }
    //Login paths
    ApiPathService.authenticationPath = function () {
        return __1.ConfigApplication.apiUrl + "/users/authenticate";
    };
    ApiPathService.registrationPath = function () {
        return __1.ConfigApplication.apiUrl + "/users/register";
    };
    ApiPathService.getUsersListPath = function () {
        return __1.ConfigApplication.apiUrl + "/users";
    };
    ApiPathService.getUserById = function (id) {
        return __1.ConfigApplication.apiUrl + "/users/" + id;
    };
    ApiPathService.updateUserByID = function (user) {
        return __1.ConfigApplication.apiUrl + "/users/" + user.Id;
    };
    ApiPathService.deleteUserById = function (id) {
        return __1.ConfigApplication.apiUrl + "/users/" + id;
    };
    return ApiPathService;
}());
exports.ApiPathService = ApiPathService;
//# sourceMappingURL=api-path.service.js.map