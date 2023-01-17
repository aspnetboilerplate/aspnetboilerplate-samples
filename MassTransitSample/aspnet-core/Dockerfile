FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["src/MassTransitSample.Web.Host/MassTransitSample.Web.Host.csproj", "src/MassTransitSample.Web.Host/"]
COPY ["src/MassTransitSample.Web.Core/MassTransitSample.Web.Core.csproj", "src/MassTransitSample.Web.Core/"]
COPY ["src/MassTransitSample.Application/MassTransitSample.Application.csproj", "src/MassTransitSample.Application/"]
COPY ["src/MassTransitSample.Core/MassTransitSample.Core.csproj", "src/MassTransitSample.Core/"]
COPY ["src/MassTransitSample.EntityFrameworkCore/MassTransitSample.EntityFrameworkCore.csproj", "src/MassTransitSample.EntityFrameworkCore/"]
WORKDIR "/src/src/MassTransitSample.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/MassTransitSample.Web.Host", "src/MassTransitSample.Web.Host"]
COPY ["src/MassTransitSample.Web.Core", "src/MassTransitSample.Web.Core"]
COPY ["src/MassTransitSample.Application", "src/MassTransitSample.Application"]
COPY ["src/MassTransitSample.Core", "src/MassTransitSample.Core"]
COPY ["src/MassTransitSample.EntityFrameworkCore", "src/MassTransitSample.EntityFrameworkCore"]
WORKDIR "/src/src/MassTransitSample.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MassTransitSample.Web.Host.dll"]
