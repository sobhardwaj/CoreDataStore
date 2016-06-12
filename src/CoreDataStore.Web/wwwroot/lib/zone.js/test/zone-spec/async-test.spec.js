"use strict";
require('../../lib/zone-spec/async-test');
var test_util_1 = require('../test-util');
describe('AsyncTestZoneSpec', function () {
    var log;
    var AsyncTestZoneSpec = Zone['AsyncTestZoneSpec'];
    function finishCallback() {
        log.push('finish');
    }
    function failCallback() {
        log.push('fail');
    }
    beforeEach(function () {
        log = [];
    });
    it('should call finish after zone is run', function (done) {
        var finished = false;
        var testZoneSpec = new AsyncTestZoneSpec(function () {
            expect(finished).toBe(true);
            done();
        }, failCallback, 'name');
        var atz = Zone.current.fork(testZoneSpec);
        atz.run(function () {
            finished = true;
        });
    });
    it('should call finish after a setTimeout is done', function (done) {
        var finished = false;
        var testZoneSpec = new AsyncTestZoneSpec(function () {
            expect(finished).toBe(true);
            done();
        }, function () {
            done.fail('async zone called failCallback unexpectedly');
        }, 'name');
        var atz = Zone.current.fork(testZoneSpec);
        atz.run(function () {
            setTimeout(function () {
                finished = true;
            }, 10);
        });
    });
    it('should call finish after microtasks are done', function (done) {
        var finished = false;
        var testZoneSpec = new AsyncTestZoneSpec(function () {
            expect(finished).toBe(true);
            done();
        }, function () {
            done.fail('async zone called failCallback unexpectedly');
        }, 'name');
        var atz = Zone.current.fork(testZoneSpec);
        atz.run(function () {
            Promise.resolve().then(function () {
                finished = true;
            });
        });
    });
    it('should call finish after both micro and macrotasks are done', function (done) {
        var finished = false;
        var testZoneSpec = new AsyncTestZoneSpec(function () {
            expect(finished).toBe(true);
            done();
        }, function () {
            done.fail('async zone called failCallback unexpectedly');
        }, 'name');
        var atz = Zone.current.fork(testZoneSpec);
        atz.run(function () {
            var deferred = new Promise(function (resolve, reject) {
                setTimeout(function () {
                    resolve();
                }, 10);
            }).then(function () {
                finished = true;
            });
        });
    });
    it('should call finish after both macro and microtasks are done', function (done) {
        var finished = false;
        var testZoneSpec = new AsyncTestZoneSpec(function () {
            expect(finished).toBe(true);
            done();
        }, function () {
            done.fail('async zone called failCallback unexpectedly');
        }, 'name');
        var atz = Zone.current.fork(testZoneSpec);
        atz.run(function () {
            Promise.resolve().then(function () {
                setTimeout(function () {
                    finished = true;
                }, 10);
            });
        });
    });
    describe('event tasks', test_util_1.ifEnvSupports('document', function () {
        var button;
        beforeEach(function () {
            button = document.createElement('button');
            document.body.appendChild(button);
        });
        afterEach(function () {
            document.body.removeChild(button);
        });
        it('should call finish after an event task is done', function (done) {
            var finished = false;
            var testZoneSpec = new AsyncTestZoneSpec(function () {
                expect(finished).toBe(true);
                done();
            }, function () {
                done.fail('async zone called failCallback unexpectedly');
            }, 'name');
            var atz = Zone.current.fork(testZoneSpec);
            atz.run(function () {
                button.addEventListener('click', function () {
                    finished = true;
                });
                var clickEvent = document.createEvent('Event');
                clickEvent.initEvent('click', true, true);
                button.dispatchEvent(clickEvent);
            });
        });
        it('should call finish after an event task is done asynchronously', function (done) {
            var finished = false;
            var testZoneSpec = new AsyncTestZoneSpec(function () {
                expect(finished).toBe(true);
                done();
            }, function () {
                done.fail('async zone called failCallback unexpectedly');
            }, 'name');
            var atz = Zone.current.fork(testZoneSpec);
            atz.run(function () {
                button.addEventListener('click', function () {
                    setTimeout(function () {
                        finished = true;
                    }, 10);
                });
                var clickEvent = document.createEvent('Event');
                clickEvent.initEvent('click', true, true);
                button.dispatchEvent(clickEvent);
            });
        });
    }));
    describe('XHRs', test_util_1.ifEnvSupports('XMLHttpRequest', function () {
        it('should wait for XHRs to complete', function (done) {
            var req;
            var finished = false;
            var testZoneSpec = new AsyncTestZoneSpec(function () {
                expect(finished).toBe(true);
                done();
            }, function (err) {
                done.fail('async zone called failCallback unexpectedly');
            }, 'name');
            var atz = Zone.current.fork(testZoneSpec);
            atz.run(function () {
                req = new XMLHttpRequest();
                req.onreadystatechange = function () {
                    if (req.readyState === XMLHttpRequest.DONE) {
                        finished = true;
                    }
                };
                req.open('get', '/', true);
                req.send();
            });
        });
        it('should fail if an xhr fails', function (done) {
            var req;
            var testZoneSpec = new AsyncTestZoneSpec(function () {
                done.fail('expected failCallback to be called');
            }, function (err) {
                expect(err).toEqual('bad url failure');
                done();
            }, 'name');
            var atz = Zone.current.fork(testZoneSpec);
            atz.run(function () {
                req = new XMLHttpRequest();
                req.onload = function () {
                    if (req.status != 200) {
                        throw new Error('bad url failure');
                    }
                };
                req.open('get', '/bad-url', true);
                req.send();
            });
        });
    }));
    it('should fail if setInterval is used', function (done) {
        var finished = false;
        var testZoneSpec = new AsyncTestZoneSpec(function () {
            done.fail('expected failCallback to be called');
        }, function (err) {
            expect(err).toEqual('Cannot use setInterval from within an async zone test.');
            done();
        }, 'name');
        var atz = Zone.current.fork(testZoneSpec);
        atz.run(function () {
            setInterval(function () {
            }, 100);
        });
    });
    it('should fail if an error is thrown asynchronously', function (done) {
        var finished = false;
        var testZoneSpec = new AsyncTestZoneSpec(function () {
            done.fail('expected failCallback to be called');
        }, function (err) {
            expect(err).toEqual('my error');
            done();
        }, 'name');
        var atz = Zone.current.fork(testZoneSpec);
        atz.run(function () {
            setTimeout(function () {
                throw new Error('my error');
            }, 10);
        });
    });
    it('should fail if a promise rejection is unhandled', function (done) {
        var finished = false;
        var testZoneSpec = new AsyncTestZoneSpec(function () {
            done.fail('expected failCallback to be called');
        }, function (err) {
            expect(err).toEqual('Uncaught (in promise): my reason');
            done();
        }, 'name');
        var atz = Zone.current.fork(testZoneSpec);
        atz.run(function () {
            Promise.reject('my reason');
        });
    });
});
//# sourceMappingURL=async-test.spec.js.map