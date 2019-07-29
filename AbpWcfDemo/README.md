## This is a simple WCF/SOAP application using ASP.NET Boilerplate. 

It uses Castle Wcf Integration Facility for supporting WCF services with injection.

It exposes 2 WCF/SOAP services:

1. SimpleService.cs / MySimpleEcho.svc - A basic echo services (does not use ABP)
2. EventsSoapService.cs / MyFirstAbp.svc - A simple service using ABP application servce

WCF services are exposes as:

1. http://localhost:61754/Soap/MySimpleEcho.svc
2. http://localhost:61754/Soap/MyFirstAbp.svc

### Before running the application:

* Set AbpWcfDemo.Web as startup project.
* Open the file MyFirstAbp.svc or SimpleService.svc.
* Run the web application.


