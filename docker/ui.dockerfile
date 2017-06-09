FROM node:6.10.2

# Set environment variables
ENV LANDMARK=http://informationcart.eastus2.cloudapp.azure.com:80/api/
ENV MAPSAPI="http://informationcart.eastus2.cloudapp.azure.com:82/api/"

RUN mkdir -p /app
WORKDIR /app

COPY src/CoreDataStore.Web/wwwroot ./wwwroot


EXPOSE 80
CMD [ "npm", "start" ]
