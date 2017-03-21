FROM microsoft/dotnet:1.1-sdk-msbuild
MAINTAINER Stuart Shay
LABEL version="1.0.1"

## Install NodeJS
ENV NPM_CONFIG_LOGLEVEL info  
ENV NODE_VERSION 6.9.2 
ENV NODE_SHA256 9b2fcdd0d81e69a9764c3ce5a33087e02e94e8e23ea2b8c9efceebe79d49936e

RUN powershell -Command \  
    wget -Uri https://nodejs.org/dist/v%NODE_VERSION%/node-v%NODE_VERSION%-x64.msi -OutFile node.msi -UseBasicParsing ; \
    if ((Get-FileHash node.msi -Algorithm sha256).Hash -ne $env:NODE_SHA256) {exit 1} ; \
    Start-Process -FilePath msiexec -ArgumentList /q, /i, node.msi -Wait ; \
    Remove-Item -Path node.msi

RUN npm install -g gulp
RUN npm install -g typings 
RUN npm install -g npm3

## Copy SRC 
COPY src /app/src
COPY CoreDataStore.sln /app/CoreDataStore.sln
COPY NuGet.config /app/NuGet.config
WORKDIR /app

RUN dotnet restore

WORKDIR /app/src/CoreDataStore.Web
RUN npm install
RUN npm run build
RUN dotnet build

EXPOSE 5000/tcp

#CMD [ "cmd" ]
ENTRYPOINT ["dotnet", "run"]