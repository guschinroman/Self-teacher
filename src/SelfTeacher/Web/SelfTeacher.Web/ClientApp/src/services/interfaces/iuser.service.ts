import { UserDto } from "../../models/UserDto";
import { ListDto } from "../../models/ListDto";

export abstract class IUserService {

    /**
     * login method user service
     * @param username - login of user
     * @param password - password of user
     * @returns Promise after request and adding to local storage
     */
    public abstract login(username: string, password: string): Promise<any>;

    /**
     * Logout function for remove user info from local storage
     */
    public abstract logout(): void;

    /**
     * Register user in system by user info
     */
    public abstract register(user: UserDto): Promise<any>;

    /**
     * Method for getting all users in system
     * @returns Promise with all users in system
     */
    public abstract getAll(): Promise<ListDto<UserDto>>;

    /**
     * Method for getting user by ID
     * @param id - id of user
     * @returns Promise with User information
     */
    public abstract getById(id: string): Promise<UserDto>;

    /**
     * Method for update user information
     * @param User - UserDto for update
     * @returns Promise request for update
     */
    public abstract update(user: UserDto): Promise<UserDto>;

    /**
     * 
     * @param id - id of user for deleting
     * @returns Promise request of deleting user
     */
    public abstract delete(id: string): Promise<void>;

    /**
     * @returns Flag if user in login
     */
    public abstract IsLoginUser(): boolean;
}

