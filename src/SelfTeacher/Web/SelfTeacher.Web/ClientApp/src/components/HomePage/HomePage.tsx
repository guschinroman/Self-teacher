import React = require('react');
import { LocalizeContextProps, Translate, withLocalize } from 'react-localize-redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import * as homePageTranslation from '../../../static/translations/homePage.json';

import { UserDto } from '../../models/UserDto';

type Props = LocalizeContextProps & {
    user: UserDto
}

type State = {
    user: UserDto
}

class HomePage extends React.Component<Props, State> {

    constructor(props: Props) {
        super(props);

        this.props.addTranslation(homePageTranslation);
    }

    componentDidMount() {
    }

    render() {
        const { user } = this.props;
        return (
            <div className="col-md-6 col-md-offset-3">
                <h1>
                    <Translate id="HomePage.Greetings.Hi" /> {user.FirstName}!
                </h1>
                <p>
                    <Translate id="HomePage.Greetings.YouAreLogged" />
                </p>
                <p>
                    <Link to="/login"> <Translate id="HomePage.Func.Logout" /> </Link>
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

const connectedHomePage = withLocalize(connect(mapStateToProps)(HomePage));
export { connectedHomePage as HomePage };
