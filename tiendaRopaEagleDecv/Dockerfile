
# Imagen base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Imagen de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos todo el código al contenedor
COPY . .

# Restauramos dependencias
RUN dotnet restore tiendaRopaEagleDecv.csproj

# Compilamos el proyecto
RUN dotnet build tiendaRopaEagleDecv.csproj -c Release -o /app/build

# Publicamos
FROM build AS publish
RUN dotnet publish tiendaRopaEagleDecv.csproj -c Release -o /app/publish /p:UseAppHost=false

# Imagen final de producción
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tiendaRopaEagleDecv.dll"]
