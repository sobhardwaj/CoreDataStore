FROM nginx

MAINTAINER Stuart Shay

COPY /docker/nginx/proxy-nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
