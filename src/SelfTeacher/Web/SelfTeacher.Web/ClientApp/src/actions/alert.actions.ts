import { AlertConstants } from './../constrants/alert.constants';
import { AlertActionsTypes } from '../types';

export function SuccessAlertAction(message: string): AlertActionsTypes {
    return {
        type: AlertConstants.SUCCESS,
        message: message
    }
}

export function ErrorAlertAction(error: string): AlertActionsTypes {
    return {
        type: AlertConstants.ERROR,
        message: error
    }
}

export function ClearAlertAction(message: string): AlertActionsTypes {
    return {
        type: AlertConstants.CLEAR,
        message: message
    }
}
