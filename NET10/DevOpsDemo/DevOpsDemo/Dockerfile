#FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#
## csproj y Dockerfile están en la misma carpeta en el contexto
#COPY ["DevOpsDemo.Web.csproj", "./"]
#RUN dotnet restore "DevOpsDemo.Web.csproj"
#
## ahora sí copiamos todo el código
#COPY . .
#
#WORKDIR "/src"
#RUN dotnet build "DevOpsDemo.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "DevOpsDemo.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "DevOpsDemo.Web.dll"]
#

# Fase de build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiamos los csproj de Web y Data
#COPY ["DevOpsDemo/DevOpsDemo/DevOpsDemo.Web.csproj", "DevOpsDemo/DevOpsDemo/"]
#COPY ["DevOpsDemo/DevOpsDemo.Data/DevOpsDemo.Data.csproj", "DevOpsDemo/DevOpsDemo.Data/"]
COPY ["DevOpsDemo/DevOpsDemo/DevOpsDemo.Web.csproj", "DevOpsDemo/"]
COPY ["DevOpsDemo/DevOpsDemo.Data/DevOpsDemo.Data.csproj", "DevOpsDemo.Data/"]

# Restauramos dependencias del proyecto web (que ya conoce el Data)
#RUN dotnet restore "DevOpsDemo/DevOpsDemo/DevOpsDemo.Web.csproj"
RUN dotnet restore "DevOpsDemo/DevOpsDemo.Web.csproj"

# Copiamos TODO el código (ahora que el restore está cacheado)
COPY . .

# Nos vamos a la carpeta del proyecto web
WORKDIR "/src/DevOpsDemo/DevOpsDemo"

# Compilamos
RUN dotnet build "DevOpsDemo.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicamos
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DevOpsDemo.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevOpsDemo.Web.dll"]

