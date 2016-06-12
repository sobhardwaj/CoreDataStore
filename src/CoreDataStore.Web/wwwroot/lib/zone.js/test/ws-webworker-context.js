importScripts('/base/test/zone_worker_entry_point.ts');
Zone.current.fork({ name: 'webworker' }).run(function () {
    var websocket = new WebSocket('ws://localhost:8001');
    websocket.addEventListener('open', function () {
        websocket.onmessage = function () {
            if (self.Zone.current.name === 'webworker') {
                self.postMessage('pass');
            }
            else {
                self.postMessage('fail');
            }
        };
        websocket.send('text');
    });
});
//# sourceMappingURL=ws-webworker-context.js.map