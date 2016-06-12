"use strict";
var test_util_1 = require('../test-util');
function supportsImports() {
    return 'import' in document.createElement('link');
}
supportsImports.message = 'HTML Imports';
describe('HTML Imports', test_util_1.ifEnvSupports(supportsImports, function () {
    var testZone = Zone.current.fork({ name: 'test' });
    it('should work with addEventListener', function (done) {
        var link;
        testZone.run(function () {
            link = document.createElement('link');
            link.rel = 'import';
            link.href = 'someUrl';
            link.addEventListener('error', function () {
                expect(Zone.current).toBe(testZone);
                document.head.removeChild(link);
                done();
            });
        });
        document.head.appendChild(link);
    });
    function supportsOnEvents() {
        var link = document.createElement('link');
        var linkPropDesc = Object.getOwnPropertyDescriptor(link, 'onerror');
        return !(linkPropDesc && linkPropDesc.value === null);
    }
    supportsOnEvents.message = 'Supports HTMLLinkElement#onxxx patching';
    test_util_1.ifEnvSupports(supportsOnEvents, function () {
        it('should work with onerror', function (done) {
            var link;
            testZone.run(function () {
                link = document.createElement('link');
                link.rel = 'import';
                link.href = 'anotherUrl';
                link.onerror = function () {
                    expect(Zone.current).toBe(testZone);
                    document.head.removeChild(link);
                    done();
                };
            });
            document.head.appendChild(link);
        });
        it('should work with onload', function (done) {
            var link;
            testZone.run(function () {
                link = document.createElement('link');
                link.rel = 'import';
                link.href = '/base/test/assets/import.html';
                link.onload = function () {
                    expect(Zone.current).toBe(testZone);
                    document.head.removeChild(link);
                    done();
                };
            });
            document.head.appendChild(link);
        });
    });
}));
//# sourceMappingURL=HTMLImports.spec.js.map