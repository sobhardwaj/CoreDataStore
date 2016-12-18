System.register(['@angular/core', './userblock.service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, userblock_service_1;
    var UserblockComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (userblock_service_1_1) {
                userblock_service_1 = userblock_service_1_1;
            }],
        execute: function() {
            UserblockComponent = (function () {
                function UserblockComponent(userblockService) {
                    this.userblockService = userblockService;
                    this.user = {
                        picture: 'img/user/01.jpg'
                    };
                }
                UserblockComponent.prototype.ngOnInit = function () { };
                UserblockComponent.prototype.userBlockIsVisible = function () {
                    return this.userblockService.getVisibility();
                };
                UserblockComponent = __decorate([
                    core_1.Component({
                        selector: 'app-userblock',
                        templateUrl: 'app/layout/sidebar/userblock/userblock.component.html'
                    }), 
                    __metadata('design:paramtypes', [userblock_service_1.UserblockService])
                ], UserblockComponent);
                return UserblockComponent;
            }());
            exports_1("UserblockComponent", UserblockComponent);
        }
    }
});
