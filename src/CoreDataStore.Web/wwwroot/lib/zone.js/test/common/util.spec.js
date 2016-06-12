"use strict";
var utils_1 = require('../../lib/common/utils');
describe('utils', function () {
    describe('patchMethod', function () {
        it('should patch target where the method is defined', function () {
            var args;
            var self;
            var Type = function () { };
            var method = Type.prototype.method = function () {
                var _args = [];
                for (var _i = 0; _i < arguments.length; _i++) {
                    _args[_i - 0] = arguments[_i];
                }
                args = _args;
                self = this;
                return 'OK';
            };
            var delegateMethod;
            var delegateSymbol;
            var instance = new Type();
            expect(utils_1.patchMethod(instance, 'method', function (delegate, symbol, name) {
                expect(name).toEqual('method');
                delegateMethod = delegate;
                delegateSymbol = symbol;
                return function (self, args) {
                    return delegate.apply(self, ['patch', args[0]]);
                };
            })).toBe(delegateMethod);
            expect(instance.method('a0')).toEqual('OK');
            expect(args).toEqual(['patch', 'a0']);
            expect(self).toBe(instance);
            expect(delegateMethod).toBe(method);
            expect(delegateSymbol).toEqual(utils_1.zoneSymbol('method'));
            expect(Type.prototype[delegateSymbol]).toBe(method);
        });
        it('should not double patch', function () {
            var Type = function () { };
            var method = Type.prototype.method = function () { };
            utils_1.patchMethod(Type.prototype, 'method', function (delegate) {
                return function (self, args) { return delegate.apply(self, ['patch'].concat(args)); };
            });
            var pMethod = Type.prototype.method;
            expect(pMethod).not.toBe(method);
            utils_1.patchMethod(Type.prototype, 'method', function (delegate) {
                return function (self, args) { return delegate.apply(self, ['patch'].concat(args)); };
            });
            expect(pMethod).toBe(Type.prototype.method);
        });
        it('should have a method name in the stacktrace', function () {
            var fn = function someOtherName() { throw new Error('MyError'); };
            var target = { mySpecialMethodName: fn };
            utils_1.patchMethod(target, 'mySpecialMethodName', function (delegate) {
                return function (self, args) { return delegate(); };
            });
            try {
                target.mySpecialMethodName();
            }
            catch (e) {
                if (e.stack) {
                    expect(e.stack).toContain('mySpecialMethodName');
                }
            }
        });
    });
});
//# sourceMappingURL=util.spec.js.map