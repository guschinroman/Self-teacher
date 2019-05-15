"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var user_constants_1 = require("./../constrants/user.constants");
var RequestAction = /** @class */ (function () {
    function RequestAction() {
        this.type = user_constants_1.UserConstants.LOGIN_REQUEST;
    }
    return RequestAction;
}());
exports.RequestAction = RequestAction;
var SuccessAction = /** @class */ (function () {
    function SuccessAction() {
        this.type = user_constants_1.UserConstants.LOGIN_SUCCESS;
    }
    return SuccessAction;
}());
exports.SuccessAction = SuccessAction;
var FailureAction = /** @class */ (function () {
    function FailureAction() {
        this.type = user_constants_1.UserConstants.LOGIN_FAILURE;
    }
    return FailureAction;
}());
exports.FailureAction = FailureAction;
//# sourceMappingURL=login.types.js.map