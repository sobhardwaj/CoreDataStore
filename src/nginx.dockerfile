FROM nginx

MAINTAINER Stuart Shay

COPY /docker/nginx/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
