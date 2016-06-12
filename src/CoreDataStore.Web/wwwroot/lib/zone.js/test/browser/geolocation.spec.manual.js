"use strict";
var test_util_1 = require('../test-util');
function supportsGeolocation() {
    return 'geolocation' in navigator;
}
supportsGeolocation.message = 'Geolocation';
describe('Geolocation', test_util_1.ifEnvSupports(supportsGeolocation, function () {
    var testZone = Zone.current.fork({ name: 'geotest' });
    it('should work for getCurrentPosition', function (done) {
        testZone.run(function () {
            navigator.geolocation.getCurrentPosition(function (pos) {
                expect(Zone.current).toBe(testZone);
                done();
            });
        });
    }, 10000);
    it('should work for watchPosition', function (done) {
        testZone.run(function () {
            var watchId;
            watchId = navigator.geolocation.watchPosition(function (pos) {
                expect(Zone.current).toBe(testZone);
                navigator.geolocation.clearWatch(watchId);
                done();
            });
        });
    }, 10000);
}));
//# sourceMappingURL=geolocation.spec.manual.js.map