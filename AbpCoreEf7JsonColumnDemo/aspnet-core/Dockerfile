FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["src/AbpCoreEf7JsonColumnDemo.Web.Host/AbpCoreEf7JsonColumnDemo.Web.Host.csproj", "src/AbpCoreEf7JsonColumnDemo.Web.Host/"]
COPY ["src/AbpCoreEf7JsonColumnDemo.Web.Core/AbpCoreEf7JsonColumnDemo.Web.Core.csproj", "src/AbpCoreEf7JsonColumnDemo.Web.Core/"]
COPY ["src/AbpCoreEf7JsonColumnDemo.Application/AbpCoreEf7JsonColumnDemo.Application.csproj", "src/AbpCoreEf7JsonColumnDemo.Application/"]
COPY ["src/AbpCoreEf7JsonColumnDemo.Core/AbpCoreEf7JsonColumnDemo.Core.csproj", "src/AbpCoreEf7JsonColumnDemo.Core/"]
COPY ["src/AbpCoreEf7JsonColumnDemo.EntityFrameworkCore/AbpCoreEf7JsonColumnDemo.EntityFrameworkCore.csproj", "src/AbpCoreEf7JsonColumnDemo.EntityFrameworkCore/"]
WORKDIR "/src/src/AbpCoreEf7JsonColumnDemo.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/AbpCoreEf7JsonColumnDemo.Web.Host", "src/AbpCoreEf7JsonColumnDemo.Web.Host"]
COPY ["src/AbpCoreEf7JsonColumnDemo.Web.Core", "src/AbpCoreEf7JsonColumnDemo.Web.Core"]
COPY ["src/AbpCoreEf7JsonColumnDemo.Application", "src/AbpCoreEf7JsonColumnDemo.Application"]
COPY ["src/AbpCoreEf7JsonColumnDemo.Core", "src/AbpCoreEf7JsonColumnDemo.Core"]
COPY ["src/AbpCoreEf7JsonColumnDemo.EntityFrameworkCore", "src/AbpCoreEf7JsonColumnDemo.EntityFrameworkCore"]
WORKDIR "/src/src/AbpCoreEf7JsonColumnDemo.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "AbpCoreEf7JsonColumnDemo.Web.Host.dll"]
