FROM microsoft/dotnet:1.0.0-rc2-core-deps

# CoreDataStore.Web Docker File
# 
#
#
#
# Reference Dockerfile
# https://github.com/DanWahlin/AspNetCorePostgreSQLDockerApp/blob/master/aspnetcore.dockerfile


MAINTAINER Stuart Shay

# DotNet CLI version
ENV DOTNET_VERSION=1.0.0-rc2-3002702


# Work around https://github.com/dotnet/cli/issues/1582 until Docker releases a
# fix (https://github.com/docker/docker/issues/20818). This workaround allows
# the container to be run with the default seccomp Docker settings by avoiding
# the restart_syscall made by LTTng which causes a failed assertion.
ENV LTTNG_UST_REGISTER_TIMEOUT 0

#RUN echo "deb [arch=amd64] http://apt-mo.trafficmanager.net/repos/dotnet/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list \
 #   && apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893 \
 #   && apt-get update \
 #   && apt-get install -y --no-install-recommends dotnet-dev-${DOTNET_VERSION} \
  #  && rm -rf /var/lib/apt/lists/*


RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        ca-certificates \
        curl \
    && rm -rf /var/lib/apt/lists/*


RUN curl -SL https://dotnetcli.blob.core.windows.net/dotnet/beta/Binaries/$DOTNET_CORE_VERSION/dotnet-debian-x64.$DOTNET_CORE_VERSION.tar.gz --output dotnet.tar.gz \
    && mkdir -p /usr/share/dotnet \
    && tar -zxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet


# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

# Copy files to app directory
COPY . /app

# Set working directory
WORKDIR /app/CoreDataStore.Web


# Restore NuGet packages
RUN ["dotnet", "restore"]

# Open up port
EXPOSE 5000

# Run the app
ENTRYPOINT ["dotnet", "run"]
