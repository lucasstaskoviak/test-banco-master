# Travels API
Este projeto consiste em uma API RESTful desenvolvida em .NET 6 com o padrão Clean Architecture. A API é responsável pela criação e gerenciamento de rotas de viagem e inclui funcionalidades para calcular a rota mais barata entre dois destinos.

## Funcionalidades
- CRUD de Rotas: Criação, leitura, atualização e exclusão de rotas de viagem.
- Cálculo de Rota Mais Barata: Um endpoint que encontra a rota mais barata entre dois destinos usando o algoritmo de Dijkstra.

## Tecnologias e Frameworks Utilizados
- .NET 6: Framework principal para desenvolvimento da API.
- MVC (Model-View-Controller): Arquitetura usada para separar responsabilidades e manter o código organizado.
- Clean Architecture: Estrutura do projeto baseada em princípios de arquitetura limpa para promover desacoplamento e facilitar a manutenção.
- XUnit: Framework de testes utilizado para garantir a qualidade e o funcionamento correto da aplicação.
- FluentAssertions: Biblioteca para facilitar as asserções nos testes unitários, tornando-os mais legíveis e expressivos.
- Moq: Biblioteca usada para criar mocks em testes unitários, permitindo a simulação de comportamentos em dependências externas.

## Estrutura do Projeto
O projeto é organizado utilizando o padrão Clean Architecture e contém as seguintes pastas:
- Travels.Api: Contém os controladores e configurações da API REST.
- Travels.Application: Contém a lógica de negócios, interfaces de serviços e DTOs.
- Travels.Domain: Contém as entidades do domínio e as regras de negócios.
- Travels.Infrastructure: Contém a implementação de repositórios e interações com bancos de dados, incluindo a implementação do repositório em memória.
- Travels.Test: Contém os testes unitários da aplicação.

## Endpoints

- POST /routes

Cria uma nova rota de viagem.

Resposta:

- Código 201: Rota criada com sucesso.

------------------------------------------------

- GET /routes

Obtém todas as rotas cadastradas.

Resposta:

- Código 200: Retorna uma lista de rotas.

------------------------------------------------

- GET /routes/{id}

Obtém uma rota específica pelo ID.

Resposta:

- Código 200: Retorna a rota solicitada.

- Código 404: Rota não encontrada.

------------------------------------------------
- PUT /routes/{id}

Atualiza uma rota existente.

Resposta:

- Código 200: Rota atualizada com sucesso.

- Código 404: Rota não encontrada.

------------------------------------------------

- DELETE /routes/{id}

Deleta uma rota pelo ID.

Resposta:

- Código 204: Rota deletada com sucesso.

- Código 404: Rota não encontrada.

------------------------------------------------

- GET /routes/cheapest/from/{from}/to/{to}
  
Calcula a rota mais barata entre dois destinos.

Parâmetros da URL:

- from: Local de origem.

- to: Local de destino.

Resposta:

- Código 200: Retorna a rota mais barata, incluindo o caminho e o custo total.

- Código 404: Se não for possível encontrar uma rota.


## Testes
O projeto inclui testes unitários para as funcionalidades principais, como:
- Testes de CRUD: Verificação das operações de criação, leitura, atualização e exclusão de rotas.
- Testes de Cálculo da Rota Mais Barata: Verificação do algoritmo de Dijkstra para garantir que a rota mais barata seja calculada corretamente.


## Rodando a aplicação
Para rodar a aplicação localmente:

***Atenção!!!***
```
É necessário ter o .Net 6 instalado e sua respectiva SDK.

Para instalar siga as instruções da página a seguir: https://dotnet.microsoft.com/pt-br/download/dotnet/6.0
```

------------------------------------------------

- Depois disso, clone o repositório:
```
    git clone https://github.com/lucasstaskoviak/test-banco-master.git
```

- Navegue até a pasta raiz do projeto:
```
    cd test-banco-master
```

- Restaure as dependências:
```
    dotnet restore
```

- Construa a aplicação:
```
    dotnet build
```

- Execute a API:
```
    dotnet run --project src/Travels.Api
```

Assim que o projeto for iniciado, um banco de dados em memória será criado. Esse banco possue dados relativos ao test case imposto pela empresa. Toda vez que o projeto roda, esses dados são gerados novamente.

A API estará disponível em https://localhost:7113/swagger.


## Rodando os testes
Para rodar os teste:

- Navegue até a pasta raiz do projeto:
```
    cd test-banco-master
```

- Execute o comando:
```
    dotnet test
```

## Melhorias possíveis
- Utilizar docker-compose para fazer o orquestramento de containers;
- Adicionar mecanismo de log (Serilog);
- Utilizar um banco de dados para persistência de dados;
- Utilizar Entity Framework para mapeamento objeto-relacional;
- Utilizar conceito de cache;
- Criar pipeline para executar testes e build automaticamente;
- Criar DTO's específicos para cada tipo de representação de entidades;
- Criar interfaces para os UsesCase e incluir na comunicação com o Controller;
- Acrescentar regras faltantes de validação;
- Implementar ou usar alguma library para lidar com erros de maneira mais eficiente;
- Melhorar documentação de API's e utilizar SwaggerRequestExample;
- Teste de integração;
- Padronizar/Annotations propriedades das entidades;
- Criar uma entidade específica para o preço, com uma trativa mais inteligente sobre valores;
- Adicionar JWT para autenticação.