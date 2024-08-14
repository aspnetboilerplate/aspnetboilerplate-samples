FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/MultipleDbContextEfCoreDemo.Web.Mvc/MultipleDbContextEfCoreDemo.Web.Mvc.csproj", "src/MultipleDbContextEfCoreDemo.Web.Mvc/"]
COPY ["src/MultipleDbContextEfCoreDemo.Web.Core/MultipleDbContextEfCoreDemo.Web.Core.csproj", "src/MultipleDbContextEfCoreDemo.Web.Core/"]
COPY ["src/MultipleDbContextEfCoreDemo.Application/MultipleDbContextEfCoreDemo.Application.csproj", "src/MultipleDbContextEfCoreDemo.Application/"]
COPY ["src/MultipleDbContextEfCoreDemo.Core/MultipleDbContextEfCoreDemo.Core.csproj", "src/MultipleDbContextEfCoreDemo.Core/"]
COPY ["src/MultipleDbContextEfCoreDemo.EntityFrameworkCore/MultipleDbContextEfCoreDemo.EntityFrameworkCore.csproj", "src/MultipleDbContextEfCoreDemo.EntityFrameworkCore/"]
WORKDIR "/src/src/MultipleDbContextEfCoreDemo.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/MultipleDbContextEfCoreDemo.Web.Mvc", "src/MultipleDbContextEfCoreDemo.Web.Mvc"]
COPY ["src/MultipleDbContextEfCoreDemo.Web.Core", "src/MultipleDbContextEfCoreDemo.Web.Core"]
COPY ["src/MultipleDbContextEfCoreDemo.Application", "src/MultipleDbContextEfCoreDemo.Application"]
COPY ["src/MultipleDbContextEfCoreDemo.Core", "src/MultipleDbContextEfCoreDemo.Core"]
COPY ["src/MultipleDbContextEfCoreDemo.EntityFrameworkCore", "src/MultipleDbContextEfCoreDemo.EntityFrameworkCore"]
WORKDIR "/src/src/MultipleDbContextEfCoreDemo.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MultipleDbContextEfCoreDemo.Web.Mvc.dll"]
