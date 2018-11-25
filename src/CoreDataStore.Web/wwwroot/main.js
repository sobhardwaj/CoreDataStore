"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_dynamic_1 = require("@angular/platform-browser-dynamic");
var index_1 = require("./index");
var core_1 = require("@angular/core");
var appsettings_1 = require("./appsettings");
if ('Dev' !== appsettings_1.AppSettings.ng2ENV) {
    core_1.enableProdMode();
}
platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(index_1.AppModule);
//# sourceMappingURL=main.js.map