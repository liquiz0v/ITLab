FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env

RUN mkdir /app
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish --configuration Release -o out

FROM mcr.microsoft.com/dotnet/core/sdk:3.0
WORKDIR /app
EXPOSE 5000/tcp
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "ITLab.dll" ]