import { Container, Scope } from "typescript-ioc";
import { IUserService } from "../interfaces/iuser.service";
import { UserService } from './../user.service';
import { IAccountService } from "../interfaces/iaccount.service";
import { AccountService } from './../communication/account.service';
import { IAuthenticateHttp } from "../communication/iauthenticate-http";
import { AuthenticateHttp } from './../communication/authenticate-http';
import { UserActionCreator } from './../../actions/user.actions';

export class IocConfig {
    constructor() {

    }

    public static config() {
        Container.bind(IUserService).to(UserService).scope(Scope.Local);
        Container.bind(IAccountService).to(AccountService).scope(Scope.Local);
        Container.bind(IAuthenticateHttp).to(AuthenticateHttp).scope(Scope.Local);
        Container.bind(UserActionCreator).provider({ 
            get: () => { return new UserActionCreator(); }
        }).scope(Scope.Local);
    }
}
