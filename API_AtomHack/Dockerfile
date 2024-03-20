#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app/publish
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https -ep API_AtomHack.pfx  -p crypticpassword
WORKDIR /src
COPY ["API_AtomHack/API_AtomHack.csproj", "API_AtomHack/"]
RUN dotnet restore "./API_AtomHack/API_AtomHack.csproj"
COPY . .
WORKDIR "/src/API_AtomHack"
RUN dotnet build "./API_AtomHack.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API_AtomHack.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
USER root
RUN chmod og+r API_AtomHack.pfx
WORKDIR /app/wwwroot
RUN chmod 777 files -R
RUN chown www-data files -R
RUN chgrp www-data files -R
USER app
WORKDIR /app
ENTRYPOINT ["dotnet", "API_AtomHack.dll"]