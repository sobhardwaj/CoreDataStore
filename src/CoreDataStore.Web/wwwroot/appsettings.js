"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var AppSettings = /** @class */ (function () {
    function AppSettings() {
    }
    Object.defineProperty(AppSettings, "build", {
        get: function () {
            return localStorage.getItem("build") || "local";
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AppSettings, "buildId", {
        get: function () {
            return localStorage.getItem("BuildId") || "1.0.0";
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AppSettings, "ng2ENV", {
        get: function () {
            return localStorage.getItem("ng2ENV") || "";
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AppSettings, "ApiEndpoint", {
        get: function () {
            return localStorage.getItem("ApiEndpoint") || "";
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AppSettings, "ApiMaps", {
        get: function () {
            return localStorage.getItem("ApiMaps") || "";
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AppSettings, "ApiLocation", {
        get: function () {
            return localStorage.getItem("ApiLocation") || "";
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AppSettings, "ApiReports", {
        get: function () {
            return localStorage.getItem("ApiReport") || "";
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
//# sourceMappingURL=appsettings.js.map