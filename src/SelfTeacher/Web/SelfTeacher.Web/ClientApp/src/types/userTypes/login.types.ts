import { UserConstants } from '../../constrants/user.constants';
import { UserDto } from '../../models/UserDto';

export class RequestLoginAction {
    public type: string = UserConstants.LOGIN_REQUEST;
    user: UserDto;
}

export class SuccessLoginAction {
    public type: string = UserConstants.LOGIN_SUCCESS;
    user: UserDto
}

export class FailureLoginAction {
    public type: string = UserConstants.LOGIN_FAILURE;
    error: any
}

export type LoginActions = RequestLoginAction | SuccessLoginAction | FailureLoginAction;
