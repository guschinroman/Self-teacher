import React = require('react');
import CssBaseline from '@material-ui/core/CssBaseline';
import { LocalizeContextProps, Translate, withLocalize } from 'react-localize-redux';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import { AnyAction } from 'redux';
import { ThunkDispatch } from 'redux-thunk';

import * as vkConfirmPage from '../../../static/translations/vkConfirmPage.json';

import { UserActionCreator } from '../../actions';
import { Typography, FormControl, InputLabel, Input, Button, Paper, Avatar, Grid } from '@material-ui/core';
import { Inject, Container } from 'typescript-ioc';
import { connect } from 'react-redux';
import { IAccountService } from '../../services/interfaces/iaccount.service';
import { AuthenticateDto } from './../../models/AuthenticateDto';

type Props = LocalizeContextProps & {
    match: any
}
type State = {
    userInfo: AuthenticateDto,
    accessCode: string,
    email: string
}

class VkConfirmAuthentication extends React.Component<Props, State> {
    @Inject
    private readonly _accountService: IAccountService;

    constructor(props: Props) {
        super(props)

        this.props.addTranslation(vkConfirmPage);

        this.state = {
            userInfo:  {},
            accessCode: '',
            email: ''
        };
        
        const { accessToken } = this.props.match.params;
        this.setState({...this.state, ['accessCode']: accessToken});

        this._accountService.GetAuthenticationDtoByAccessToken(accessToken);

    }

    handleChange(e: React.ChangeEvent<HTMLInputElement>) {
        const { name, value } = e.target;
        this.setState({...this.state, [name]: value });
    }

    handleClick(e: React.MouseEvent<HTMLInputElement>) {
        const { email } = this.state;
        

    }

    render() {
        return (
            <main className="login-container">
                <CssBaseline />
                <Paper className="login-container__paper">
                    <Avatar className="login-container__avatar">
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        <Translate id="VkConfirmPage.Text.HeaderText" />
                    </Typography>
                    <Typography component="h2" variant="h5" align="center">
                        <Translate id="VkConfirmPage.Text.MainText" />
                    </Typography>
                    <form name="form" className="login-container__form">
                        <FormControl margin="normal" required fullWidth>
                            <InputLabel htmlFor="email"> <Translate id="VkConfirmPage.Fields.Email" /></InputLabel>
                            <Input id="email" name="email" onChange={this.handleChange} autoFocus />
                        </FormControl>
                        <Button
                            type="button"
                            fullWidth
                            variant="contained"
                            color="primary"
                            className="login-container__button"
                            onClick={this.handleClick}>
                                <Translate id="VkConfirmPage.Text.Register" />
                        </Button>
                    </form>
                </Paper>
            </main>
        );
    }
}

const mapStateToProps = (store: State) => {
    return {
    }
}
const mapDispatchToProps = (dispatch: ThunkDispatch<any, any, AnyAction>) => {
    const userActionCreator: UserActionCreator = Container.get(UserActionCreator);
    return {
        login: (username: string, password: string) => dispatch(userActionCreator.login(username, password)),
        logout: () => dispatch(userActionCreator.logout())
    }
}

export default withLocalize(connect(
    mapStateToProps,
    mapDispatchToProps
)(VkConfirmAuthentication));
