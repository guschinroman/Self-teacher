import { HashRouter, Route } from 'react-router-dom';
import { connect } from 'react-redux';

import { HomePage } from '../HomePage/HomePage';
import React = require('react');
import { HistoryService } from './../../helpers/history';
import LoginPage from '../LoginPage/LoginPage';
import { ThunkDispatch } from 'redux-thunk';
import { AnyAction } from 'redux';
import { RegisterPage } from '../RegisterPage';
import { ClearAlertAction } from '../../actions';
import { Container, Provider } from 'react-inversify';
import { AppContainer } from './../../services/ioc/container';
import { PrivateRoute } from '../Common/PrivateRoute';

type State = {
    alert: any
}

type Props = {
    alertClear: () => { type: string, message: string },
    alert: any
}

class App extends React.Component<Props, State> {

    constructor(props: Props) {
        super(props);


        HistoryService.history.listen((location, action) => {
            this.props.alertClear();
        });
    }

    render() {
        const { alert } = this.props;
        return (
            <Provider container={AppContainer}>
                <div className="jumbotron">
                    <div className="container">
                        <div className="col-sm-8 col-sm-offset-2">
                            {alert.message &&
                                <div className={`alert ${alert.type}`}>{alert.message}</div>
                            }
                            <HashRouter>
                                <div>
                                    <PrivateRoute exact path="/" component={HomePage} />
                                    <Route path="/login" component={LoginPage} />
                                    <Route path="/register" component={RegisterPage} />
                                </div>
                            </HashRouter>
                        </div>
                    </div>
                </div>
            </Provider>
        );
    }
}

const mapStateToProps = (state: State) => {
    const { alert } = state;
    return {
        alert
    };
};

const mapDispatchToProps = (dispatch: ThunkDispatch<any, any, AnyAction>) => {
    return {
        alertClear: () => dispatch(ClearAlertAction("clear"))
    };
};

const connectedApp = connect(
    mapStateToProps,
    mapDispatchToProps)(App);
export { connectedApp as App }; 