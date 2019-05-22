import { ConstStringsService, ConfigApplication } from '..';
import { IAuthenticateHttp } from './iauthenticate-http';

export class AuthenticateHttp extends  IAuthenticateHttp {

/**
 * GET request for client
 * @param url URL for request
 * @param options Headers for request
 * @param encode flag for set header x-www-form-urlencoded
 */
    public async get(url: string, options?: any, encode = true): Promise<Response> {

        options = options || {};
        options.method = 'GET';
    
        const responce = await fetch(`${url}`, this.addJwt(options, encode));
        return this.handleResponce(responce);
    }

    /**
     * POST request for client
     * @param url - url request
     * @param body - body information
     * @param options - Header and another info
     */
    public async post(url: string, body: string,  options?: any): Promise<Response> {

        options = options || {};
        options.method = 'POST';

        options.headers = options.headers || new Headers();
        options.headers.append('Content-type', 'application/json');
        options.body = body;
        const responce = await fetch(`${url}`, this.addJwt(options));
        return this.handleResponce(responce);
    }

    /**
     * PUT request for client
     * @param url - url request
     * @param body - body information
     * @param options - header and another info
     */
    public async put(url: string, body: string, options?: any): Promise<Response> {
        options = options || {};
        options.method = 'PUT';

        options.headers = options.headers || new Headers();
        options.headers.append('Content-type', 'application/json');
        options.body = body;
        const responce = await fetch(`${url}`, this.addJwt(options));
        return this.handleResponce(responce);
    }

    /**
     * DELETE request for client
     * @param url url request
     * @param options - header and another info
     * @param encode - flag for set header x-www-form-urlencoded 
     */
    public async delete(url: string, options?: any, encode = true): Promise<Response> {

        options = options || {};
        options.method = 'DELETE';
    
        const responce = await fetch(`${url}`, this.addJwt(options, encode));
        return this.handleResponce(responce);
    }


    /**
     * Method for adding auth token to request
     * @param options - headers for request
     * @param encode - flag for set header x-www-form-urlencoded
     */
    private addJwt(options: any, encode: boolean = true): any {
        // ensure request options and headers are not null
        options = options || {};
        options.headers = options.headers || new Headers();
        if (encode) {
          options.headers.append('Accept', 'x-www-form-urlencoded');
        }

        // add authorization header with jwt token
        const currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser && currentUser.access_token) {
            options.headers.append('Authorization', 'Bearer ' + currentUser.access_token);
        }

        return options;
    }
        
    /**
     * Method for checking responce
     * @param responce Responce for server to check answer
     */
    private async handleResponce(responce: Response): Promise<Response> {

        if (!responce.ok) {
            if (responce.status === 401) {
                const text = await responce.text();
                let data;
                try {
                    data = text && JSON.parse(text);
                } catch(ex) {
                    data = text && text;
                }
                localStorage.removeItem(ConstStringsService.USER_LOCALSTORAGE);
                location.reload(true);
                const error = (data && data.message) || responce.statusText;
                return Promise.reject(error);
            }
        } else {
            return Promise.resolve(responce);
        }
    }
}