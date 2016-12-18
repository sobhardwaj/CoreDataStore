/* tslint:disable:no-unused-variable */
System.register(['@angular/core/testing', './menu.service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var testing_1, menu_service_1;
    return {
        setters:[
            function (testing_1_1) {
                testing_1 = testing_1_1;
            },
            function (menu_service_1_1) {
                menu_service_1 = menu_service_1_1;
            }],
        execute: function() {
            describe('Service: Menu', function () {
                beforeEach(function () {
                    testing_1.TestBed.configureTestingModule({
                        providers: [menu_service_1.MenuService]
                    });
                });
                it('should ...', testing_1.inject([menu_service_1.MenuService], function (service) {
                    expect(service).toBeTruthy();
                }));
            });
        }
    }
});
