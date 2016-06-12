"use strict";
describe('longStackTraceZone', function () {
    var log;
    var lstz = Zone.current.fork(Zone['longStackTraceZoneSpec']).fork({
        name: 'long-stack-trace-zone-test',
        onHandleError: function (parentZoneDelegate, currentZone, targetZone, error) {
            parentZoneDelegate.handleError(targetZone, error);
            log.push(error.stack);
            return false;
        }
    });
    beforeEach(function () {
        log = [];
    });
    it('should produce long stack traces', function (done) {
        lstz.run(function () {
            setTimeout(function () {
                setTimeout(function () {
                    setTimeout(function () {
                        try {
                            expect(log[0].split('Elapsed: ').length).toBe(3);
                            done();
                        }
                        catch (e) {
                            expect(e).toBe(null);
                        }
                    }, 0);
                    throw new Error('Hello');
                }, 0);
            }, 0);
        });
    });
});
//# sourceMappingURL=long-stack-trace-zone.spec.js.map