import { alertConstants } from '../constrants';

export const alertActions = {
    success,
    error,
    clean
};

function success(message) {
    return { type: alertConstrants.alertConstants.SUCCESS, message };
}

function error(message) {
    return { type: alertConstrants.alertConstants.ERROR, message };
}

function clear(message) {
    return { type: alertConstants.alertConstants.CLEAR, message };
}
