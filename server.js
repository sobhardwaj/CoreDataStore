// export NG_ENVIRONMENT=Dev

const LANDMARK = process.env.LANDMARK || 'https://api.coredatastore.com/api/';
const REPORTSAPI = process.env.REPORTSAPI || 'https://report.coredatastore.com/';
const MAPSAPI = process.env.MAPSAPI || 'https://api-maps.navigatorglass.com/api/';
const NG_ENVIRONMENT = process.env.NG_ENVIRONMENT || '';

var path = require('path');
var express = require('express');
var port = process.env.PORT || 3000;
var app = express();
global.base = __dirname;

// view engine setup
app.set('views', path.join(__dirname, 'wwwroot'));
app.set('view engine', 'jade');

app.use(express.static(path.join(__dirname, 'wwwroot')));

/* GET home page. */
app.get('/', function(req, res, next) {
  res.render('index', {
    'LANDMARK': LANDMARK,
    'MAPSAPI': MAPSAPI,
    'REPORTSAPI': REPORTSAPI,
    'ng2ENV': NG_ENVIRONMENT
  });
});

// catch 404 and forward to error handler
app.use(function(req, res, next) {
  var err = new Error('Not Found');
  err.status = 404;
  next(err);
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});

app.listen(port, '0.0.0.0', function() {
  console.log('Listening on port %d', port);
});
