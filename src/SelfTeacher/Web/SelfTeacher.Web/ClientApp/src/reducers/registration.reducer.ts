import { UserConstants } from '../constrants';
import { RegisterActions } from '../types';

export function registration(state = {}, actions: RegisterActions) {
    switch (actions.type) {
        case UserConstants.REGISTER_REQUEST:
            return { registering: true };
        case UserConstants.REGISTER_SUCCESS:
            return {};
        case UserConstants.REGISTER_FAILURE:
            return {};
        default:
            return state;
    }
}