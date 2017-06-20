var express = require('express');
var port = process.env.PORT || 3000;
var app = express();

global.base = __dirname;
app.use("/", express.static(__dirname + "/wwwroot"));

app.listen(port, '0.0.0.0', function() {
  console.log('Listening on port %d', port);
});
