#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["OPLOGInventory/OPLOGInventory.API/OPLOGInventory.API.csproj", "OPLOGInventory/OPLOGInventory.API/"]
COPY ["OPLOGInventory/OPLOGInventory.Application/OPLOGInventory.Application.csproj", "OPLOGInventory/OPLOGInventory.Application/"]
COPY ["OPLOGInventory/OPLOGInventory.Data/OPLOGInventory.Data.csproj", "OPLOGInventory/OPLOGInventory.Data/"]
COPY ["OPLOGInventory/OPLOGInventory.Model/OPLOGInventory.Model.csproj", "OPLOGInventory/OPLOGInventory.Model/"]
COPY ["OPLOGInventory/OPLOGInventory.Repository/OPLOGInventory.Repository.csproj", "OPLOGInventory/OPLOGInventory.Repository/"]
RUN dotnet restore "OPLOGInventory/OPLOGInventory.API/OPLOGInventory.API.csproj"
COPY . .
WORKDIR "/src/OPLOGInventory/OPLOGInventory.API"
RUN dotnet build "OPLOGInventory.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OPLOGInventory.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OPLOGInventory.API.dll"]