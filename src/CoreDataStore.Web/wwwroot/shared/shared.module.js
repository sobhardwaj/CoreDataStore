"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var router_1 = require("@angular/router");
var http_1 = require("@angular/http");
var animations_1 = require("@angular/platform-browser/animations");
var ng2_toastr_1 = require("ng2-toastr/ng2-toastr");
// import { CollapseModule } from 'ngx-bootstrap/collapse';
// import { DatepickerModule } from 'ngx-bootstrap/datepicker';
// import { PaginationModule } from 'ngx-bootstrap/pagination';
var ngx_bootstrap_1 = require("ngx-bootstrap");
var colors_service_1 = require("./colors/colors.service");
var session_1 = require("./services/session");
var checkall_1 = require("./directives/checkall");
var now_1 = require("./directives/now");
var scrollable_1 = require("./directives/scrollable");
var capitalize_1 = require("./pipes/capitalize");
var trim_1 = require("./pipes/trim");
// https://angular.io/styleguide#!#04-10
var SharedModule = /** @class */ (function () {
    function SharedModule() {
    }
    SharedModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule,
                forms_1.FormsModule,
                forms_1.ReactiveFormsModule,
                animations_1.BrowserAnimationsModule,
                ngx_bootstrap_1.DatepickerModule.forRoot(),
                ngx_bootstrap_1.PaginationModule.forRoot(),
                ngx_bootstrap_1.CollapseModule.forRoot(),
                ngx_bootstrap_1.TabsModule.forRoot(),
                ng2_toastr_1.ToastModule.forRoot()
            ],
            providers: [
                colors_service_1.ColorsService,
                session_1.SessionService
            ],
            declarations: [
                trim_1.TrimPipe,
                capitalize_1.CapitalizePipe,
                checkall_1.CheckallDirective,
                now_1.NowDirective,
                scrollable_1.ScrollableDirective
            ],
            exports: [
                common_1.CommonModule,
                forms_1.FormsModule,
                forms_1.ReactiveFormsModule,
                http_1.HttpModule,
                router_1.RouterModule,
                ngx_bootstrap_1.DatepickerModule,
                ngx_bootstrap_1.PaginationModule,
                ngx_bootstrap_1.CollapseModule,
                ngx_bootstrap_1.TabsModule,
                ng2_toastr_1.ToastModule,
                trim_1.TrimPipe,
                capitalize_1.CapitalizePipe,
                checkall_1.CheckallDirective,
                now_1.NowDirective,
                scrollable_1.ScrollableDirective
            ]
        })
    ], SharedModule);
    return SharedModule;
}());
exports.SharedModule = SharedModule;
//# sourceMappingURL=shared.module.js.map