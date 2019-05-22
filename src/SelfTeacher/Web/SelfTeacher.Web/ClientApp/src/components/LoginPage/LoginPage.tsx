import React = require('react');
import CssBaseline from '@material-ui/core/CssBaseline';
import { LocalizeContextProps, Translate, withLocalize } from 'react-localize-redux';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Link from '@material-ui/core/Link';
import { AnyAction } from 'redux';
import { ThunkDispatch } from 'redux-thunk';

import * as loginPageTranslation from '../../../static/translations/loginPage.json';

import { UserActionCreator } from '../../actions';
import { Typography, FormControl, InputLabel, Input, Button, Paper, Avatar, Grid } from '@material-ui/core';
import { Inject, Container } from 'typescript-ioc';
import { connect } from 'react-redux';
import { IAccountService } from '../../services/interfaces/iaccount.service';
import { IAuthenticateHttp } from '../../services/communication/iauthenticate-http';
import { IUserService } from '../../services/interfaces/iuser.service';

type Props = LocalizeContextProps & {
    loggingIn: Boolean,
    logout: () => { type: string },
    login: (username: string, password: string) => void
}
type State = {
    username: string,
    password: string,
    submitted: boolean
    link: string,
}

class LoginPage extends React.Component<Props, State> {
    @Inject
    private readonly _accountService: IAccountService;

    constructor(props: Props) {
        super(props)

        this.props.addTranslation(loginPageTranslation);

        // reset login status
        props.logout();

        this.state = {
            username: '',
            password: '',
            submitted: false,
            link: ''
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.goToVkAuth = this.goToVkAuth.bind(this);
    }

    async componentDidMount() {
        if (!this.state.link) {
            const link = await this._accountService.GetVkAuthLink();
            const test = link;
            this.setState({...this.state, link: link });
        }
    }

    goToVkAuth(e: React.MouseEvent) {
        location.href = this.state.link;
    }

    handleChange(e: React.ChangeEvent<HTMLInputElement>) {
        const { name, value } = e.target;
        this.setState({...this.state, [name]: value });
    }

    handleSubmit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();

        this.setState({...this.state, submitted: true });
        const { username, password } = this.state;
        if (username && password) {
            this.props.login(username, password);
        }
    }

    render() {
        const { username, password, submitted } = this.state;
        return (
            <main className="login-container">
                <CssBaseline />
                <Paper className="login-container__paper">
                    <Avatar className="login-container__avatar">
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        <Translate id="LoginPage.Text.Login" />
                    </Typography>
                    <form name="form" onSubmit={this.handleSubmit} className="login-container__form">
                        <FormControl margin="normal" required fullWidth>
                            <InputLabel htmlFor="username"> <Translate id="LoginPage.Fields.Username" /></InputLabel>
                            <Input id="username" name="username" value={username} onChange={this.handleChange} autoFocus />
                        </FormControl>
                        <FormControl margin="normal" required fullWidth>
                            <InputLabel htmlFor="password"><Translate id="LoginPage.Fields.Password" /></InputLabel>
                            <Input type="password" name="password" value={password} onChange={this.handleChange} />
                        </FormControl>
                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            color="primary"
                            className="login-container__button">
                                <Translate id="LoginPage.Text.Login" />
                        </Button>
                        <FormControl margin="normal" fullWidth>
                            <Link align="center" href="#/register" className="login-container__link" color="primary">
                                <Translate id="LoginPage.Text.Register" />
                            </Link>
                        </FormControl>
                    </form>
                    <Grid container className="login-container__social-buttons-container" spacing={16}>
                        <Grid item xs={12}>
                            <Grid container className="login-container__social-buttons-container__element-container" justify="center" >
                                <Grid key="vk" item>
                                    <Button
                                        onClick={this.goToVkAuth}
                                        type="button"
                                        fullWidth
                                        variant="contained"
                                        color="primary"
                                        className="login-container__button">
                                            <Translate id="LoginPage.Text.Vk" />
                                    </Button>
                                </Grid>
                                <Grid key="twitter" item>
                                    <Button
                                        type="button"
                                        fullWidth
                                        variant="contained"
                                        color="primary"
                                        className="login-container__button">
                                            <Translate id="LoginPage.Text.Twitter" />
                                    </Button>
                                </Grid>
                                <Grid key="google" item>
                                    <Button
                                        type="button"
                                        fullWidth
                                        variant="contained"
                                        color="primary"
                                        className="login-container__button">
                                            <Translate id="LoginPage.Text.Google" />
                                    </Button>
                                </Grid>
                                <Grid key="facebook" item>
                                    <Button
                                        type="button"
                                        fullWidth
                                        variant="contained"
                                        color="primary"
                                        className="login-container__button">
                                            <Translate id="LoginPage.Text.Facebook" />
                                    </Button>
                                </Grid>
                            </Grid>
                        </Grid>
                    </Grid>
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
)(LoginPage));
