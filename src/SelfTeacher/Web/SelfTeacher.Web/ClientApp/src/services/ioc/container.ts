import { Container } from 'inversify';
import { IAuthenticateHttp } from './../communication/iauthenticate-http';
import { AuthenticateHttp } from './../communication/authenticate-http';
import { IUserService } from '../interfaces/iuser.service';
import { UserService } from './../user.service';
import { UserActionCreator } from '../../actions';

export const AppContainer = new Container();

AppContainer.bind<IAuthenticateHttp>("authenticate-http").to(AuthenticateHttp);
AppContainer.bind<IUserService>("user-service").to(UserService);
AppContainer.bind<UserActionCreator>("user-action-creator").to(UserActionCreator);
