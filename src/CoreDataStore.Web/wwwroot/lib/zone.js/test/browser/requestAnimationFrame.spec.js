"use strict";
var test_util_1 = require('../test-util');
describe('requestAnimationFrame', function () {
    var functions = [
        'requestAnimationFrame',
        'webkitRequestAnimationFrame',
        'mozRequestAnimationFrame'
    ];
    functions.forEach(function (fnName) {
        describe(fnName, test_util_1.ifEnvSupports(fnName, function () {
            var rAF = window[fnName];
            it('should be tolerant of invalid arguments', function () {
                // rAF throws an error on invalid arguments, so expect that.
                expect(function () {
                    rAF(null);
                }).toThrow();
            });
            it('should bind to same zone when called recursively', function (done) {
                Zone.current.fork({ name: 'TestZone' }).run(function () {
                    var frames = 0;
                    var previousTimeStamp = 0;
                    function frameCallback(timestamp) {
                        expect(timestamp).toMatch(/^[\d.]+$/);
                        // expect previous <= current
                        expect(previousTimeStamp).not.toBeGreaterThan(timestamp);
                        previousTimeStamp = timestamp;
                        if (frames++ > 15) {
                            return done();
                        }
                        rAF(frameCallback);
                    }
                    rAF(frameCallback);
                });
            });
        }));
    });
});
//# sourceMappingURL=requestAnimationFrame.spec.js.map