FROM microsoft/windowsservercore
MAINTAINER Stuart Shay
LABEL version="1.0.1"

## Install .NET Core
#ENV NETCORE_URL https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0/scripts/obtain/dotnet-install.ps1 

#RUN powershell.exe Invoke-WebRequest -Uri https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0/scripts/obtain/dotnet-install.ps1 -OutFile install.ps1 ; \
#./install.ps1


## Install NodeJS

ENV NPM_CONFIG_LOGLEVEL info  
ENV NODE_VERSION 6.9.2 
ENV NODE_SHA256 9b2fcdd0d81e69a9764c3ce5a33087e02e94e8e23ea2b8c9efceebe79d49936e

RUN powershell -Command \  
    wget -Uri https://nodejs.org/dist/v%NODE_VERSION%/node-v%NODE_VERSION%-x64.msi -OutFile node.msi -UseBasicParsing ; \
    if ((Get-FileHash node.msi -Algorithm sha256).Hash -ne $env:NODE_SHA256) {exit 1} ; \
    Start-Process -FilePath msiexec -ArgumentList /q, /i, node.msi -Wait ; \
    Remove-Item -Path node.msi

## Install Ruby


## Copy SRC 
COPY src /app
WORKDIR /app

#RUN dotnet restore

WORKDIR /app/CoreDataStore.Web
RUN npm install
#RUN npm run build
#RUN dotnet build

CMD [ "cmd" ]