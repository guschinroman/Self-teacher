import { ConstStringsService, ConfigApplication } from '..';

export interface IAuthenticateHttp {

/**
 * GET request for client
 * @param url URL for request
 * @param options Headers for request
 * @param encode flag for set header x-www-form-urlencoded
 */
    get(url: string, options?: any, encode?: boolean): Promise<Response>;

    /**
     * POST request for client
     * @param url - url request
     * @param body - body information
     * @param options - Header and another info
     */
    post(url: string, body: string,  options?: any): Promise<Response>;

    /**
     * PUT request for client
     * @param url - url request
     * @param body - body information
     * @param options - header and another info
     */
    put(url: string, body: string, options?: any): Promise<Response>;

    /**
     * DELETE request for client
     * @param url url request
     * @param options - header and another info
     * @param encode - flag for set header x-www-form-urlencoded 
     */
    delete(url: string, options?: any, encode?: boolean): Promise<Response>;
}