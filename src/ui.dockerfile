FROM nginx

COPY src/CoreDataStore.UI/build /usr/share/nginx/html

EXPOSE 80

CMD ["nginx"]

