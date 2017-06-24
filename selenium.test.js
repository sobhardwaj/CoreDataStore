var username = process.env.SAUCE_USERNAME || '';
var accessKey = process.env.SAUCE_ACCESS_KEY || '';

var webdriver = require('selenium-webdriver'),
  urlSaucelabs,
  driver;

if (username && accessKey) {
  urlSaucelabs = ["http://", username, ":", accessKey, "@ondemand.saucelabs.com:80/wd/hub"].join('');
  driver = new webdriver.Builder().
  withCapabilities({
    'browserName': 'googlechrome',
    'platform': 'Windows 7',
    'version': '59.0.',
    'username': username,
    'accessKey': accessKey
  }).
  usingServer(urlSaucelabs).
  build();

  driver.get("http://localhost:3000/#/diagnostics");

  driver.getTitle().then(function(title) {
    console.log("title is: " + title);
  });

  driver.quit();
}
