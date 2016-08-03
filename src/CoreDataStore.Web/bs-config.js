var proxyMiddleware = require('http-proxy-middleware');
var fallbackMiddleware = require('connect-history-api-fallback');

module.exports = {
    port: 8000,
    files: ["build/**/*.{html,htm,css,js}"],
    server: {
        baseDir: "build",
        middleware: {
            1: proxyMiddleware('/api', {
                target: 'localhost:5000',
                changeOrigin: false   
            }),       
            2: proxyMiddleware('/swagger', {
                target: 'localhost:5000',
                changeOrigin: false   
            })           
        }
    }
};