"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var SessionService = (function () {
    function SessionService() {
    }
    SessionService.prototype.get = function (key) {
        var record;
        record = JSON.parse(sessionStorage.getItem(key));
        if (!record) {
            return null;
        }
        return new Date().getTime() < record.timestamp && JSON.parse(record.value);
    };
    ;
    SessionService.prototype.set = function (key, val, time) {
        var expire, record;
        expire = time ? (time * 60 * 1000) : 864000;
        record = {
            value: JSON.stringify(val),
            timestamp: new Date().getTime() + expire
        };
        sessionStorage.setItem(key, JSON.stringify(record));
        return val;
    };
    ;
    SessionService.prototype.unset = function (key) {
        return sessionStorage.removeItem(key);
    };
    return SessionService;
}());
exports.SessionService = SessionService;
;
