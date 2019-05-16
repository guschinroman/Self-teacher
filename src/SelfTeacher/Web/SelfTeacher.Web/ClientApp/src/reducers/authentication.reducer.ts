import { UserConstants } from '../constrants';
import { ConstStringsService } from '../services';
import { RegisterActions, RequestLoginAction, SuccessRegisterAction } from '../types';

let user = JSON.parse(localStorage.getItem(ConstStringsService.USER_LOCALSTORAGE));
const initialState = user ? { loggedIn: true, user } : { loggedIn: false };

export function authentication(state = initialState, action: RegisterActions) {
    switch (action.type) {
        case UserConstants.LOGIN_REQUEST:
            return {
                loggingIn: true,
                user: (<RequestLoginAction>action).user
            };
        case UserConstants.LOGIN_SUCCESS:
            return {
                loggedIn: true,
                user: (<SuccessRegisterAction>action).user
            };
        case UserConstants.LOGIN_FAILURE:
            return {
                loggedIn: false
            };
        case UserConstants.LOGOUT:
            return {
                loggedIn: false
            };
        default:
            return state;
    }
}
