FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

RUN dotnet --version

COPY *.sln .
COPY TODO.API/*.csproj ./TODO.API/
COPY TODO.Domain/*.csproj ./TODO.Domain/
COPY TODO.Infra/*.csproj ./TODO.Infra/

RUN dotnet restore

COPY TODO.API/. ./TODO.API/
COPY TODO.Domain/. ./TODO.Domain/
COPY TODO.Infra/. ./TODO.Infra/

WORKDIR /app
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "TODO.API.dll" ]