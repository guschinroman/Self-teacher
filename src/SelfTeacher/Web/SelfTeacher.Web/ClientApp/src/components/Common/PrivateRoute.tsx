import * as React from "react"
import {Redirect, Route, RouteComponentProps, RouteProps} from "react-router-dom"
import { UserService } from "../../services";
import { AppContainer } from "../../services/ioc/container";

type RouteComponent = React.StatelessComponent<RouteComponentProps<{}>> | React.ComponentClass<any>

export const PrivateRoute: React.StatelessComponent<RouteProps> = ({component, ...rest}) => {
  const renderFn = (Component?: any) => (props: RouteProps) => {
    if (!Component) {
      return null
    }

    const userService = AppContainer.get<UserService>("user-service");

    if (userService.IsLoginUser()) {
      return <Component {...props} />
    }

    const redirectProps = {
      to: {
        pathname: "/login",
        state: {from: props.location},
      },
    }

    return <Redirect {...redirectProps} />
  }

  return <Route {...rest} render={renderFn(component)} />
}