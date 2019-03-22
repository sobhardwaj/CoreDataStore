# Build Stage
FROM stuartshay/coredatastore:2.2.1-base AS build-env

ARG BUILD_NUMBER=0
ENV BUILD_NUMBER ${BUILD_NUMBER}

COPY src /app/src
COPY _stylecop /app/_stylecop
COPY CoreDataStore.sln /app/CoreDataStore.sln

WORKDIR /app/src/CoreDataStore.Web

RUN dotnet tool install --global dotnet-setversion --version 2.0.0 
RUN dotnet tool install --global dotnet-dbinfo --version 1.4.0 
RUN /root/.dotnet/tools/setversion 2.2.1.${BUILD_NUMBER};

RUN dotnet publish -o /publish -c Release -f netcoreapp2.2 -r debian.9-x64

# Runtime Image Stage
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

#COPY ./scripts/entrypoint.sh /entrypoint.sh
#COPY ./scripts/healthcheck.sh /healthcheck.sh

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        curl \
        && rm -rf /var/lib/apt/lists/* \
        && curl https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh > /wait_for_it.sh \
        && chmod +x /*.sh

WORKDIR /publish
COPY --from=build-env /publish .

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

HEALTHCHECK CMD curl --fail http://localhost:5000/health || exit 1

# Open up port
EXPOSE 5000

ENTRYPOINT ["dotnet", "CoreDataStore.Web.dll"]
#ENTRYPOINT ["/entrypoint.sh"]
