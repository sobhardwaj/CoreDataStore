FROM node:6.10.2
MAINTAINER Stuart Shay

# Set Default environment variables (Temp Placeholder)
ENV LANDMARK="https://api.coredatastore.com/api/"
ENV MAPSAPI="https://api-maps.navigatorglass.com/api/"

# Create and copy app directory
RUN mkdir -p /app
WORKDIR /app
COPY src/CoreDataStore.Web/wwwroot ./wwwroot
COPY _package.json /app/package.json
COPY server.js /app/

# Install app dependencies
RUN npm i

EXPOSE 3000
CMD [ "npm", "start" ]
