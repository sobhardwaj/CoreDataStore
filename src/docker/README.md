### Docker Readme

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
    docker rm  -f <CONATINERID>     #Remove Container
```

###Publish

```bash 
docker tag coredatastore stuartshay/coredatastore
docker push stuartshay/coredatastore:latest
```

###Run 

```bash 
   docker pull stuartshay/coredatastore
   docker run --rm --name <containername> -p 5000:5000 stuartshay/coredatastore
```



##Examine Containers

```bash 
# Get Created DateTime  
docker inspect -f '{{ .Created }}' stuartshay/coredatastore 
```

```bash 
# Examine Filesystem (bash shell)
docker run -i -t --entrypoint /bin/bash <IMAGEID>  
```



