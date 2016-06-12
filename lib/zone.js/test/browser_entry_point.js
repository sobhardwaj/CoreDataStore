"use strict";
// Must be loaded before zone loads, so that zone can detect WTF.
require('./wtf_mock');
// Setup tests for Zone without microtask support
require('../lib/zone');
require('../lib/browser/browser.ts');
require('../lib/zone-spec/long-stack-trace');
require('../lib/zone-spec/wtf');
// Setup test environment
require('./test-env-setup');
// List all tests here:
require('./common_tests');
require('./browser/browser.spec');
require('./browser/element.spec');
require('./browser/FileReader.spec');
require('./browser/HTMLImports.spec');
require('./browser/registerElement.spec');
require('./browser/requestAnimationFrame.spec');
require('./browser/WebSocket.spec');
require('./browser/XMLHttpRequest.spec');
//import './browser/geolocation.spec.manual';
//# sourceMappingURL=browser_entry_point.js.map