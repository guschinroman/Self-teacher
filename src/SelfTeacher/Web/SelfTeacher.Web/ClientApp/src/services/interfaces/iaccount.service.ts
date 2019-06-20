import { AuthenticateDto } from "../../models/AuthenticateDto";


export abstract class IAccountService {

    /**
     * Get vk authentication link
     * @returns Promise after request to server
     */
    abstract GetVkAuthLink(): Promise<string>;

    abstract GetAuthenticationDtoByAccessToken(accessToken: string): Promise<AuthenticateDto>;
}

