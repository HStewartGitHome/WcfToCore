---
title: WcfToCore Readme
---

By Stewart Hyde
===============

Introduction
============

I design this GitHub project as an experiment to see what it takes to call WCF
services in .Net 5 projects. The basically idea is provide an upgrade path from
.Net Framework and still keep the same code.

Client side uses .Net 5 ServiceModel using web address for the service.
Server-side modifications use SoapCore NuGet package and a lot of inspiration
for this code was found on SoapCore GitHub page and especially examples.

[GitHub - DigDes/SoapCore: SOAP extension for ASP.NET
Core](https://github.com/DigDes/SoapCore)

I took the following steps:

1. Created .Net Framework 4.72 project with WPF client and WPF Self Host.

2. Created .Net 5 WPF base on 4.72 project and use technique shown in examples.

3. Once I got above working, I created SoapCore Host and made modifications for
services

4. I tried this on Microsoft Blazor projects

>   1. Blazor Web assembly Hosted was first attempt, and it works fine.

>   2. Blazor Web assembly - had trouble and needs more research but believe it
>   related to Wasm not support ServiceModel.

>   3. I also created Blazor Server

5. Also included is command line test application.

One special note, I was able to get both WCF Hosted and SoapCore Hosted to work
at same service on clients, but the names of service must be same name space.

The following is example screen from WPF 5 application running test.

![](media/073884bfb3e9a1b5db5db19221160332.png)

The Following is example screen from WPF Framework application running test

![](media/f91e11d2e3696c003342fb5a9658b1d8.png)

The Following is example screen from Blazor Web assembly Hosted running test

![](media/bb38f6aec541eff302508d096c3cd75a.png)

The following is example screen from Blazor Server running test

![](media/ceb3feff0b451c2df43e4d64ca7a570f.png)

The following is the command line test application.

![](media/e44fddb42a8e7258070082501665f025.png)

The following output is from SoapCore host application.

![](media/ffd78d0213272c2cf9b173317e9ec488.png)
