# How to Install Splunk in Docker Compose


Running Splunk using Docker Compose involves creating a docker-compose.yml file with the necessary configurations. Splunk provides an official Docker image that you can use. Here's a simple example:


Create a docker-compose.yml file: Open a text editor and create a docker-compose.yml file with the following content: yaml  

```Docker
 		services:
 		  splunk:
 		    image: splunk/splunk:latest
 		    container_name: splunk
 		    environment:
 		      - SPLUNK_START_ARGS=--accept-license
 		      - SPLUNK_PASSWORD=<your_splunk_admin_password>
 		    ports:
 		      - "8000:8000"
 		      - "8088:8088"
 		    volumes:
 		      - splunk-data:/opt/splunk/var
 		volumes:
 		  splunk-data:
```

**NOTE** : Replace <your_splunk_admin_password> with the desired password for the Splunk admin account.


1. Run Splunk using Docker Compose: Open a terminal, navigate to the directory containing the docker-compose.yml file, and run the following command:

``` bash
  docker-compose up -d
```

2.  This command pulls the Splunk image, creates a container named "splunk," and starts it in the background.
3. Access Splunk Web Interface: Once the Splunk container is running, you can access the Splunk Web Interface by opening a web browser and navigating to http://localhost:8000.
4. Log in with the username admin and the password you specified in the docker-compose.yml file.
5. Stop and Remove the Splunk Container: When you're done using Splunk, you can stop and remove the container using the following command:

``` bash  
docker-compose down
```

   This stops and removes the Splunk container. If you want to remove the data volume as well, you can

```bash
docker-compose down -v
```
   This removes the container and the associated data volume.
