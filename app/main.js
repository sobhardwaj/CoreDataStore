System.register(['@angular/platform-browser-dynamic', './index'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var platform_browser_dynamic_1, index_1;
    return {
        setters:[
            function (platform_browser_dynamic_1_1) {
                platform_browser_dynamic_1 = platform_browser_dynamic_1_1;
            },
            function (index_1_1) {
                index_1 = index_1_1;
            }],
        execute: function() {
            // enableProdMode();
            platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(index_1.AppModule);
        }
    }
});
