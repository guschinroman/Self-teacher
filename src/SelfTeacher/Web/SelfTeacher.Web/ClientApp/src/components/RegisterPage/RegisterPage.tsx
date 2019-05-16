import React = require('react');
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { AnyAction } from 'redux';
import { ThunkDispatch } from 'redux-thunk';

import { UserActionCreator } from '../../actions';
import { UserDto } from '../../models/UserDto';
import { AppContainer } from '../../services/ioc/container';

type State = {
    user: UserDto,
    submitted: boolean
};

type Props = {
    register: (user: UserDto) => void,
    registering: boolean
}

class RegisterPage extends React.Component<Props, State> {

    constructor(props: Props) {
        super(props);

        this.state = {
            user: {
                FirstName: '',
                LastName: '',
                Username: '',
                Password: ''
            },
            submitted: false
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
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

    render() {
        const { registering } = this.props;
        const { user, submitted } = this.state;
        return (
            <div className="col-md-6 col-md-offset-3">
                <h2>Register</h2>
                <form name="form" onSubmit={this.handleSubmit}>
                    <div className={'form-group' + (submitted && !user.FirstName ? ' has-error' : '')}>
                        <label htmlFor="FirstName">First Name</label>
                        <input type="text" className="form-control" name="FirstName" value={user.FirstName} onChange={this.handleChange} />
                        {submitted && !user.FirstName &&
                            <div className="help-block">First Name is required</div>
                        }
                    </div>
                    <div className={'form-group' + (submitted && !user.LastName ? ' has-error' : '')}>
                        <label htmlFor="LastName">Last Name</label>
                        <input type="text" className="form-control" name="LastName" value={user.LastName} onChange={this.handleChange} />
                        {submitted && !user.LastName &&
                            <div className="help-block">Last Name is required</div>
                        }
                    </div>
                    <div className={'form-group' + (submitted && !user.Username ? ' has-error' : '')}>
                        <label htmlFor="Username">Username</label>
                        <input type="text" className="form-control" name="Username" value={user.Username} onChange={this.handleChange} />
                        {submitted && !user.Username &&
                            <div className="help-block">Username is required</div>
                        }
                    </div>
                    <div className={'form-group' + (submitted && !user.Password ? ' has-error' : '')}>
                        <label htmlFor="Password">Password</label>
                        <input type="Password" className="form-control" name="Password" value={user.Password} onChange={this.handleChange} />
                        {submitted && !user.Password &&
                            <div className="help-block">Password is required</div>
                        }
                    </div>
                    <div className="form-group">
                        <button className="btn btn-primary">Register</button>
                        {registering &&
                            <img src="data:image/gif;base64,R0lGODlhEAAQAPIAAP///wAAAMLCwkJCQgAAAGJiYoKCgpKSkiH/C05FVFNDQVBFMi4wAwEAAAAh/hpDcmVhdGVkIHdpdGggYWpheGxvYWQuaW5mbwAh+QQJCgAAACwAAAAAEAAQAAADMwi63P4wyklrE2MIOggZnAdOmGYJRbExwroUmcG2LmDEwnHQLVsYOd2mBzkYDAdKa+dIAAAh+QQJCgAAACwAAAAAEAAQAAADNAi63P5OjCEgG4QMu7DmikRxQlFUYDEZIGBMRVsaqHwctXXf7WEYB4Ag1xjihkMZsiUkKhIAIfkECQoAAAAsAAAAABAAEAAAAzYIujIjK8pByJDMlFYvBoVjHA70GU7xSUJhmKtwHPAKzLO9HMaoKwJZ7Rf8AYPDDzKpZBqfvwQAIfkECQoAAAAsAAAAABAAEAAAAzMIumIlK8oyhpHsnFZfhYumCYUhDAQxRIdhHBGqRoKw0R8DYlJd8z0fMDgsGo/IpHI5TAAAIfkECQoAAAAsAAAAABAAEAAAAzIIunInK0rnZBTwGPNMgQwmdsNgXGJUlIWEuR5oWUIpz8pAEAMe6TwfwyYsGo/IpFKSAAAh+QQJCgAAACwAAAAAEAAQAAADMwi6IMKQORfjdOe82p4wGccc4CEuQradylesojEMBgsUc2G7sDX3lQGBMLAJibufbSlKAAAh+QQJCgAAACwAAAAAEAAQAAADMgi63P7wCRHZnFVdmgHu2nFwlWCI3WGc3TSWhUFGxTAUkGCbtgENBMJAEJsxgMLWzpEAACH5BAkKAAAALAAAAAAQABAAAAMyCLrc/jDKSatlQtScKdceCAjDII7HcQ4EMTCpyrCuUBjCYRgHVtqlAiB1YhiCnlsRkAAAOwAAAAAAAAAAAA==" />
                        }
                        <Link to="/login" className="btn btn-link">Cancel</Link>
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
    const userActionCreator: UserActionCreator = AppContainer.get<UserActionCreator>("user-action-creator");
    return {
        register: (user: UserDto) => dispatch(userActionCreator.register(user))
    }
}

const connectedRegisterPage = connect(
    mapStateToProps,
    mapDispatchToProps)(RegisterPage);

export { connectedRegisterPage as RegisterPage };