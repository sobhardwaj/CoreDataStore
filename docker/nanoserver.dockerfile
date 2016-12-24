FROM microsoft/dotnet:1.1.0-sdk-projectjson-nanoserver
MAINTAINER Stuart Shay
LABEL version="1.0.1"

## Install NodeJS

ENV NPM_CONFIG_LOGLEVEL info  
ENV NODE_VERSION 6.9.2 
ENV NODE_SHA256 9b2fcdd0d81e69a9764c3ce5a33087e02e94e8e23ea2b8c9efceebe79d49936e

RUN powershell -Command \
	$ErrorActionPreference = 'Stop'; \
	Invoke-WebRequest -Method Get -Uri https://nodejs.org/dist/v6.9.2/win-x64/node.exe -OutFile c:\node\node.exe ; 
	#\  TODO - NEED TO FIX
	#Start-Process c:\node.exe -ArgumentList '/verysilent' -Wait ; \
    #Remove-Item c:\node.exe -Force

RUN npm install -g npm3


## Install Ruby 
ENV RUBY_VERSION  2.2.4
ENV RUBY_SHA256 XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX 

RUN powershell -Command \
	$ErrorActionPreference = 'Stop'; \
	Invoke-WebRequest -Method Get -Uri http://dl.bintray.com/oneclick/rubyinstaller/rubyinstaller-%RUBY_VERSION%-x64.exe -OutFile c:\ruby.exe ; \
	Start-Process c:\ruby.exe -ArgumentList '/verysilent' -Wait ; \
    Remove-Item c:\ruby.exe -Force

CMD [ "C:/Ruby22-x64/bin/gem install compass" ] 

## Copy SRC 
COPY src /app
WORKDIR /app

RUN dotnet restore

WORKDIR /app/CoreDataStore.Web
#RUN npm install
#RUN npm run build
RUN dotnet build


EXPOSE 5000/tcp
#CMD [ "cmd" ]
#ENTRYPOINT ["dotnet", "CoreDataStore.Web.dll"]
ENTRYPOINT ["dotnet", "run"]