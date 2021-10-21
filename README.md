# AKS-Lab

## Introduction

In this lab we are going to create some services (WebApis) with the final goal to deploy them to store the images into Azure Container Registry and deploy them to Azure Kubernetes Services. But we will take it step by step.

## 1a. Create the service-nl

Create a .NET 5 WebApi project called service-nl, make sure:
- To add a Dockerfile
- To deselect HTTPS redirection
- The WebAPi project should only have one controller (GreetController) with one GET action (Greet) returning the string  "Hallo, iedereen van ITUMX !"

- Test your project locally
- Create the docker image with the name service-nl
- Run the container: `docker run -d -p:5000:80 service-no` 
- Test your service in the browser: `http://localhost:5000/greeting`
- When ready stop and remove the docker container

## 1b. Create the service-no

(Note: This is almost a copy of the service-nl WebApi)

Create a .NET 5 WebApi project called service-no, make sure:
- To add a Dockerfile
- To deselect HTTPS redirection
- The WebAPi project should only have one controller (GreetController) with one GET action (Greet) returning the string  ""Hei, alle fra ITUMX !"

- Test your project locally
- Create the docker image with the name service-nl
- Run the container: `docker run -d -p:5001:80 service-no` 
- Test your service in the browser: `http://localhost:5001/greeting`
- When ready stop and remove the docker container

## 2. Run your services in a local Kubernetes cluster

Create a K8s deployment file for each service, use the names:
-  service-nl-deployment.yaml and
-  service-no-deployment.yaml

each deployment file should include:

- A spec, with image set to the local image (e.g. use service-nl:v1, and service-no:v1 )
- Number of replicas: 1
- A Service with port 80 and type ClusterIP

To Test your local service deployment by performing e.g.:

`kubectl apply -f service-nl-local-deployment.yaml`

and

`kubectl port-forward deploy/service-nl-deployment 5000:80`

and browse to `http://localhost:5000/greeting`

## 3. Azure Container Registry

- Create an Azure Container Registry (in the portal). Please note the login server name.
- From the Azure CLI terminal log in to Azure: `az login`
- From the Azure CLI termin log in to ACR: e.g. `az acr login --name [edit acr name].azurecr.io` 
- Retag you service images to `[edit acr name].azurecr.io/service-nl:v1` and  `[edit acr name].azurecr.io/service-no:v1`
- Use `docker push` to upload both service images to your Azure Container Registry. 
- Verify in the Azure portal you can find two repositories with the images.
