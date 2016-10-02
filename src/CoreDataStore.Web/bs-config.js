var proxyMiddleware = require('http-proxy-middleware');
var fallbackMiddleware = require('connect-history-api-fallback');

module.exports = {
    port: 8000,
    files: ["wwwroot/**/*.{html,htm,css,js}"],
    server: {
        baseDir: "wwwroot",
        middleware: {
            1: proxyMiddleware('/api', {
                target: 'http://localhost:5000',
                changeOrigin: false   
            }),       
            2: proxyMiddleware('/swagger', {
                target: 'http://localhost:5000',
                changeOrigin: false   
            })           
        }
    }
};