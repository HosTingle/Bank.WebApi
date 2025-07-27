#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Bank.WebApi/Banka.WebApi.csproj", "Bank.WebApi/"]
COPY ["Banka.İs/Banka.İs.csproj", "Banka.İs/"]
COPY ["Banka.Cekirdek/Banka.Cekirdek.csproj", "Banka.Cekirdek/"]
COPY ["Banka.Varlıklar/Banka.Varlıklar.csproj", "Banka.Varlıklar/"]
COPY ["Banka.VeriErisimi/Banka.VeriErisimi.csproj", "Banka.VeriErisimi/"]
RUN dotnet restore "./Bank.WebApi/Banka.WebApi.csproj"
COPY . .
WORKDIR "/src/Bank.WebApi"
RUN dotnet build "./Banka.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Banka.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Banka.WebApi.dll"]