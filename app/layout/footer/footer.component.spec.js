/* tslint:disable:no-unused-variable */
System.register(['@angular/core/testing', './footer.component', '../../core/settings/settings.service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var testing_1, footer_component_1, settings_service_1;
    return {
        setters:[
            function (testing_1_1) {
                testing_1 = testing_1_1;
            },
            function (footer_component_1_1) {
                footer_component_1 = footer_component_1_1;
            },
            function (settings_service_1_1) {
                settings_service_1 = settings_service_1_1;
            }],
        execute: function() {
            describe('Component: Footer', function () {
                beforeEach(function () {
                    testing_1.TestBed.configureTestingModule({
                        providers: [settings_service_1.SettingsService]
                    }).compileComponents();
                });
                it('should create an instance', testing_1.async(testing_1.inject([settings_service_1.SettingsService], function (settingsService) {
                    var component = new footer_component_1.FooterComponent(settingsService);
                    expect(component).toBeTruthy();
                })));
            });
        }
    }
});
