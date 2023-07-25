# Vitrine de Usados

## Esse projeto utiliza as seguintes tecnologias: 
API:
- .NET 6
- Entity Framework Core
- EF Migrations
- SQLite
- Token JWT

Front:
- Angular 16.1.5
- Angular Material

Para rodar é necessário: .net6, node, npm, angular-cli

## Como Rodar o Projeto:
1. Abra uma janela de terminal, vá até a pasta VitrineUsadosAPI e digite o comando `dotnet run`
2. Certifique-se na saida que a API está executando na porta 5029 através da informação `Now listening on: http://localhost:5029`
3. Abra outra janela de terminal, vá para a pasta VitrineUsadosWeb e digite o comando `npm start`
4. Certifique-se que o projeto web está rodando na porta 4200.
5. Abra o navegador e acesse: http://localhost:4200 

## Acesso ao admin
Usuario: `teste@teste.com` 
Senha: `teste123`

Caso seja deletado o banco de dados `vitrine.db`, migrations fará a criação com os dados iniciais.