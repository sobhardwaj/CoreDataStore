System.register(['@angular/core', 'moment'], function(exports_1, context_1) {
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
    var core_1, moment;
    var NowDirective;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (moment_1) {
                moment = moment_1;
            }],
        execute: function() {
            NowDirective = (function () {
                function NowDirective(element) {
                    this.element = element;
                }
                NowDirective.prototype.ngOnInit = function () {
                    this.updateTime();
                    this.intervalId = setInterval(this.updateTime.bind(this), 1000);
                };
                NowDirective.prototype.updateTime = function () {
                    var dt = moment().format(this.format);
                    this.element.nativeElement.innerHTML = dt;
                };
                NowDirective.prototype.ngOnDestroy = function () {
                    clearInterval(this.intervalId);
                };
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Object)
                ], NowDirective.prototype, "format", void 0);
                NowDirective = __decorate([
                    core_1.Directive({
                        selector: '[now]'
                    }), 
                    __metadata('design:paramtypes', [core_1.ElementRef])
                ], NowDirective);
                return NowDirective;
            }());
            exports_1("NowDirective", NowDirective);
        }
    }
});
