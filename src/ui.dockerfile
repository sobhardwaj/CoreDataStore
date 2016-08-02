FROM nginx

COPY src/CoreDataStore.UI/build etc/nginx/html
COPY src/CoreDataStore.UI/nginx.conf /etc/nginx/nginx.conf