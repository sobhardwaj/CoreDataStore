### Docker Readme

##Usefull Commands 

###Images 

```bash 
    docker images                     #Get List of Images
    docker rmi  -f IMAGEID            #Remove Image 
```

###Containers 

```bash 
    docker ps -a                    #All Containers
    docker ps                       #Running Containers 
    docker stop CONATINERID         #Stop Running Image 
    docker rm  -f IMAGEID           #Remove Image 
```

##Examine Containers

```bash 
# Get Created DateTime  
docker inspect -f '{{ .Created }}' stuartshay/coredatastore 
```

```bash 
# Examine Filesystem (bash shell)
docker run -i -t --entrypoint /bin/bash IMAGEID  
```



