# Imagen base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Imagen de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar todo el código
COPY . .

# Restaurar dependencias
RUN dotnet restore tiendaRopaEagleDecv.csproj

# Compilar
RUN dotnet build tiendaRopaEagleDecv.csproj -c Release -o /app/build

# Publicar
FROM build AS publish
RUN dotnet publish tiendaRopaEagleDecv.csproj -c Release -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tiendaRopaEagleDecv.dll"]
