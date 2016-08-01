FROM nginx

COPY src/CoreDataStore.Web/wwwroot /usr/share/nginx/html

EXPOSE 80

ENTRYPOINT ["nginx"]

