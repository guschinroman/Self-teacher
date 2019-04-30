import { alertConstants } from '../constrants'

export const aletrActions = {
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
