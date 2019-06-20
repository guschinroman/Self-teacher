import { IAccountService } from "../interfaces/iaccount.service";
import { IAuthenticateHttp } from "./iauthenticate-http";
import { ApiPathService } from "./api-path.service";
import { Inject } from '../../../node_modules/typescript-ioc';
import { AuthenticateDto } from "../../models/AuthenticateDto";

export class AccountService extends IAccountService {

    @Inject
    private readonly _authHttp: IAuthenticateHttp;

    async GetVkAuthLink(): Promise<string> {
        
        const responce = await this._authHttp.get(ApiPathService.getVkAuthPath());

        return await responce.text();
    }

    async GetAuthenticationDtoByAccessToken(accessToken: string): Promise<AuthenticateDto> {
        
        const responce = await this._authHttp.get(ApiPathService.getUserByAccessCode(accessToken));

        return await responce.json();
    }
}
