#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MatchManagementWebAPI/MatchManagementWebAPI.csproj", "MatchManagementWebAPI/"]
RUN dotnet restore "MatchManagementWebAPI/MatchManagementWebAPI.csproj"
COPY . .
WORKDIR "/src/MatchManagementWebAPI"
RUN dotnet build "MatchManagementWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MatchManagementWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MatchManagementWebAPI.dll"]