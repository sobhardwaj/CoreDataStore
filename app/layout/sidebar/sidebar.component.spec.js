/* tslint:disable:no-unused-variable */
System.register(['@angular/core/testing', './sidebar.component', '../../core/menu/menu.service', '../../core/settings/settings.service', '@angular/router'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var testing_1, sidebar_component_1, menu_service_1, settings_service_1, router_1;
    return {
        setters:[
            function (testing_1_1) {
                testing_1 = testing_1_1;
            },
            function (sidebar_component_1_1) {
                sidebar_component_1 = sidebar_component_1_1;
            },
            function (menu_service_1_1) {
                menu_service_1 = menu_service_1_1;
            },
            function (settings_service_1_1) {
                settings_service_1 = settings_service_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            }],
        execute: function() {
            describe('Component: Sidebar', function () {
                var mockRouter = {
                    navigate: jasmine.createSpy('navigate')
                };
                beforeEach(function () {
                    testing_1.TestBed.configureTestingModule({
                        providers: [
                            menu_service_1.MenuService,
                            settings_service_1.SettingsService,
                            { provide: router_1.Router, useValue: mockRouter }
                        ]
                    }).compileComponents();
                });
                it('should create an instance', testing_1.async(testing_1.inject([menu_service_1.MenuService, settings_service_1.SettingsService, router_1.Router], function (menuService, settingsService, router) {
                    var component = new sidebar_component_1.SidebarComponent(menuService, settingsService, router);
                    expect(component).toBeTruthy();
                })));
            });
        }
    }
});
