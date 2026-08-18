# Products API

Repositório criado para estudo e aprendizado de **C#** e **.NET**, desenvolvendo uma API RESTful com **ASP.NET Core** e **.NET 8**.

Gerencia **Clientes** e **Produtos**, com relação **1 para muitos** (um cliente pode ter vários produtos).

## 🚀 Tecnologias

- .NET 8 / ASP.NET Core
- Entity Framework Core + SQLite
- HTML/CSS/JS puro (front-end de teste)

## 📋 Funcionalidades

- Cadastrar, listar, editar e remover clientes
- Cadastrar e remover produtos vinculados a um cliente

## ▶️ Como rodar

```bash
dotnet restore
dotnet run --project Products.API
```

A API sobe em `http://localhost:5044`.

## 🧪 Como testar

**Opção 1 — Swagger** (rota `/swagger`, abra http://localhost:5044/swagger/index.html)
Bom pra testar endpoint por endpoint direto, sem interface visual.

**Opção 2 — Front-end (`index.html`)**
Abra o arquivo `index.html`, na raiz do projeto, direto no navegador (duplo clique, não precisa de servidor). Com a API rodando, dá pra cadastrar clientes e produtos, ver a lista e testar tudo visualmente.

## 📚 Sobre

Estudo baseado no curso de C#/.NET da [Rocketseat](https://www.rocketseat.com.br/).
