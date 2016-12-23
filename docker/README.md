## Docker 

### Build & Run container

### Linux

````
cd  CoreDataStore/
docker build -f docker/aspnetcore.dockerfile -t coredatastore_web  .
docker run -it --rm --name coredatastore_web -p 5000:5000 coredatastore_web
````

### Windows 

````
cd  CoreDataStore/
docker build -f docker/windowsserver.dockerfile -t coredatastore_web  .
docker run -it --rm --name coredatastore_web -p 5000:5000 coredatastore_web

docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' <CONATINERID> 
````

### Docker Compose

##### Local 

````
 docker-compose --file docker-compose-local.yml  up
````

##### Development - (Lattest Tag)
````
 docker-compose --file docker-compose-development.yml  up
````

##### Staging - (Stable Tag)
````
 docker-compose --file docker-compose-staging.yml  up
````

##Usefull Commands 

###Images 

```bash 
    docker images                     #Get List of Images
    docker rmi  -f <IMAGEID>          #Remove Image 
```

###Containers 

```bash 
    docker ps -a                    #All Containers
    docker ps                       #Running Containers 
   
    docker stop <CONATINERID>       #Stop Running Container
    docker stop $(docker ps -a -q)
   
    docker rm  -f <CONATINERID>     #Remove Container
    docker rm $(docker ps -a -q)
```

###Tag & Publish

```bash 
docker tag <imageid> coredatastore_web:stable
docker tag coredatastore_web:stable  stuartshay/coredatastore:stable

docker push stuartshay/coredatastore:stable
```

###Run 

```bash 
   docker pull stuartshay/coredatastore
   docker run --rm --name <containername> -p 5000:5000 stuartshay/coredatastore
```

###Volumes 

```bash 
   docker volume ls
   docker volume rm <VOLUMENAME>
```

##Examine Containers

```bash 
# Get Created DateTime  
docker inspect -f '{{ .Created }}' stuartshay/coredatastore
docker logs <CONATINERID>
```

```bash 
# Examine Filesystem (bash shell)
docker run -i -t --entrypoint /bin/bash <IMAGEID>  
```



