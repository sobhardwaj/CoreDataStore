"use strict";
require('../../lib/zone-spec/sync-test');
var test_util_1 = require('../test-util');
describe('SyncTestZoneSpec', function () {
    var SyncTestZoneSpec = Zone['SyncTestZoneSpec'];
    var testZoneSpec;
    var syncTestZone;
    beforeEach(function () {
        testZoneSpec = new SyncTestZoneSpec('name');
        syncTestZone = Zone.current.fork(testZoneSpec);
    });
    it('should fail on Promise.then', function () {
        syncTestZone.run(function () {
            expect(function () { Promise.resolve().then(function () { }); })
                .toThrow(new Error("Cannot call Promise.then from within a sync test."));
        });
    });
    it('should fail on setTimeout', function () {
        syncTestZone.run(function () {
            expect(function () { setTimeout(function () { }, 100); })
                .toThrow(new Error("Cannot call setTimeout from within a sync test."));
        });
    });
    describe('event tasks', test_util_1.ifEnvSupports('document', function () {
        it('should work with event tasks', function () {
            syncTestZone.run(function () {
                var button = document.createElement('button');
                document.body.appendChild(button);
                var x = 1;
                try {
                    button.addEventListener('click', function () { x++; });
                    button.click();
                    expect(x).toEqual(2);
                    button.click();
                    expect(x).toEqual(3);
                }
                finally {
                    document.body.removeChild(button);
                }
            });
        });
    }));
});
//# sourceMappingURL=sync-test.spec.js.map