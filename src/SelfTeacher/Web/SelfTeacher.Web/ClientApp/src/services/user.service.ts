import { config } from './config/config.service';
import { constStringsService } from '.';
import { authHaldler, authHeader } from '../helpers';
import { ListDto } from './../models/ListDto';
import { UserDto } from './../models/UserDto';

export class userService {

    /**
     * login method user service
     * @param username - login of user
     * @param password - password of user
     * @returns Promise after request and adding to local storage
     */
    public async login(username: string, password: string): Promise<any> {

        const requestOptions = {
            method: 'POST',
            header: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ username, password })
        };
    
        const responce = await fetch(`${config.apiUrl}/users/authenticate`, requestOptions);
        const user = await handleResponce(responce);
        localStorage.setItem(constStringsService.USER_LOCALSTORAGE, user);
        return user;
    }

    /**
     * Logout function for remove user info from local storage
     */
    public logout(): void {
        localStorage.removeItem(constStringsService.USER_LOCALSTORAGE);
    }

    /**
     * Method for getting all users in system
     * @returns Promise with all users in system
     */
    public async getAll(): Promise<ListDto<UserDto>> {
        const requestOptions = {
            method: 'GET',
            headers: authHeader()
        };
    
        const responce = await fetch(`${config.apiUrl}/users`, requestOptions);
        return handleResponce(responce);
    }

    /**
     * Method for getting user by ID
     * @param id - id of user
     * @returns Promise with User information
     */
    public async getById(id: string): Promise<UserDto> {
        const requestOptions = {
            method: 'GET',
            header: authHeader()
        };
    
        const responce = await fetch(`${config.apiUrl}/users/${id}`, requestOptions);
        return handleResponce(responce);
    }

    /**
     * Method for update user information
     * @param User - UserDto for update
     * @returns Promise request for update
     */
    public update(user: UserDto): Promise<UserDto> {
        const requestOptions = {
            method: 'PUT',
            headers: { ...authHeader(), 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        };
    
        return fetch(`${config.apiUrl}/users/${user.Id}`, requestOptions).then(handleResponce);
    }

    /**
     * 
     * @param id - id of user for deleting
     * @returns Promise request of deleting user
     */
    public async delete(id: string): Promise<void> {

        const requestOptions = {
            method: 'DELETE',
            headers: authHeader()
        };
    
        const responce = await fetch(`${config.apiUrl}/users/${id}`, requestOptions);
        return handleResponce(responce);
    }

}

