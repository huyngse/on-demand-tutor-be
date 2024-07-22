#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ["BE_SWP391_OnDemandTutor.API/BE_SWP391_OnDemandTutor.API.csproj", "BE_SWP391_OnDemandTutor.API/"]
COPY ["BE_SWP391_OnDemandTutor.BusinessLogic/BE_SWP391_OnDemandTutor.BusinessLogic.csproj", "BE_SWP391_OnDemandTutor.BusinessLogic/"]
COPY ["BE_SWP391_OnDemandTutor.DataAccess/BE_SWP391_OnDemandTutor.DataAccess.csproj", "BE_SWP391_OnDemandTutor.DataAccess/"]
COPY ["BE_SWP391_OnDemandTutor.Common/BE_SWP391_OnDemandTutor.Common.csproj", "BE_SWP391_OnDemandTutor.Common/"]
RUN dotnet restore "BE_SWP391_OnDemandTutor.API/BE_SWP391_OnDemandTutor.API.csproj"
COPY . .
WORKDIR "/src/BE_SWP391_OnDemandTutor.API"
RUN dotnet build "BE_SWP391_OnDemandTutor.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BE_SWP391_OnDemandTutor.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BE_SWP391_OnDemandTutor.API.dll"]
