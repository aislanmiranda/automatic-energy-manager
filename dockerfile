# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# USER $APP_UID 
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Api/Api.csproj", "Api/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]

# Limpar cache do NuGet e restaurar dependências com log detalhado
RUN dotnet nuget locals all --clear
RUN dotnet restore "Api/Api.csproj" --verbosity detailed
COPY . .
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

# Etapa 2: Imagem Final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# COPY Api/wwwroot ./wwwroot
# RUN mkdir -p ./wwwroot

# Configurar o ponto de entrada
ENTRYPOINT ["dotnet", "Api.dll"]
