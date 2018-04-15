Kendo has a very powerful grid system that serves perfectly in almost all projects. Recently I encountered a problem that took a while find a solution. In a microservice architecture I wanted to pass the Kendo request source to the microservice responsible for the data in the grid. I needed the call to be from the code behind of the client and didn't want to call the microservice from the grid directly for several internal reasons to the project I was working on. 

This repo shows how to do that with ASP.NET Kendo Grids. 

Kendo requires license so you will need to include your own kendo library and include it in order to use the repo.