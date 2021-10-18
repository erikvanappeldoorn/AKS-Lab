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

## Run your services is a local Kubernetes cluster




