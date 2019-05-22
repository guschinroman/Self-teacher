import * as React from "react"
import {Redirect, Route, RouteComponentProps, RouteProps} from "react-router-dom"
import { UserService } from "../../services";
import { Container } from 'typescript-ioc';
import { IUserService } from "../../services/interfaces/iuser.service";

type RouteComponent = React.StatelessComponent<RouteComponentProps<{}>> | React.ComponentClass<any>

export const PrivateRoute: React.StatelessComponent<RouteProps> = ({component, ...rest}) => {
  const renderFn = (Component?: any) => (props: RouteProps) => {
    if (!Component) {
      return null
    }

    const userService: IUserService = Container.get(IUserService);

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