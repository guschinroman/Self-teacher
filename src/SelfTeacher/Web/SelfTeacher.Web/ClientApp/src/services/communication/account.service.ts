import { IAccountService } from "../interfaces/iaccount.service";
import { IAuthenticateHttp } from "./iauthenticate-http";
import { ApiPathService } from "./api-path.service";
import { Inject } from '../../../node_modules/typescript-ioc';

export class AccountService extends IAccountService {

    @Inject
    private readonly _authHttp: IAuthenticateHttp;

    async GetVkAuthLink(): Promise<string> {
        
        const responce = await this._authHttp.get(ApiPathService.getVkAuthPath());

        return await responce.text();
    }
}
