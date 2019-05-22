import { ConfigApplication } from "..";
import { UserDto } from './../../models/UserDto';


export class ApiPathService {

    //Login paths
    public static authenticationPath() {
        return `${ConfigApplication.apiUrl}/users/authenticate`;
    }

    public static registrationPath() {
        return `${ConfigApplication.apiUrl}/users/register`;
    }

    public static getUsersListPath() {
        return `${ConfigApplication.apiUrl}/users`;
    }

    public static getUserById(id: string) {
        return `${ConfigApplication.apiUrl}/users/${id}`;
    }

    public static updateUserByID(user: UserDto) {
        return `${ConfigApplication.apiUrl}/users/${user.Id}`;
    }

    public static deleteUserById(id: string) {
        return `${ConfigApplication.apiUrl}/users/${id}`;
    }

    //Account paths
    public static getVkAuthPath() {
        return `${ConfigApplication.apiUrl}/account/get-vk-authenticate-link`;
    }
}
