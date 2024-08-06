FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/MultipleDbContextEfCoreDemo.Web.Host/MultipleDbContextEfCoreDemo.Web.Host.csproj", "src/MultipleDbContextEfCoreDemo.Web.Host/"]
COPY ["src/MultipleDbContextEfCoreDemo.Web.Core/MultipleDbContextEfCoreDemo.Web.Core.csproj", "src/MultipleDbContextEfCoreDemo.Web.Core/"]
COPY ["src/MultipleDbContextEfCoreDemo.Application/MultipleDbContextEfCoreDemo.Application.csproj", "src/MultipleDbContextEfCoreDemo.Application/"]
COPY ["src/MultipleDbContextEfCoreDemo.Core/MultipleDbContextEfCoreDemo.Core.csproj", "src/MultipleDbContextEfCoreDemo.Core/"]
COPY ["src/MultipleDbContextEfCoreDemo.EntityFrameworkCore/MultipleDbContextEfCoreDemo.EntityFrameworkCore.csproj", "src/MultipleDbContextEfCoreDemo.EntityFrameworkCore/"]
WORKDIR "/src/src/MultipleDbContextEfCoreDemo.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/MultipleDbContextEfCoreDemo.Web.Host", "src/MultipleDbContextEfCoreDemo.Web.Host"]
COPY ["src/MultipleDbContextEfCoreDemo.Web.Core", "src/MultipleDbContextEfCoreDemo.Web.Core"]
COPY ["src/MultipleDbContextEfCoreDemo.Application", "src/MultipleDbContextEfCoreDemo.Application"]
COPY ["src/MultipleDbContextEfCoreDemo.Core", "src/MultipleDbContextEfCoreDemo.Core"]
COPY ["src/MultipleDbContextEfCoreDemo.EntityFrameworkCore", "src/MultipleDbContextEfCoreDemo.EntityFrameworkCore"]
WORKDIR "/src/src/MultipleDbContextEfCoreDemo.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MultipleDbContextEfCoreDemo.Web.Host.dll"]
