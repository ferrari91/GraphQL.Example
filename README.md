# GraphQL.Example
## Descrição
Consiste em uma API capaz de realizar crud em GraphQL. 
Pode ser util como base de estudo para utilização do Graophql.

## Objetivo
Cadastrar uma entidade Person com os seguintes registros Id, Name e Age pelo mutation do Graphql e obter um cadastro especifico pelo ID ou todos os Registros incluso na tabela Person.

## Utilizando a API
Mutation:

![image](https://github.com/ferrari91/GraphQL.Example/assets/54671169/5c23e971-19ab-42de-9999-e14670e724dd)

Query:

![image](https://github.com/ferrari91/GraphQL.Example/assets/54671169/96258ffe-2581-4380-bfe0-5159c22d39fe)

![image](https://github.com/ferrari91/GraphQL.Example/assets/54671169/4455d8ce-3880-4f2e-b0ee-743c051689a5)

maiores informações consultar o Schema e Docs no graphql da aplicação.

## Executando Docker
Para executar a api é necessário utilizar os seguintes comandos.
comando utilizado para criar a imagem no docker -> docker build -t graphql-example -f GraphQL.Example/Dockerfile .
docmando utilizado para criar e executar um container -> docker run -d -p 5000:80 --name graphql-example-container graphql-example

Após a execução dos comandos basta acessar a url: http://localhost:5000/ui/graphql

