"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
Object.defineProperty(exports, "__esModule", { value: true });
var _1 = require(".");
var api_path_service_1 = require("./communication/api-path.service");
var react_inversify_1 = require("react-inversify");
var UserService = /** @class */ (function () {
    function UserService(authHttp) {
        this.authHttp = authHttp;
        this._authHttp = authHttp;
    }
    /**
     * login method user service
     * @param username - login of user
     * @param password - password of user
     * @returns Promise after request and adding to local storage
     */
    UserService.prototype.login = function (username, password) {
        return __awaiter(this, void 0, void 0, function () {
            var responce, user;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this._authHttp.post(api_path_service_1.ApiPathService.authenticationPath(), JSON.stringify({ username: username, password: password }))];
                    case 1:
                        responce = _a.sent();
                        return [4 /*yield*/, responce.json()];
                    case 2:
                        user = _a.sent();
                        localStorage.setItem(_1.ConstStringsService.USER_LOCALSTORAGE, JSON.stringify(user));
                        return [2 /*return*/];
                }
            });
        });
    };
    /**
     * Logout function for remove user info from local storage
     */
    UserService.prototype.logout = function () {
        localStorage.removeItem(_1.ConstStringsService.USER_LOCALSTORAGE);
    };
    /**
     * Register user in system by user info
     */
    UserService.prototype.register = function (user) {
        return __awaiter(this, void 0, void 0, function () {
            var responce;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this._authHttp.post(api_path_service_1.ApiPathService.registrationPath(), JSON.stringify(user))];
                    case 1:
                        responce = _a.sent();
                        return [2 /*return*/, responce.json()];
                }
            });
        });
    };
    /**
     * Method for getting all users in system
     * @returns Promise with all users in system
     */
    UserService.prototype.getAll = function () {
        return __awaiter(this, void 0, void 0, function () {
            var responce;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this._authHttp.get(api_path_service_1.ApiPathService.getUsersListPath())];
                    case 1:
                        responce = _a.sent();
                        return [2 /*return*/, responce.json()];
                }
            });
        });
    };
    /**
     * Method for getting user by ID
     * @param id - id of user
     * @returns Promise with User information
     */
    UserService.prototype.getById = function (id) {
        return __awaiter(this, void 0, void 0, function () {
            var responce;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this._authHttp.get(api_path_service_1.ApiPathService.getUserById(id))];
                    case 1:
                        responce = _a.sent();
                        return [2 /*return*/, responce.json()];
                }
            });
        });
    };
    /**
     * Method for update user information
     * @param User - UserDto for update
     * @returns Promise request for update
     */
    UserService.prototype.update = function (user) {
        return __awaiter(this, void 0, void 0, function () {
            var responce;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this._authHttp.post(api_path_service_1.ApiPathService.updateUserByID(user), JSON.stringify(user))];
                    case 1:
                        responce = _a.sent();
                        return [2 /*return*/, responce.json()];
                }
            });
        });
    };
    /**
     *
     * @param id - id of user for deleting
     * @returns Promise request of deleting user
     */
    UserService.prototype.delete = function (id) {
        return __awaiter(this, void 0, void 0, function () {
            var responce;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this._authHttp.delete(api_path_service_1.ApiPathService.deleteUserById(id))];
                    case 1:
                        responce = _a.sent();
                        return [2 /*return*/, responce.json()];
                }
            });
        });
    };
    UserService = __decorate([
        __param(0, react_inversify_1.inject("authenticate-http"))
    ], UserService);
    return UserService;
}());
exports.UserService = UserService;
//# sourceMappingURL=user.service.js.map