FROM mcr.microsoft.com/dotnet/core/sdk:3.1.300-alpine3.11 AS build-env

WORKDIR /app

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.4-alpine3.11

WORKDIR /app

COPY --from=build-env /app/out .

HEALTHCHECK --interval=30s --timeout=2s --retries=3 CMD curl --silent --fail http://localhost:5000/health || exit 1

EXPOSE 5000

ENTRYPOINT ["dotnet", "CopaFilmes.Api.dll"]