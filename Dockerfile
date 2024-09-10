FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /api

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /appbuild

COPY . .
RUN dotnet restore
WORKDIR /appbuild/Lab1PRN231API
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /api
COPY --from=build /appbuild/Lab1PRN231API/out .
ENTRYPOINT ["dotnet", "Lab1PRN231API.dll"]