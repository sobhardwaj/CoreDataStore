"use strict";
var test_util_1 = require('../test-util');
var MicroTaskQueueZoneSpec = (function () {
    function MicroTaskQueueZoneSpec() {
        this.name = 'MicroTaskQueue';
        this.queue = [];
        this.properties = { queue: this.queue, flush: this.flush.bind(this) };
    }
    MicroTaskQueueZoneSpec.prototype.flush = function () {
        while (this.queue.length) {
            var task = this.queue.shift();
            task.invoke();
        }
    };
    MicroTaskQueueZoneSpec.prototype.onScheduleTask = function (delegate, currentZone, targetZone, task) {
        this.queue.push(task);
    };
    return MicroTaskQueueZoneSpec;
}());
function flushMicrotasks() {
    Zone.current.get('flush')();
}
describe('Promise', test_util_1.ifEnvSupports('Promise', function () {
    if (!global.Promise)
        return;
    var testZone = Zone.current.fork({ name: 'TestZone' });
    var log;
    var pZone = Zone.current.fork({
        name: 'promise-zone',
        onScheduleTask: function (parentZoneDelegate, currentZone, targetZone, task) {
            log.push('scheduleTask');
            parentZoneDelegate.scheduleTask(targetZone, task);
        }
    });
    var queueZone = Zone.current.fork(new MicroTaskQueueZoneSpec());
    beforeEach(function () {
        log = [];
    });
    it('should make sure that new Promise is instance of Promise', function () {
        expect(Promise.resolve(123) instanceof Promise).toBe(true);
        expect(new Promise(function () { return null; }) instanceof Promise).toBe(true);
    });
    it('should intercept scheduling of resolution and then', function (done) {
        pZone.run(function () {
            var p = new Promise(function (resolve, reject) {
                expect(resolve('RValue')).toBe(undefined);
            });
            expect(log).toEqual([]);
            expect(p instanceof Promise).toBe(true);
            p = p.then(function (v) {
                log.push(v);
                expect(v).toBe('RValue');
                expect(log).toEqual(['scheduleTask', 'RValue']);
                return 'second value';
            });
            expect(p instanceof Promise).toBe(true);
            expect(log).toEqual(['scheduleTask']);
            p = p.then(function (v) {
                log.push(v);
                expect(log).toEqual(['scheduleTask', 'RValue', 'scheduleTask', 'second value']);
                done();
            });
            expect(p instanceof Promise).toBe(true);
            expect(log).toEqual(['scheduleTask']);
        });
    });
    it('should allow sync resolution of promises', function () {
        queueZone.run(function () {
            var flush = Zone.current.get('flush');
            var queue = Zone.current.get('queue');
            var p = new Promise(function (resolve, reject) {
                resolve('RValue');
            }).then(function (v) {
                log.push(v);
                return 'second value';
            }).then(function (v) {
                log.push(v);
            });
            expect(queue.length).toEqual(1);
            expect(log).toEqual([]);
            flush();
            expect(log).toEqual(['RValue', 'second value']);
        });
    });
    it('should allow sync resolution of promises returning promises', function () {
        queueZone.run(function () {
            var flush = Zone.current.get('flush');
            var queue = Zone.current.get('queue');
            var p = new Promise(function (resolve, reject) {
                resolve(Promise.resolve('RValue'));
            }).then(function (v) {
                log.push(v);
                return Promise.resolve('second value');
            }).then(function (v) {
                log.push(v);
            });
            expect(queue.length).toEqual(1);
            expect(log).toEqual([]);
            flush();
            expect(log).toEqual(['RValue', 'second value']);
        });
    });
    describe('Promise API', function () {
        it('should work with .then', function (done) {
            var resolve;
            testZone.run(function () {
                new Promise(function (resolveFn) {
                    resolve = resolveFn;
                }).then(function () {
                    expect(Zone.current).toBe(testZone);
                    done();
                });
            });
            resolve();
        });
        it('should work with .catch', function (done) {
            var reject;
            testZone.run(function () {
                new Promise(function (resolveFn, rejectFn) {
                    reject = rejectFn;
                })['catch'](function () {
                    expect(Zone.current).toBe(testZone);
                    done();
                });
            });
            expect(reject()).toBe(undefined);
        });
        it('should work with Promise.resolve', function () {
            queueZone.run(function () {
                var value = null;
                Promise.resolve('resolveValue').then(function (v) { return value = v; });
                expect(Zone.current.get('queue').length).toEqual(1);
                flushMicrotasks();
                expect(value).toEqual('resolveValue');
            });
        });
        it('should work with Promise.reject', function () {
            queueZone.run(function () {
                var value = null;
                Promise.reject('rejectReason')['catch'](function (v) { return value = v; });
                expect(Zone.current.get('queue').length).toEqual(1);
                flushMicrotasks();
                expect(value).toEqual('rejectReason');
            });
        });
        describe('reject', function () {
            it('should reject promise', function () {
                queueZone.run(function () {
                    var value = null;
                    Promise.reject('rejectReason')['catch'](function (v) { return value = v; });
                    flushMicrotasks();
                    expect(value).toEqual('rejectReason');
                });
            });
            it('should reject promise', function () {
                queueZone.run(function () {
                    var value = null;
                    Promise.reject('rejectReason')['catch'](function (v) { return value = v; });
                    flushMicrotasks();
                    expect(value).toEqual('rejectReason');
                });
            });
            it('should re-reject promise', function () {
                queueZone.run(function () {
                    var value = null;
                    Promise.reject('rejectReason')['catch'](function (v) { throw v; })['catch'](function (v) { return value = v; });
                    flushMicrotasks();
                    expect(value).toEqual('rejectReason');
                });
            });
            it('should reject and recover promise', function () {
                queueZone.run(function () {
                    var value = null;
                    Promise.reject('rejectReason')['catch'](function (v) { return v; }).then(function (v) { return value = v; });
                    flushMicrotasks();
                    expect(value).toEqual('rejectReason');
                });
            });
            it('should reject if chained promise does not catch promise', function () {
                queueZone.run(function () {
                    var value = null;
                    Promise.reject('rejectReason')
                        .then(function (v) { return fail('should not get here'); })
                        .then(null, function (v) { return value = v; });
                    flushMicrotasks();
                    expect(value).toEqual('rejectReason');
                });
            });
            it('should notify Zone.onError if no one catches promise', function (done) {
                var promiseError = null;
                var zone = null;
                var task = null;
                queueZone.fork({
                    name: 'promise-error',
                    onHandleError: function (delegate, current, target, error) {
                        promiseError = error;
                        delegate.handleError(target, error);
                        return false;
                    }
                }).run(function () {
                    zone = Zone.current;
                    task = Zone.currentTask;
                    Promise.reject('rejectedErrorShouldBeHandled');
                    expect(promiseError).toBe(null);
                });
                setTimeout(function () { return null; });
                setTimeout(function () {
                    expect(promiseError.message).toBe('Uncaught (in promise): rejectedErrorShouldBeHandled');
                    expect(promiseError['rejection']).toBe('rejectedErrorShouldBeHandled');
                    expect(promiseError['zone']).toBe(zone);
                    expect(promiseError['task']).toBe(task);
                    done();
                });
            });
        });
        describe('Promise.race', function () {
            it('should reject the value', function () {
                queueZone.run(function () {
                    var value = null;
                    Promise.race([Promise.reject('rejection1'), 'v1'])['catch'](function (v) { return value = v; });
                    //expect(Zone.current.get('queue').length).toEqual(2);
                    flushMicrotasks();
                    expect(value).toEqual('rejection1');
                });
            });
            it('should resolve the value', function () {
                queueZone.run(function () {
                    var value = null;
                    Promise.race([Promise.resolve('resolution'), 'v1']).then(function (v) { return value = v; });
                    //expect(Zone.current.get('queue').length).toEqual(2);
                    flushMicrotasks();
                    expect(value).toEqual('resolution');
                });
            });
        });
        describe('Promise.all', function () {
            it('should reject the value', function () {
                queueZone.run(function () {
                    var value = null;
                    Promise.all([Promise.reject('rejection'), 'v1'])['catch'](function (v) { return value = v; });
                    //expect(Zone.current.get('queue').length).toEqual(2);
                    flushMicrotasks();
                    expect(value).toEqual('rejection');
                });
            });
            it('should resolve the value', function () {
                queueZone.run(function () {
                    var value = null;
                    Promise.all([Promise.resolve('resolution'), 'v1']).then(function (v) { return value = v; });
                    //expect(Zone.current.get('queue').length).toEqual(2);
                    flushMicrotasks();
                    expect(value).toEqual(['resolution', 'v1']);
                });
            });
        });
    });
    describe('fetch', test_util_1.ifEnvSupports('fetch', function () {
        it('should work for text response', function (done) {
            testZone.run(function () {
                global['fetch']('/base/test/assets/sample.json').then(function (response) {
                    var fetchZone = Zone.current;
                    expect(fetchZone).toBe(testZone);
                    response.text().then(function (text) {
                        expect(Zone.current).toBe(fetchZone);
                        expect(text.trim()).toEqual('{"hello": "world"}');
                        done();
                    });
                });
            });
        });
        it('should work for json response', function (done) {
            testZone.run(function () {
                global['fetch']('/base/test/assets/sample.json').then(function (response) {
                    var fetchZone = Zone.current;
                    expect(fetchZone).toBe(testZone);
                    response.json().then(function (obj) {
                        expect(Zone.current).toBe(fetchZone);
                        expect(obj.hello).toEqual('world');
                        done();
                    });
                });
            });
        });
        it('should work for blob response', function (done) {
            testZone.run(function () {
                global['fetch']('/base/test/assets/sample.json').then(function (response) {
                    var fetchZone = Zone.current;
                    expect(fetchZone).toBe(testZone);
                    response.blob().then(function (blob) {
                        expect(Zone.current).toBe(fetchZone);
                        expect(blob instanceof Blob).toEqual(true);
                        done();
                    });
                });
            });
        });
        it('should work for arrayBuffer response', function (done) {
            testZone.run(function () {
                global['fetch']('/base/test/assets/sample.json').then(function (response) {
                    var fetchZone = Zone.current;
                    expect(fetchZone).toBe(testZone);
                    response.arrayBuffer().then(function (blob) {
                        expect(Zone.current).toBe(fetchZone);
                        expect(blob instanceof ArrayBuffer).toEqual(true);
                        done();
                    });
                });
            });
        });
    }));
}));
//# sourceMappingURL=Promise.spec.js.map