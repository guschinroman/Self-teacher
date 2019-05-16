import { AlertConstants } from '../constrants';
import { AlertActionsTypes } from '../types';
import { AlertSuccess, AlertError } from './../types/userTypes/alert.types';

export function alert(state = {}, action: AlertActionsTypes) {

    switch (action.type) {

        case AlertConstants.SUCCESS:
            return {
                type: 'alert-success',
                message: (<AlertSuccess>action).message
            };

        case AlertConstants.ERROR:
            return {
                type: 'alert-danger',
                message: (<AlertError>action).error
            };

        case AlertConstants.CLEAR:
            return {};
        default:
            return state;
    }

}
