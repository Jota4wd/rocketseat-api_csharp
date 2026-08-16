# Products API

Repositório criado para estudo e aprendizado de **C#** e **.NET**, desenvolvendo uma API RESTful com **ASP.NET Core** e **.NET 8**.

Gerencia **Clientes** e **Produtos**, com relação **1 para muitos** (um cliente pode ter vários produtos).

## 🚀 Tecnologias

- .NET 8
- ASP.NET Core
- C#

## ▶️ Como executar

Pré-requisito: [.NET 8 SDK](https://dotnet.microsoft.com/download) instalado.

```bash
# Restaurar dependências
dotnet restore

# Rodar o projeto (a partir da pasta Products.API)
cd Products.API
dotnet run
```

A API sobe por padrão em `https://localhost:{porta}` (a porta exata aparece no terminal ao rodar).

## 🧪 Testando a API

Recomenda-se usar o [Swagger](https://swagger.io/) (já configurado por padrão em projetos ASP.NET Core) acessando `/swagger` no navegador, ou ferramentas como Insomnia/Postman.

## 🔗 Relação entre entidades

- **Cliente** → possui vários **Produtos** (1:N)
- **Produto** → pertence a um único **Cliente**

## 📚 Sobre

Estudo baseado no curso de C#/.NET da [Rocketseat](https://www.rocketseat.com.br/).
