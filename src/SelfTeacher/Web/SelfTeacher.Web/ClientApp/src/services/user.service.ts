import { ConstStringsService, ConfigApplication } from '.';
import { ListDto } from './../models/ListDto';
import { UserDto } from './../models/UserDto';
import { ApiPathService } from './communication/api-path.service';
import { IAuthenticateHttp } from './communication/iauthenticate-http';
import { Inject, Container } from 'typescript-ioc';
import { IUserService } from './interfaces/iuser.service';

export class UserService extends IUserService {

    @Inject
    private _authHttp: IAuthenticateHttp;

    public IsLoginUser() {
        const user = localStorage.getItem(ConstStringsService.USER_LOCALSTORAGE);

        return user && user != null;
    }

    /**
     * login method user service
     * @param username - login of user
     * @param password - password of user
     * @returns Promise after request and adding to local storage
     */
    public async login(username: string, password: string): Promise<any> {
        const responce = await this._authHttp.post(ApiPathService.authenticationPath(), JSON.stringify({ username, password }));
        const user:UserDto = await responce.json();
        localStorage.setItem(ConstStringsService.USER_LOCALSTORAGE, JSON.stringify(user));
    }

    /**
     * Logout function for remove user info from local storage
     */
    public logout(): void {
        localStorage.removeItem(ConstStringsService.USER_LOCALSTORAGE);
    }

    /**
     * Register user in system by user info
     */
    public async register(user: UserDto): Promise<any> {
        const responce = await this._authHttp.post(ApiPathService.registrationPath(), JSON.stringify(user));
        return responce.json();
    }

    /**
     * Method for getting all users in system
     * @returns Promise with all users in system
     */
    public async getAll(): Promise<ListDto<UserDto>> {            
        const responce = await this._authHttp.get(ApiPathService.getUsersListPath());
        return responce.json();
    }

    /**
     * Method for getting user by ID
     * @param id - id of user
     * @returns Promise with User information
     */
    public async getById(id: string): Promise<UserDto> {            
        const responce = await this._authHttp.get(ApiPathService.getUserById(id));
        return responce.json();
    }

    /**
     * Method for update user information
     * @param User - UserDto for update
     * @returns Promise request for update
     */
    public async update(user: UserDto): Promise<UserDto> {      
        
        const responce = await this._authHttp.post(ApiPathService.updateUserByID(user), JSON.stringify(user));
        return responce.json();
    }

    /**
     * 
     * @param id - id of user for deleting
     * @returns Promise request of deleting user
     */
    public async delete(id: string): Promise<void> {

        const responce = await this._authHttp.delete(ApiPathService.deleteUserById(id));
        return responce.json();
    }

}

