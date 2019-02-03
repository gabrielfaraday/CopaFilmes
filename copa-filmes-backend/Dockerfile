FROM microsoft/dotnet:2.2-sdk-alpine AS build-env
WORKDIR /app

COPY . ./
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=build-env /app/src/CopaFilmes.Api/out .
ENTRYPOINT ["dotnet", "CopaFilmes.Api.dll"]