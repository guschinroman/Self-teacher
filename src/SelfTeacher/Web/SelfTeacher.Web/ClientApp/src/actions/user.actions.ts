import { Dispatch } from 'react';

import { ErrorAlertAction } from '.';
import { RegistrationTextConstantStrings, UserConstants } from '../constrants';
import { HistoryService } from '../helpers/history';
import { UserDto } from '../models/UserDto';
import { FailureRegisterAction, RegisterActions, RequestRegisterAction, SuccessRegisterAction } from '../types';
import { FailureLoginAction, LoginActions, RequestLoginAction, SuccessLoginAction } from '../types/userTypes/login.types';
import { IUserService } from './../services/interfaces/iuser.service';
import { SuccessAlertAction } from './alert.actions';
import { Inject } from 'typescript-ioc';

export class UserActionCreator {

    @Inject
    private readonly _userService: IUserService;

    public login(username: string, password: string) {
        return (dispatch: Dispatch<LoginActions>) => {
            
            const errorAction = new FailureLoginAction();
            const successAction = new SuccessLoginAction();
            const requestAction = new RequestLoginAction();
            const userDto = new UserDto();

            userDto.Username = username;            
            requestAction.user = userDto;
            successAction.user = userDto;

            dispatch(requestAction);
    
            this._userService.login(username, password)
                .then(
                    user => {
                        dispatch(successAction);
                        HistoryService.history.push('.');
                    },
                    error => {
                        errorAction.error = error.toString();
                        dispatch(errorAction);
                        dispatch(<any>ErrorAlertAction(error.toString()));
                    }
                );
        };
    
    }
    
    public logout() {
        this._userService.logout();
        return { type: UserConstants.LOGOUT };
    }
    
    public register(user: UserDto) {
        return (dispatch: Dispatch<RegisterActions>) => {
            const errorAction = new FailureRegisterAction();
            const successAction = new SuccessRegisterAction();
            const requestAction = new RequestRegisterAction();
            requestAction.user = user;
            successAction.user = user;

            dispatch(requestAction);
    
            this._userService.register(user)
                .then(
                    user => {
                        dispatch(successAction);
                        HistoryService.history.push('/login');
                        dispatch(<any>SuccessAlertAction(RegistrationTextConstantStrings.REGISTATION_SUCCESSFUL));
                    },
                    error => {
                        errorAction.error = error.toString();
                        dispatch(errorAction);
                        dispatch(<any>ErrorAlertAction(error.toString()));
                    }
                );
        };
    
    }
    
    public getAll() {
    }
}
