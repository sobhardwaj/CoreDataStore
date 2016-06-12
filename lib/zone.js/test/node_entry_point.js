"use strict";
// Must be loaded before zone loads, so that zone can detect WTF.
require('./wtf_mock');
// Setup tests for Zone without microtask support
require('../lib/zone');
require('../lib/node/node');
require('../lib/zone-spec/long-stack-trace');
require('../lib/zone-spec/wtf');
// Setup test environment
require('./test-env-setup');
// List all tests here:
require('./common_tests');
//# sourceMappingURL=node_entry_point.js.map