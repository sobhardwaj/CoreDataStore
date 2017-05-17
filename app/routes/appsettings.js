"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var AppSettings = (function () {
    function AppSettings() {
    }
    Object.defineProperty(AppSettings, "build", {
        get: function () {
            return "local";
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AppSettings, "ng2ENV", {
        get: function () {
            return "Dev";
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AppSettings, "ApiEndpoint", {
        get: function () {
            return "http://informationcart.eastus2.cloudapp.azure.com:80/api/";
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AppSettings, "ApiMaps", {
        get: function () {
            return "http://informationcart.eastus2.cloudapp.azure.com:82/api/";
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AppSettings, "ApiReports", {
        get: function () {
            return "/api/reports";
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AppSettings, "ApiAttraction", {
        get: function () {
            return "/api/attraction";
        },
        enumerable: true,
        configurable: true
    });
    return AppSettings;
}());
exports.AppSettings = AppSettings;
