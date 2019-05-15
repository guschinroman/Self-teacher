import { AlertConstants } from '../../constrants';

interface AlertSuccess {
    type:  typeof AlertConstants.SUCCESS
    message: string
}

interface AlertError {
    type: typeof AlertConstants.ERROR
    error: any
}

interface AlertClear {
    type: typeof AlertConstants.CLEAR
    message: string
}

export type AlertActionsTypes = AlertSuccess | AlertError | AlertClear;