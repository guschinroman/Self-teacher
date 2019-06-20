import { EUserAccountState } from './EUserAccountState';


export class AuthenticateDto  { 
	public UserId?: string = undefined;
	public Token?: string = undefined;
	public AccessTokenLiveTime?: string = undefined;
	public State?: EUserAccountState = undefined;
}
 
