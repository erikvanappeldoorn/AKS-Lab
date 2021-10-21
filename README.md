# AKS-Lab

## Introduction

In this lab we are going to create some WebApi REST services, Containerize them and store the images into a Azure Container Registry and deploy them to Azure Kubernetes Services. But we will take it step by step.

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

- A spec, with image set to the local image (use e.g. service-nl:v1, and service-no:v1 )
- Number of replicas: 1
- A Service with port 80 and type ClusterIP

To test your deployment in your local Docker Desktop Kubernetes cluster perform:

`kubectl apply -f service-nl-local-deployment.yaml`

and

`kubectl port-forward deploy/service-nl-deployment 5000:80`

and browse to `http://localhost:5000/greeting`

- Do the same for the service-no WebAPi.

## 3. Azure Container Registry

- Create an Azure Container Registry (in the portal). Please note the login server name.
- From the Azure CLI terminal log in to Azure: `az login`
- From the Azure CLI termin log in to ACR: e.g. `az acr login --name [edit acr name].azurecr.io` 
- Retag you service images to `[edit acr name].azurecr.io/service-nl:v1` and  `[edit acr name].azurecr.io/service-no:v1`
- Use `docker push` to upload both service images to your Azure Container Registry. 
- Verify in the Azure portal you can find two repositories with the images.

## 4. Create an Azure Kubernetes Service with ACR integration.

- Create an Azure Kubernetes Service (in the portal)
- Make sure you use the same resource group as the ACR resource group
- In the Integrations tab make sure you select the ACR
- Explore the AKS cluster using the portal

## 5. Deploy a WebApi to the AKS Cluster

Everything is now in place to perform a deployment to the AKS service. The next step is to take a WebApi image and deploy it to the cluster in Azure.

- We are going to download the AKS connection details by performing the acr credentials command: `az aks get-credentials -g [edit resource group name] -n [AKS cluster name]`

e.g. `az aks get-credentials -g aks-lab -n aks-lab`

- Now we have two different K8S contexts: Docker Desktop and AKS, to get an overview of all available contexts: `kubectl config get-contexts` . Make sure your AKS cluster is the active cluster (it should have an asterix before it's name). If not you can switch contexts by: `kubectl config use-context [edit name of context]`

- On AKS the service image will be pulled from the ACR, so we will have to change the Kubernetes deploument manifest file. Make a copy of the service-no-deployment.yaml called: service-no-deployment-acr.yaml.

- In this file replace the image name by the image name used on ACR.
- To make the service public available we change the service type from ClusterIP to LoadBalancer.
- After we have made these changes we can perform the deployment by using the kubectl apply command:

`kubectl apply -f service-no-deployment-acr.yaml`

- Explore the Kubernetes Resource blade in the portal to check the status of the deployment. Especially the Workloads & Services and Ingresses tab contain a lot of information and can help you pinpoint to issues related to the deployment.

- On the Kubernetes resources blad select the Services and Ingresses Tab. Look for the Loadbalancer service and copy the External IP address to your clipboard.

- To test the web api on the AKS cluster open a browser and use the URL: https://[edit external ip address]/greeting. If the deployment was succeful you should see the text: "Hei, alle fra ITUMX !"






