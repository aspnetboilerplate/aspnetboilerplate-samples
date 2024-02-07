FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/InterceptionDemo.Web.Host/InterceptionDemo.Web.Host.csproj", "src/InterceptionDemo.Web.Host/"]
COPY ["src/InterceptionDemo.Web.Core/InterceptionDemo.Web.Core.csproj", "src/InterceptionDemo.Web.Core/"]
COPY ["src/InterceptionDemo.Application/InterceptionDemo.Application.csproj", "src/InterceptionDemo.Application/"]
COPY ["src/InterceptionDemo.Core/InterceptionDemo.Core.csproj", "src/InterceptionDemo.Core/"]
COPY ["src/InterceptionDemo.EntityFrameworkCore/InterceptionDemo.EntityFrameworkCore.csproj", "src/InterceptionDemo.EntityFrameworkCore/"]
WORKDIR "/src/src/InterceptionDemo.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/InterceptionDemo.Web.Host", "src/InterceptionDemo.Web.Host"]
COPY ["src/InterceptionDemo.Web.Core", "src/InterceptionDemo.Web.Core"]
COPY ["src/InterceptionDemo.Application", "src/InterceptionDemo.Application"]
COPY ["src/InterceptionDemo.Core", "src/InterceptionDemo.Core"]
COPY ["src/InterceptionDemo.EntityFrameworkCore", "src/InterceptionDemo.EntityFrameworkCore"]
WORKDIR "/src/src/InterceptionDemo.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "InterceptionDemo.Web.Host.dll"]
