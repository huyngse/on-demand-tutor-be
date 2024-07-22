FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source


COPY BE_SWP391_OnDemandTutor.sln ./
COPY BE_SWP391_OnDemandTutor.API/*.csproj ./BE_SWP391_OnDemandTutor.API/
COPY BE_SWP391_OnDemandTutor.BusinessLogic/*.csproj ./BE_SWP391_OnDemandTutor.BusinessLogic/
COPY BE_SWP391_OnDemandTutor.DataAccess/*.csproj ./BE_SWP391_OnDemandTutor.DataAccess/
COPY BE_SWP391_OnDemandTutor.Common/*.csproj ./BE_SWP391_OnDemandTutor.Common/

COPY . ./

WORKDIR /source/BE_SWP391_OnDemandTutor.API
RUN dotnet clean
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "BE_SWP391_OnDemandTutor.API.dll"]