#!/usr/bin/env bash

set -ex


if [ "$TRAVIS_BRANCH" == "master" ]; then
    curl -sSL https://github.com/rancher/rancher-compose/releases/download/v${RANCHER_COMPOSE_VERSION}/rancher-compose-linux-amd64-v${RANCHER_COMPOSE_VERSION}.tar.gz | tar -zxf - --strip-components=2;
    export NODE_UI_TAG=node$TRAVIS_NODE_VERSION-$TRAVIS_BUILD_NUMBER;
    ./rancher-compose -f ${DOCKER_COMPOSE} -r ${RANCHER_COMPOSE} -p ${STACK_NAME} create;
    ./rancher-compose -f ${DOCKER_COMPOSE} -r ${RANCHER_COMPOSE} -p ${STACK_NAME} up -d;
    ./rancher-compose -f ${DOCKER_COMPOSE} -r ${RANCHER_COMPOSE} -p ${STACK_NAME} --verbose up --upgrade --force-upgrade --pull -d ${UPGRADE_SERVICES};
    ./rancher-compose -f ${DOCKER_COMPOSE} -r ${RANCHER_COMPOSE} -p ${STACK_NAME} --verbose up -d --confirm-upgrade ${UPGRADE_SERVICES};
fi;
