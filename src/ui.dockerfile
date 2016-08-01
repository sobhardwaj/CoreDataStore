FROM nginx

COPY src/CoreDataStore.UI/build usr/share/nginx/html
COPY src/CoreDataStore.UI/nginx.conf /etc/nginx/nginx.conf