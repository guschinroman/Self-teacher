"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var alert_constants_1 = require("./../constrants/alert.constants");
function SuccessAlertAction(message) {
    return {
        type: alert_constants_1.AlertConstants.SUCCESS,
        message: message
    };
}
exports.SuccessAlertAction = SuccessAlertAction;
function ErrorAlertAction(error) {
    return {
        type: alert_constants_1.AlertConstants.ERROR,
        message: error
    };
}
exports.ErrorAlertAction = ErrorAlertAction;
function ClearAlertAction(message) {
    return {
        type: alert_constants_1.AlertConstants.CLEAR,
        message: message
    };
}
exports.ClearAlertAction = ClearAlertAction;
//# sourceMappingURL=alert.actions.js.map