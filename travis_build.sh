#!/usr/bin/env bash

set -ex

npm run clean
npm run build

cat wwwroot/index.pug
rm -f wwwroot/index.html
cd ../..
docker build -f docker/coredatastore-travis-ui.dockerfile/node.dockerfile -t stuartshay/coredatastore:node$TRAVIS_NODE_VERSION-$TRAVIS_BRANCH-$TRAVIS_BUILD_NUMBER .
docker run --env-file docker/env.staging -d -p 3000:3000 stuartshay/coredatastore:node$TRAVIS_NODE_VERSION-$TRAVIS_BRANCH-$TRAVIS_BUILD_NUMBER
docker ps -a

docker login -u="$DOCKER_USERNAME" -p="$DOCKER_PASSWORD"
docker push stuartshay/coredatastore:node$TRAVIS_NODE_VERSION-$TRAVIS_BRANCH-$TRAVIS_BUILD_NUMBER
