FROM microsoft/dotnet:1.0.0-preview2-windowsservercore-sdk
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

RUN npm install -g npm3

## Install Ruby
ENV RUBY_VERSION  2.2.4
RUN powershell -Command \
	$ErrorActionPreference = 'Stop'; \
	Invoke-WebRequest -Method Get -Uri http://dl.bintray.com/oneclick/rubyinstaller/rubyinstaller-%RUBY_VERSION%-x64.exe -OutFile c:\ruby.exe ; \
	Start-Process c:\ruby.exe -ArgumentList '/verysilent' -Wait ; \
    Remove-Item c:\ruby.exe -Force

#RUN [ "C:/Ruby22-x64/bin/gem install compass" ]

## Copy SRC 
COPY src /app
WORKDIR /app

RUN dotnet restore

WORKDIR /app/CoreDataStore.Web
RUN npm install
RUN npm run build
RUN dotnet build

#CMD [ "cmd" ]
EXPOSE 5000/tcp
ENTRYPOINT ["dotnet", "run"]