FROM nginx

COPY src/CoreDataStore.Web/wwwroot etc/nginx/html
COPY src/CoreDataStore.Web/nginx.conf /etc/nginx/nginx.conf