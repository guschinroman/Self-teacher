import { UserConstants } from "../../constrants";
import { UserDto } from "../../models/UserDto";

export class RequestRegisterAction {
    public type: string = UserConstants.REGISTER_REQUEST;
    user: UserDto;
}

export class SuccessRegisterAction {
    public type: string = UserConstants.REGISTER_SUCCESS;
    user: UserDto;
}

export class FailureRegisterAction {
    public type: string = UserConstants.REGISTER_FAILURE;
    error: any
}

export type RegisterActions = RequestRegisterAction | SuccessRegisterAction | FailureRegisterAction;
