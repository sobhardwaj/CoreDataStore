/* tslint:disable:no-unused-variable */
System.register(['@angular/core/testing', './userblock.service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var testing_1, userblock_service_1;
    return {
        setters:[
            function (testing_1_1) {
                testing_1 = testing_1_1;
            },
            function (userblock_service_1_1) {
                userblock_service_1 = userblock_service_1_1;
            }],
        execute: function() {
            describe('Service: Userblock', function () {
                beforeEach(function () {
                    testing_1.TestBed.configureTestingModule({
                        providers: [userblock_service_1.UserblockService]
                    });
                });
                it('should ...', testing_1.inject([userblock_service_1.UserblockService], function (service) {
                    expect(service).toBeTruthy();
                }));
            });
        }
    }
});
