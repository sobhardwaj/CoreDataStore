/* tslint:disable:no-unused-variable */
System.register(['@angular/core/testing', './settings.service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var testing_1, settings_service_1;
    return {
        setters:[
            function (testing_1_1) {
                testing_1 = testing_1_1;
            },
            function (settings_service_1_1) {
                settings_service_1 = settings_service_1_1;
            }],
        execute: function() {
            describe('Service: Settings', function () {
                beforeEach(function () {
                    testing_1.TestBed.configureTestingModule({
                        providers: [settings_service_1.SettingsService]
                    });
                });
                it('should ...', testing_1.inject([settings_service_1.SettingsService], function (service) {
                    expect(service).toBeTruthy();
                }));
            });
        }
    }
});
