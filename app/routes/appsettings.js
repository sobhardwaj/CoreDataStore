System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var AppSettings;
    return {
        setters:[],
        execute: function() {
            AppSettings = (function () {
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
                        return null;
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
                        return "http://informationcart.eastus2.cloudapp.azure.com:84/api/";
                    },
                    enumerable: true,
                    configurable: true
                });
                Object.defineProperty(AppSettings, "ApiAttraction", {
                    get: function () {
                        return "http://informationcart.eastus2.cloudapp.azure.com:83/api/";
                    },
                    enumerable: true,
                    configurable: true
                });
                return AppSettings;
            }());
            exports_1("AppSettings", AppSettings);
        }
    }
});
