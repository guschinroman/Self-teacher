"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var constrants_1 = require("../constrants");
var UserDto_1 = require("../models/UserDto");
var inversify_1 = require("inversify");
var login_types_1 = require("./../types/login.types");
var history_1 = require("../helpers/history");
var _1 = require(".");
var UserActionCreator = /** @class */ (function () {
    function UserActionCreator(userService) {
        this.userService = userService;
        this._userService = userService;
    }
    UserActionCreator.prototype.login = function (username, password) {
        var _this = this;
        return function (dispatch) {
            var errorAction = new login_types_1.FailureAction();
            var successAction = new login_types_1.SuccessAction();
            var requestAction = new login_types_1.RequestAction();
            var userDto = new UserDto_1.UserDto();
            userDto.Username = username;
            requestAction.user = userDto;
            successAction.user = userDto;
            dispatch(requestAction);
            _this._userService.login(username, password)
                .then(function (user) {
                dispatch(successAction);
                history_1.HistoryService.history.push('.');
            }, function (error) {
                errorAction.error = error.toString();
                dispatch(errorAction);
                dispatch(_1.ErrorAlertAction(error.toString()));
            });
        };
    };
    UserActionCreator.prototype.logout = function () {
        this._userService.logout();
        return { type: constrants_1.UserConstants.LOGOUT };
    };
    UserActionCreator.prototype.register = function (user) {
        return function (dispatch) {
            dispatch(request(user));
            userService.register(user)
                .then(function (user) {
                dispatch(success());
                history.push('/login');
                dispatch(alertActions.success(registrationTextConstantStrings.REGISTATION_SUCCESSFUL));
            }, function (error) {
                dispatch(failure(error.toString()));
                dispatch(alertActions.error(error.toString()));
            });
        };
    };
    UserActionCreator = __decorate([
        __param(0, inversify_1.inject("user-service"))
    ], UserActionCreator);
    return UserActionCreator;
}());
exports.UserActionCreator = UserActionCreator;
function getAll() {
    return function (dispatch) {
        dispatch(request());
        userService.getAll()
            .then(function (users) { return dispatch(success(users)); }, function (error) { return dispatch(failure(error.toString())); });
    };
    function request() { return { type: userConstants.GETALL_REQUEST, user: user }; }
    function success(user) { return { type: userConstants.GETALL_SUCCESS, user: user }; }
    function failure(error) { return { type: userConstants.GETALL_FAILURE, error: error }; }
}
function _delete(id) {
    return function (dispatch) {
        dispatch(request(id));
        userService.delete(id)
            .then(function (user) { return dispatch(success(id)); }, function (error) { return dispatch(failure(id, error.toString())); });
    };
    function request(id) { return { type: userConstants.DELETE_REQUEST, user: user }; }
    function success(id) { return { type: userConstants.DELETE_SUCCESS, user: user }; }
    function failure(id, error) { return { type: userConstants.DELETE_FAILURE, id: id, error: error }; }
}
//# sourceMappingURL=user.actions.js.map