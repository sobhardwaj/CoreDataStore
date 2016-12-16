System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    // https://angular.io/styleguide#!#04-12
    function throwIfAlreadyLoaded(parentModule, moduleName) {
        if (parentModule) {
            throw new Error(moduleName + " has already been loaded. Import Core modules in the AppModule only.");
        }
    }
    exports_1("throwIfAlreadyLoaded", throwIfAlreadyLoaded);
    return {
        setters:[],
        execute: function() {
        }
    }
});
