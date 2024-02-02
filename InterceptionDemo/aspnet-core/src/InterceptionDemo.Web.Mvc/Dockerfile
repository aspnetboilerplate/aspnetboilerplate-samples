FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/InterceptionDemo.Web.Mvc/InterceptionDemo.Web.Mvc.csproj", "src/InterceptionDemo.Web.Mvc/"]
COPY ["src/InterceptionDemo.Web.Core/InterceptionDemo.Web.Core.csproj", "src/InterceptionDemo.Web.Core/"]
COPY ["src/InterceptionDemo.Application/InterceptionDemo.Application.csproj", "src/InterceptionDemo.Application/"]
COPY ["src/InterceptionDemo.Core/InterceptionDemo.Core.csproj", "src/InterceptionDemo.Core/"]
COPY ["src/InterceptionDemo.EntityFrameworkCore/InterceptionDemo.EntityFrameworkCore.csproj", "src/InterceptionDemo.EntityFrameworkCore/"]
WORKDIR "/src/src/InterceptionDemo.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/InterceptionDemo.Web.Mvc", "src/InterceptionDemo.Web.Mvc"]
COPY ["src/InterceptionDemo.Web.Core", "src/InterceptionDemo.Web.Core"]
COPY ["src/InterceptionDemo.Application", "src/InterceptionDemo.Application"]
COPY ["src/InterceptionDemo.Core", "src/InterceptionDemo.Core"]
COPY ["src/InterceptionDemo.EntityFrameworkCore", "src/InterceptionDemo.EntityFrameworkCore"]
WORKDIR "/src/src/InterceptionDemo.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "InterceptionDemo.Web.Mvc.dll"]
