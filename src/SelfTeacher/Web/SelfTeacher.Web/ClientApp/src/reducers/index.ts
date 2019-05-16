import { combineReducers } from 'redux';

import { authentication } from './authentication.reducer';
import { registration } from './registration.reducer';
import { alert } from './alert.reducer';

export const reducer = combineReducers({
  authentication,
  registration,
  alert
});
