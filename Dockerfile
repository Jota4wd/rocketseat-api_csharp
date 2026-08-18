# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos de projeto das 3 camadas para restaurar dependências
COPY ["Products.API/Products.API.csproj", "Products.API/"]
COPY ["Products.Communication/Products.Communication.csproj", "Products.Communication/"]
COPY ["Products.Exceptions/Products.Exceptions.csproj", "Products.Exceptions/"]

RUN dotnet restore "Products.API/Products.API.csproj"

# Copia todo o código-fonte e publica
COPY . .
WORKDIR "/src/Products.API"
RUN dotnet publish "Products.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Products.API.dll"]
