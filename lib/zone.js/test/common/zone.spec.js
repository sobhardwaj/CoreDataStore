"use strict";
describe('Zone', function () {
    var rootZone = Zone.current;
    it('should have a name', function () {
        expect(Zone.current.name).toBeDefined();
    });
    describe('hooks', function () {
        it('should throw if onError is not defined', function () {
            expect(function () {
                Zone.current.run(throwError);
            }).toThrow();
        });
        it('should fire onError if a function run by a zone throws', function () {
            var errorSpy = jasmine.createSpy('error');
            var myZone = Zone.current.fork({
                name: 'spy',
                onHandleError: errorSpy
            });
            expect(errorSpy).not.toHaveBeenCalled();
            expect(function () {
                myZone.runGuarded(throwError);
            }).not.toThrow();
            expect(errorSpy).toHaveBeenCalled();
        });
    });
    it('should allow zones to be run from within another zone', function () {
        var zoneA = Zone.current.fork({ name: 'A' });
        var zoneB = Zone.current.fork({ name: 'B' });
        zoneA.run(function () {
            zoneB.run(function () {
                expect(Zone.current).toBe(zoneB);
            });
            expect(Zone.current).toBe(zoneA);
        });
        expect(Zone.current).toBe(rootZone);
    });
    describe('wrap', function () {
        it('should throw if argument is not a function', function () {
            expect(function () {
                Zone.current.wrap(11);
            }).toThrowError('Expecting function got: 11');
        });
    });
    describe('get', function () {
        it('should store properties', function () {
            var testZone = Zone.current.fork({ name: 'A', properties: { key: 'value' } });
            expect(testZone.get('key')).toEqual('value');
            var childZone = testZone.fork({ name: 'B', properties: { key: 'override' } });
            expect(testZone.get('key')).toEqual('value');
            expect(childZone.get('key')).toEqual('override');
        });
    });
    describe('task', function () {
        function noop() { }
        var log;
        var zone = Zone.current.fork({
            name: 'parent',
            onHasTask: function (delegate, current, target, hasTaskState) {
                hasTaskState['zone'] = target.name;
                log.push(hasTaskState);
            },
            onScheduleTask: function (delegate, current, target, task) {
                // Do nothing to prevent tasks from being run on VM turn;
                // Tests run task explicitly.
                return task;
            }
        });
        beforeEach(function () {
            log = [];
        });
        it('should prevent double cancellation', function () {
            var task = zone.scheduleMacroTask('test', function () { return log.push('macroTask'); }, null, noop, noop);
            zone.cancelTask(task);
            try {
                zone.cancelTask(task);
            }
            catch (e) {
                expect(e.message).toContain('already canceled');
            }
        });
        it('should not decrement counters on periodic tasks', function () {
            zone.run(function () {
                var task = zone.scheduleMacroTask('test', function () { return log.push('macroTask'); }, {
                    isPeriodic: true
                }, noop, noop);
                zone.runTask(task);
                zone.runTask(task);
                zone.cancelTask(task);
            });
            expect(log).toEqual([
                { microTask: false, macroTask: true, eventTask: false, change: 'macroTask', zone: 'parent' },
                'macroTask',
                'macroTask',
                { microTask: false, macroTask: false, eventTask: false, change: 'macroTask', zone: 'parent' }
            ]);
        });
        it('should notify of queue status change', function () {
            zone.run(function () {
                var z = Zone.current;
                z.runTask(z.scheduleMicroTask('test', function () { return log.push('microTask'); }));
                z.cancelTask(z.scheduleMacroTask('test', function () { return log.push('macroTask'); }, null, noop, noop));
                z.cancelTask(z.scheduleEventTask('test', function () { return log.push('eventTask'); }, null, noop, noop));
            });
            expect(log).toEqual([
                { microTask: true, macroTask: false, eventTask: false, change: 'microTask', zone: 'parent' },
                'microTask',
                { microTask: false, macroTask: false, eventTask: false, change: 'microTask', zone: 'parent' },
                { microTask: false, macroTask: true, eventTask: false, change: 'macroTask', zone: 'parent' },
                { microTask: false, macroTask: false, eventTask: false, change: 'macroTask', zone: 'parent' },
                { microTask: false, macroTask: false, eventTask: true, change: 'eventTask', zone: 'parent' },
                { microTask: false, macroTask: false, eventTask: false, change: 'eventTask', zone: 'parent' }
            ]);
        });
        it('should notify of queue status change on parent task', function () {
            zone.fork({ name: 'child' }).run(function () {
                var z = Zone.current;
                z.runTask(z.scheduleMicroTask('test', function () { return log.push('microTask'); }));
            });
            expect(log).toEqual([
                { microTask: true, macroTask: false, eventTask: false, change: 'microTask', zone: 'child' },
                { microTask: true, macroTask: false, eventTask: false, change: 'microTask', zone: 'parent' },
                'microTask',
                { microTask: false, macroTask: false, eventTask: false, change: 'microTask', zone: 'child' },
                { microTask: false, macroTask: false, eventTask: false, change: 'microTask', zone: 'parent' },
            ]);
        });
    });
});
function throwError() {
    throw new Error();
}
//# sourceMappingURL=zone.spec.js.map