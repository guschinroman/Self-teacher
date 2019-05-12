import config from 'config';
import { constStringsService } from '../services';
import { authHaldler, authHeader } from '../helpers';

export const userService = {
    login,
    logout,
    getAll
};

function login(username, password) {

    const requestOptions = {
        method: 'POST',
        header: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password })
    };

    return fetch(`${config.apiUrl}/users/authenticate`, requestOptions)
        .then(handleResponce)
        .then(user => {
            localStorage.setItem(constStringsService.USER_LOCALSTORAGE);
            return user;
    });
}

function logout() {
    localStorage.removeItem(constStringsService.USER_LOCALSTORAGE);
}

function getAll() {
    const requestOptions = {
        method: 'GET',
        headers: authHeader()
    };

    return fetch(`${config.apiUrl}/users`, requestOptions)
        .then(handleResponce);
}

function getById() {
    const requestOptions = {
        method: 'GET',
        header: authHeader()
    };

    return fetch(`${config.apiUrl}/users/${id}`, requestOptions).then(handleResponce);
}

function update(user) {
    const requestOptions = {
        method: 'PUT',
        headers: { ...authHeader(), 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    };

    return fetch(`${config.apiUrl}/users/${user.id}`, requestOptions).then(handleResponce);
}

function _delete(id) {
    const requestOptions = {
        method: 'DELETE',
        headers: authHeader()
    };

    return fetch(`${config.apiUrl}/users/${id}`, requestOptions).then(handleResponce);
}

function handleResponce(responce) {
    return responce.text().then(text => {
        const data = text && JSON.parse(text);
        if (!responce.ok) {
            if (responce.status === 401) {
                logout();
                location.reload(true);
            }
        }

        const error = (data && data.message) || responce.statuText;
        return Promise.reject(error);
    });
}
