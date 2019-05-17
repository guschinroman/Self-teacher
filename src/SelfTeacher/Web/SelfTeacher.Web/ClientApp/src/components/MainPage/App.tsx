import React = require('react');
import { renderToStaticMarkup } from 'react-dom/server';
import { Provider } from 'react-inversify';
import { LocalizeContextProps, withLocalize, InitializeOptions } from 'react-localize-redux';
import { connect } from 'react-redux';
import { HashRouter, Route } from 'react-router-dom';
import { AnyAction } from 'redux';
import { ThunkDispatch } from 'redux-thunk';

import { ClearAlertAction } from '../../actions';
import LanguageToggle from '../Common/languageSelector';
import { PrivateRoute } from '../Common/PrivateRoute';
import { HomePage } from '../HomePage/HomePage';
import LoginPage from '../LoginPage/LoginPage';
import { RegisterPage } from '../RegisterPage';
import { HistoryService } from './../../helpers/history';
import { AppContainer } from './../../services/ioc/container';
import { ConstStringsService } from './../../services/common/constString.service';

type State = {
    alert: any
}

type Props  = LocalizeContextProps & {
    alertClear: () => { type: string, message: string },
    alert: any
}

class App extends React.Component<Props, State> {

    constructor(props: Props) {
        super(props);

        const languages = ["en", "ru"];

        const defaultLanguage = localStorage.getItem(ConstStringsService.LANGUAGE_LOCALSTORAGE) || languages[0];

        let languageOptions: InitializeOptions = {
            renderToStaticMarkup: renderToStaticMarkup,
            defaultLanguage: defaultLanguage
        };

        this.props.initialize({
            languages: languages,
            translation: {},
            options: languageOptions
        });

        HistoryService.history.listen((location, action) => {
            this.props.alertClear();
        });
    }

    componentDidUpdate(prevProps: Props) {
        const prevLangCode = prevProps.activeLanguage && prevProps.activeLanguage.code;
        const curLangCode = this.props.activeLanguage && this.props.activeLanguage.code;
        const hasLanguageChanged = prevLangCode !== curLangCode;
        if (hasLanguageChanged) {
            localStorage.setItem(ConstStringsService.LANGUAGE_LOCALSTORAGE, curLangCode);
        }
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
                            <LanguageToggle langProps={this.props}>
                            </LanguageToggle>
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

const connectedApp = withLocalize(connect(
    mapStateToProps,
    mapDispatchToProps)(App));

export { connectedApp as App }; 