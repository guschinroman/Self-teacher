import { alertConstants } from '../constrants';

export function alert(state = {}, action) {

    switch (action, state) {

        case alertConstants.SUCCESS:
            return {
                type: 'alert-success',
                message: action.message
            };

        case alertConstants.ERROR:
            return {
                type: 'alert-danger',
                message: action.message
            };

        case alertConstants.CLEAR:
            return {};
        default:
            return state;
    }

}
