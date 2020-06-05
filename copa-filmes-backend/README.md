# Copa Filmes - Backend

A aplicação backend foi desenvolvida com ASP.NET Core 3.1.

## Testes

### CLI

Para executar os testes via CLI, acesse na linha de comando a pasta raiz onde está a solution e execute os seguintes comandos:

    dotnet test

Para executar os teste e gerar um relatório de coverage execute:

    dotnet test //p:CollectCoverage=true //p:CoverletOutputFormat=OpenCover (para Windows)

Para visualizar o relatório completo instale a tool necessária:

    dotnet tool install -g dotnet-reportgenerator-globaltool
    dotnet tool install dotnet-reportgenerator-globaltool --tool-path tools

E gere o report:

    reportgenerator "-reports:tests\coverage.opencover.xml" "-targetdir:tests\reports" "-sourcedirs:src/" -reporttypes:HTML;Cobertura

O report estará diposnivel em tests/reports/index.html

 
## Subindo a aplicação

### CLI

Para executar a aplicação via linha de comando, acesse a pasta raiz onde está a solution e execute o seguinte comando:

    dotnet run -p src/CopaFilmes.Api/

Health check: http://localhost:5000/health

Swagger: http://localhost:5000/swagger

### Docker

Para executar a aplicação via Docker, na linha de comando acesse a pasta raiz onde está a solution e execute o seguinte comando:

    docker build . -t copa-back

Após a conclusão do processo com sucesso, execute:

    docker run -d -p 5000:5000 copa-back

Health check: http://localhost:5000/health

Swagger: http://localhost:5000/swagger
