

export abstract class IAccountService {

    /**
     * Get vk authentication link
     * @returns Promise after request to server
     */
    abstract GetVkAuthLink(): Promise<string>;
}

