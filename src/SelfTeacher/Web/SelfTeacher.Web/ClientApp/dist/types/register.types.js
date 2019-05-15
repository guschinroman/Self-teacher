"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function request(user) { return { type: userConstants.REGISTER_REQUEST, user: user }; }
function success(user) { return { type: userConstants.REGISTER_SUCCESS, user: user }; }
function failure(error) { return { type: userConstants.REGISTER_FAILURE, error: error }; }
var RequestAction = /** @class */ (function () {
    function RequestAction() {
        this.type = UserConstants.LOGIN_REQUEST;
    }
    return RequestAction;
}());
exports.RequestAction = RequestAction;
var SuccessAction = /** @class */ (function () {
    function SuccessAction() {
        this.type = UserConstants.LOGIN_SUCCESS;
    }
    return SuccessAction;
}());
exports.SuccessAction = SuccessAction;
var FailureAction = /** @class */ (function () {
    function FailureAction() {
        this.type = UserConstants.LOGIN_FAILURE;
    }
    return FailureAction;
}());
exports.FailureAction = FailureAction;
//# sourceMappingURL=register.types.js.map