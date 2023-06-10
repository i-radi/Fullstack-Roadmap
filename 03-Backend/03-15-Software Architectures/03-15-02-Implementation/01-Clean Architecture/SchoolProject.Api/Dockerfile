#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SchoolProject.Api/SchoolProject.Api.csproj", "SchoolProject.Api/"]
COPY ["SchoolProject.Core/SchoolProject.Core.csproj", "SchoolProject.Core/"]
COPY ["SchoolProject.Data/SchoolProject.Data.csproj", "SchoolProject.Data/"]
COPY ["SchoolProject.Infrustructure/SchoolProject.Infrustructure.csproj", "SchoolProject.Infrustructure/"]
COPY ["SchoolProject.Service/SchoolProject.Service.csproj", "SchoolProject.Service/"]
RUN dotnet restore "SchoolProject.Api/SchoolProject.Api.csproj"
COPY . .
WORKDIR "/src/SchoolProject.Api"
RUN dotnet build "SchoolProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolProject.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolProject.Api.dll"]