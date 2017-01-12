/* tslint:disable:no-unused-variable */
System.register(['@angular/core/testing', './header.component', '../sidebar/userblock/userblock.service', '../../core/settings/settings.service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var testing_1, header_component_1, userblock_service_1, settings_service_1;
    return {
        setters:[
            function (testing_1_1) {
                testing_1 = testing_1_1;
            },
            function (header_component_1_1) {
                header_component_1 = header_component_1_1;
            },
            function (userblock_service_1_1) {
                userblock_service_1 = userblock_service_1_1;
            },
            function (settings_service_1_1) {
                settings_service_1 = settings_service_1_1;
            }],
        execute: function() {
            describe('Component: Header', function () {
                beforeEach(function () {
                    testing_1.TestBed.configureTestingModule({
                        providers: [userblock_service_1.UserblockService, settings_service_1.SettingsService]
                    }).compileComponents();
                });
                it('should create an instance', testing_1.async(testing_1.inject([userblock_service_1.UserblockService, settings_service_1.SettingsService], function (userblockService, settingsService) {
                    var component = new header_component_1.HeaderComponent(userblockService, settingsService);
                    expect(component).toBeTruthy();
                })));
            });
        }
    }
});
