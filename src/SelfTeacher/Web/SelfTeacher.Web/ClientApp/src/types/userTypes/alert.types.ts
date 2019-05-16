import { AlertConstants } from '../../constrants';

export interface AlertSuccess {
    type:  typeof AlertConstants.SUCCESS
    message: string
}

export interface AlertError {
    type: typeof AlertConstants.ERROR
    error: any
}

export interface AlertClear {
    type: typeof AlertConstants.CLEAR
    message: string
}

export type AlertActionsTypes = AlertSuccess | AlertError | AlertClear;