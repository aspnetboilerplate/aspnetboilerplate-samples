FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/SimpleTaskSystem.Web.Host/SimpleTaskSystem.Web.Host.csproj", "src/SimpleTaskSystem.Web.Host/"]
COPY ["src/SimpleTaskSystem.Web.Core/SimpleTaskSystem.Web.Core.csproj", "src/SimpleTaskSystem.Web.Core/"]
COPY ["src/SimpleTaskSystem.Application/SimpleTaskSystem.Application.csproj", "src/SimpleTaskSystem.Application/"]
COPY ["src/SimpleTaskSystem.Core/SimpleTaskSystem.Core.csproj", "src/SimpleTaskSystem.Core/"]
COPY ["src/SimpleTaskSystem.EntityFrameworkCore/SimpleTaskSystem.EntityFrameworkCore.csproj", "src/SimpleTaskSystem.EntityFrameworkCore/"]
WORKDIR "/src/src/SimpleTaskSystem.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/SimpleTaskSystem.Web.Host", "src/SimpleTaskSystem.Web.Host"]
COPY ["src/SimpleTaskSystem.Web.Core", "src/SimpleTaskSystem.Web.Core"]
COPY ["src/SimpleTaskSystem.Application", "src/SimpleTaskSystem.Application"]
COPY ["src/SimpleTaskSystem.Core", "src/SimpleTaskSystem.Core"]
COPY ["src/SimpleTaskSystem.EntityFrameworkCore", "src/SimpleTaskSystem.EntityFrameworkCore"]
WORKDIR "/src/src/SimpleTaskSystem.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "SimpleTaskSystem.Web.Host.dll"]
