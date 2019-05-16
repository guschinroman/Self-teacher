import { connect, Store } from 'react-redux';
import React = require('react');
import { Link } from 'react-router-dom';
import { UserDto } from '../../models/UserDto';

type Props = {
    user: UserDto
}

type State = {
    user: UserDto
}

class HomePage extends React.Component<Props, State> {
    componentDidMount() {
    }

    render() {
        const { user } = this.props;
        return (
            <div className="col-md-6 col-md-offset-3">
                <h1>Hi {user.FirstName}!</h1>
                <p>You're logged in with React!!</p>
                <h3>All registered users:</h3>
                <p>
                    <Link to="/login">Logout</Link>
                </p>
            </div>
        );
    }
}

function mapStateToProps(state: any) {
    const { authentication } = state;
    const { user } = authentication;
    return {
        user
    };
}

const connectedHomePage = connect(mapStateToProps)(HomePage);
export { connectedHomePage as HomePage };