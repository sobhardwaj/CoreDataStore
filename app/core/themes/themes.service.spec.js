/* tslint:disable:no-unused-variable */
System.register(['@angular/core/testing', './themes.service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var testing_1, themes_service_1;
    return {
        setters:[
            function (testing_1_1) {
                testing_1 = testing_1_1;
            },
            function (themes_service_1_1) {
                themes_service_1 = themes_service_1_1;
            }],
        execute: function() {
            describe('Service: Themes', function () {
                beforeEach(function () {
                    testing_1.TestBed.configureTestingModule({
                        providers: [themes_service_1.ThemesService]
                    });
                });
                it('should ...', testing_1.inject([themes_service_1.ThemesService], function (service) {
                    expect(service).toBeTruthy();
                }));
            });
        }
    }
});
