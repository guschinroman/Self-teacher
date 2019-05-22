import React = require('react');
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { AnyAction } from 'redux';
import { ThunkDispatch } from 'redux-thunk';
import * as registerPageTranslation from '../../../static/translations/registerPage.json';

import { UserActionCreator } from '../../actions';
import { UserDto } from '../../models/UserDto';
import { LocalizeContextProps, Translate, withLocalize } from 'react-localize-redux';
import { Container } from 'typescript-ioc';

type State = {
    user: UserDto,
    submitted: boolean,
    passwordConfirm: string
};

type Props = LocalizeContextProps & {
    register: (user: UserDto) => void,
    registering: boolean
}

class RegisterPage extends React.Component<Props, State> {

    constructor(props: Props) {
        super(props);

        this.props.addTranslation(registerPageTranslation);

        this.state = {
            user: {
                FirstName: '',
                LastName: '',
                Username: '',
                Password: ''
            },
            passwordConfirm: '',
            submitted: false
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleConfirmPasswordChange = this.handleConfirmPasswordChange.bind(this);
    }

    handleChange(event: React.ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        const { user } = this.state;
        this.setState({
            user: {
                ...user,
                [name]: value
            }
        });
    }

    handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        this.setState({ submitted: true });
        const { user } = this.state;

        if (user.FirstName && user.LastName && user.Username && user.Password) {
            this.props.register(user)
        }
    }

    handleConfirmPasswordChange(event: React.ChangeEvent<HTMLInputElement>) {
        event.preventDefault();
        const { passwordConfirm } = this.state;
        this.setState({ passwordConfirm: event.target.value})
    }

    render() {
        const { registering } = this.props;
        const { user, submitted, passwordConfirm } = this.state;
        return (
            <div className="col-md-6 col-md-offset-3">
                <h2><Translate id="RegisterPage.Text.Register" /></h2>
                <form name="form" onSubmit={this.handleSubmit}>
                    <div className={'form-group' + (submitted && !user.FirstName ? ' has-error' : '')}>
                        <label htmlFor="FirstName"><Translate id="RegisterPage.Fields.Firstname" /></label>
                        <input type="text" className="form-control" name="FirstName" value={user.FirstName} onChange={this.handleChange} />
                        {submitted && !user.FirstName &&
                            <div className="help-block"> <Translate id="RegisterPage.Validation.FirstNameRequired" /> </div>
                        }
                    </div>
                    <div className={'form-group' + (submitted && !user.LastName ? ' has-error' : '')}>
                        <label htmlFor="LastName"><Translate id="RegisterPage.Fields.LastName" /></label>
                        <input type="text" className="form-control" name="LastName" value={user.LastName} onChange={this.handleChange} />
                        {submitted && !user.LastName &&
                            <div className="help-block"><Translate id="RegisterPage.Validation.LastNameRequired" /></div>
                        }
                    </div>
                    <div className={'form-group' + (submitted && !user.Username ? ' has-error' : '')}>
                        <label htmlFor="Username"><Translate id="RegisterPage.Fields.Username" /></label>
                        <input type="text" className="form-control" name="Username" value={user.Username} onChange={this.handleChange} />
                        {submitted && !user.Username &&
                            <div className="help-block"><Translate id="RegisterPage.Validation.UserNameRequired" /></div>
                        }
                    </div>
                    <div className={'form-group' + (submitted && !user.Password ? ' has-error' : '')}>
                        <label htmlFor="Password"><Translate id="RegisterPage.Fields.Password" /></label>
                        <input type="Password" className="form-control" name="Password" value={user.Password} onChange={this.handleChange} />
                        {submitted && !user.Password &&
                            <div className="help-block"><Translate id="RegisterPage.Validation.PasswordRequired" /></div>
                        }
                    </div>
                    <div className={'form-group' + (submitted && !user.Password ? ' has-error' : '')}>
                        <label htmlFor="Password"><Translate id="RegisterPage.Fields.Password" /></label>
                        <input type="Password" className="form-control" name="PasswordConfirm" value={passwordConfirm} onChange={this.handleConfirmPasswordChange} />
                        {submitted && user.Password && passwordConfirm && passwordConfirm !== user.Password &&
                            <div className="help-block"><Translate id="RegisterPage.Validation.PasswordMustBeEqual" /></div>
                        }
                    </div>
                    <div className={'form-group' + (submitted && !user.Email ? ' has-error' : '')}>
                        <label htmlFor="Email"><Translate id="RegisterPage.Fields.Email" /></label>
                        <input type="text" className="form-control" name="Email" value={user.Email} onChange={this.handleChange} />
                        {submitted && !user.Email &&
                            <div className="help-block"><Translate id="RegisterPage.Validation.EmailRequired" /></div>
                        }
                        {
                            submitted && user.Email && !user.Email.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i) &&
                                <div className="help-block"><Translate id="RegisterPage.Validation.EmailInUncorrect" /></div>
                        }
                    </div>
                    <div className="form-group">
                        <button className="btn btn-primary"><Translate id="RegisterPage.Text.RegisterButton" /></button>
                        {registering &&
                            <img src="data:image/gif;base64,R0lGODlhEAAQAPIAAP///wAAAMLCwkJCQgAAAGJiYoKCgpKSkiH/C05FVFNDQVBFMi4wAwEAAAAh/hpDcmVhdGVkIHdpdGggYWpheGxvYWQuaW5mbwAh+QQJCgAAACwAAAAAEAAQAAADMwi63P4wyklrE2MIOggZnAdOmGYJRbExwroUmcG2LmDEwnHQLVsYOd2mBzkYDAdKa+dIAAAh+QQJCgAAACwAAAAAEAAQAAADNAi63P5OjCEgG4QMu7DmikRxQlFUYDEZIGBMRVsaqHwctXXf7WEYB4Ag1xjihkMZsiUkKhIAIfkECQoAAAAsAAAAABAAEAAAAzYIujIjK8pByJDMlFYvBoVjHA70GU7xSUJhmKtwHPAKzLO9HMaoKwJZ7Rf8AYPDDzKpZBqfvwQAIfkECQoAAAAsAAAAABAAEAAAAzMIumIlK8oyhpHsnFZfhYumCYUhDAQxRIdhHBGqRoKw0R8DYlJd8z0fMDgsGo/IpHI5TAAAIfkECQoAAAAsAAAAABAAEAAAAzIIunInK0rnZBTwGPNMgQwmdsNgXGJUlIWEuR5oWUIpz8pAEAMe6TwfwyYsGo/IpFKSAAAh+QQJCgAAACwAAAAAEAAQAAADMwi6IMKQORfjdOe82p4wGccc4CEuQradylesojEMBgsUc2G7sDX3lQGBMLAJibufbSlKAAAh+QQJCgAAACwAAAAAEAAQAAADMgi63P7wCRHZnFVdmgHu2nFwlWCI3WGc3TSWhUFGxTAUkGCbtgENBMJAEJsxgMLWzpEAACH5BAkKAAAALAAAAAAQABAAAAMyCLrc/jDKSatlQtScKdceCAjDII7HcQ4EMTCpyrCuUBjCYRgHVtqlAiB1YhiCnlsRkAAAOwAAAAAAAAAAAA==" />
                        }
                        <Link to="/login" className="btn btn-link"><Translate id="RegisterPage.Text.Cancel" /></Link>
                    </div>
                </form>
            </div>
        );
    }
}

const mapStateToProps = (state: State) => {
    return {
        registering: false
    }
}

const mapDispatchToProps = (dispatch: ThunkDispatch<any, any, AnyAction>) => {
    const userActionCreator: UserActionCreator = Container.get(UserActionCreator);
    return {
        register: (user: UserDto) => dispatch(userActionCreator.register(user))
    }
}

const connectedRegisterPage = withLocalize(connect(
    mapStateToProps,
    mapDispatchToProps)(RegisterPage));

export { connectedRegisterPage as RegisterPage };