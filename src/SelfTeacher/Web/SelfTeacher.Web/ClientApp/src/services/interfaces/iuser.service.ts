import { UserDto } from "../../models/UserDto";
import { ListDto } from "../../models/ListDto";

export interface IUserService {

    /**
     * login method user service
     * @param username - login of user
     * @param password - password of user
     * @returns Promise after request and adding to local storage
     */
    login(username: string, password: string): Promise<any>;

    /**
     * Logout function for remove user info from local storage
     */
    logout(): void;

    /**
     * Register user in system by user info
     */
    register(user: UserDto): Promise<any>;

    /**
     * Method for getting all users in system
     * @returns Promise with all users in system
     */
    getAll(): Promise<ListDto<UserDto>>;

    /**
     * Method for getting user by ID
     * @param id - id of user
     * @returns Promise with User information
     */
    getById(id: string): Promise<UserDto>;

    /**
     * Method for update user information
     * @param User - UserDto for update
     * @returns Promise request for update
     */
    update(user: UserDto): Promise<UserDto>;

    /**
     * 
     * @param id - id of user for deleting
     * @returns Promise request of deleting user
     */
    delete(id: string): Promise<void>;
}

