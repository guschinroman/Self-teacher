"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
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
var __1 = require("..");
var inversify_1 = require("inversify");
var AuthenticateHttp = /** @class */ (function () {
    function AuthenticateHttp() {
    }
    /**
     * GET request for client
     * @param url URL for request
     * @param options Headers for request
     * @param encode flag for set header x-www-form-urlencoded
     */
    AuthenticateHttp.prototype.get = function (url, options, encode) {
        if (encode === void 0) { encode = true; }
        return __awaiter(this, void 0, void 0, function () {
            var responce;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        options.method = 'GET';
                        return [4 /*yield*/, fetch("" + __1.ConfigApplication.apiUrl + url, this.addJwt(options, encode))];
                    case 1:
                        responce = _a.sent();
                        return [2 /*return*/, this.handleResponce(responce)];
                }
            });
        });
    };
    /**
     * POST request for client
     * @param url - url request
     * @param body - body information
     * @param options - Header and another info
     */
    AuthenticateHttp.prototype.post = function (url, body, options) {
        return __awaiter(this, void 0, void 0, function () {
            var responce;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        options = options || {};
                        options.method = 'POST';
                        options.headers = options.headers || new Headers();
                        options.headers.append('Content-type', 'application/json');
                        options.body = body;
                        return [4 /*yield*/, fetch("" + __1.ConfigApplication.apiUrl + url, this.addJwt(options))];
                    case 1:
                        responce = _a.sent();
                        return [2 /*return*/, this.handleResponce(responce)];
                }
            });
        });
    };
    /**
     * PUT request for client
     * @param url - url request
     * @param body - body information
     * @param options - header and another info
     */
    AuthenticateHttp.prototype.put = function (url, body, options) {
        return __awaiter(this, void 0, void 0, function () {
            var responce;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        options = options || {};
                        options.method = 'PUT';
                        options.headers = options.headers || new Headers();
                        options.headers.append('Content-type', 'application/json');
                        options.body = body;
                        return [4 /*yield*/, fetch("" + __1.ConfigApplication.apiUrl + url, this.addJwt(options))];
                    case 1:
                        responce = _a.sent();
                        return [2 /*return*/, this.handleResponce(responce)];
                }
            });
        });
    };
    /**
     * DELETE request for client
     * @param url url request
     * @param options - header and another info
     * @param encode - flag for set header x-www-form-urlencoded
     */
    AuthenticateHttp.prototype.delete = function (url, options, encode) {
        if (encode === void 0) { encode = true; }
        return __awaiter(this, void 0, void 0, function () {
            var responce;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        options.method = 'DELETE';
                        return [4 /*yield*/, fetch("" + __1.ConfigApplication.apiUrl + url, this.addJwt(options, encode))];
                    case 1:
                        responce = _a.sent();
                        return [2 /*return*/, this.handleResponce(responce)];
                }
            });
        });
    };
    /**
     * Method for adding auth token to request
     * @param options - headers for request
     * @param encode - flag for set header x-www-form-urlencoded
     */
    AuthenticateHttp.prototype.addJwt = function (options, encode) {
        if (encode === void 0) { encode = true; }
        // ensure request options and headers are not null
        options = options || {};
        options.headers = options.headers || new Headers();
        if (encode) {
            options.headers.append('Accept', 'x-www-form-urlencoded');
        }
        // add authorization header with jwt token
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser && currentUser.access_token) {
            options.headers.append('Authorization', 'Bearer ' + currentUser.access_token);
        }
        return options;
    };
    /**
     * Method for checking responce
     * @param responce Responce for server to check answer
     */
    AuthenticateHttp.prototype.handleResponce = function (responce) {
        return __awaiter(this, void 0, void 0, function () {
            var text, data, error;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, responce.text()];
                    case 1:
                        text = _a.sent();
                        data = text && JSON.parse(text);
                        if (!responce.ok) {
                            if (responce.status === 401) {
                                localStorage.removeItem(__1.ConstStringsService.USER_LOCALSTORAGE);
                                location.reload(true);
                            }
                        }
                        error = (data && data.message) || responce.statusText;
                        return [2 /*return*/, Promise.reject(error)];
                }
            });
        });
    };
    AuthenticateHttp = __decorate([
        inversify_1.injectable()
    ], AuthenticateHttp);
    return AuthenticateHttp;
}());
exports.AuthenticateHttp = AuthenticateHttp;
//# sourceMappingURL=authenticate-http.js.map