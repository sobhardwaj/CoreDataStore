#!/usr/bin/env bash

set -ex

if [[ `npm -v` != 3* ]]; then npm i -g npm@3; fi
cd src/CoreDataStore.Web
npm run clean
npm run build

rm -f wwwroot/index.html
cd ../..
docker build -f docker/node.dockerfile -t stuartshay/coredatastore:node$TRAVIS_NODE_VERSION-$TRAVIS_BUILD_NUMBER .
docker run --env-file docker/env.staging -d -p 3000:3000 stuartshay/coredatastore:node$TRAVIS_NODE_VERSION-$TRAVIS_BUILD_NUMBER
docker ps -a

docker login -u="$DOCKER_USERNAME" -p="$DOCKER_PASSWORD"
docker push stuartshay/coredatastore:node$TRAVIS_NODE_VERSION-$TRAVIS_BUILD_NUMBER
