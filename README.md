# Controle de Despesas 🧾

[![.NET](https://img.shields.io/badge/.NET-8-blue)](https://dotnet.microsoft.com/en-us/)
[![C#](https://img.shields.io/badge/C%23-8.0-blue?logo=c-sharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019-blue?logo=microsoft-sql-server)](https://www.microsoft.com/en-us/sql-server)

---

## 📌 Sobre o Projeto

**Controle de Despesas** é um sistema para gerenciar gastos pessoais, criado com o objetivo de **praticar DDD (Domain-Driven Design), Clean Architecture, acesso a banco de dados com Dapper e boas práticas de GitHub**.

O projeto segue boas práticas de arquitetura, mantendo **responsabilidades claras por camada**, código limpo e escalável, e também **permite treinar versionamento, commits e fluxo de branches no GitHub**.

---

## 🏛 Arquitetura e Camadas

- **API**: expõe endpoints HTTP. Não contém lógica de negócio nem acesso a banco.  
- **Application**: orquestra fluxo, mapeia DTOs e chama os Domain Services.  
- **Domain**: contém entidades, regras de negócio e interfaces de repositórios.  
- **Infrastructure**: implementa repositórios com Dapper e conexão ao SQL Server.  
- **GitHub**: prática de versionamento, controle de branches e documentação do repositório.
