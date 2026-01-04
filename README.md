# Controle de Despesas API 💰

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Dapper](https://img.shields.io/badge/Dapper-007ACC?style=for-the-badge&logo=dotnet&logoColor=white)
![Swagger](https://img.shields.io/badge/-Swagger-%2385EA2D?style=for-the-badge&logo=swagger&logoColor=black)

Esta API foi desenvolvida para o gerenciamento de finanças pessoais, focando em conceitos de **Clean Architecture** e alta performance. O projeto é um laboratório prático para aplicação de padrões de projeto e exploração de diferentes tecnologias de persistência e segurança no ecossistema .NET.

## 🎯 Objetivos de Aprendizado & Técnicas Praticadas

Este repositório demonstra a aplicação de:
* **Clean Architecture:** Separação rígida de responsabilidades em camadas (Domain, Application, Infrastructure, API).
* **Dapper (Micro-ORM):** Escolhido para a persistência inicial focando em performance e domínio de SQL puro.
* **Repository Pattern:** Abstração da camada de dados para facilitar a manutenção e testes.
* **AutoMapper & DTOs:** Gerenciamento eficiente da transferência de dados entre camadas.
* **Dependency Injection:** Uso do container nativo do .NET para baixo acoplamento.

---

## 🚧 Roadmap de Evolução (Work in Progress)

O projeto está em constante evolução. Confira o que já foi implementado e o que está por vir:

- [x] **Arquitetura Base:** Estruturação das camadas e serviços.
- [x] **Persistência com Dapper:** Implementação de repositórios usando SQL otimizado.
- [ ] **EF Core Migration:** Implementação futura do Entity Framework Core para coexistência e comparação de ORMs.
- [ ] **ASP.NET Core Identity:** Gestão de usuários e contas.
- [ ] **Segurança com JWT:** Implementação de autenticação e autorização via token.

---

## 🏛️ Estrutura da Solução

* **`ControleDeDespesas.Domain`**: Entidades, interfaces de repositórios e regras de negócio.
* **`ControleDeDespesas.Application`**: Serviços de aplicação, DTOs e mapeamentos.
* **`ControleDeDespesas.Infrastructure`**: Implementação do acesso a dados com **Dapper**.
* **`ControleDeDespesas.Api`**: Controllers, configurações de DI e documentação Swagger.

---

## 🛠️ Funcionalidades Principais

* **Despesas (`Expense`):** CRUD completo, filtros por categoria/método de pagamento e cálculo de valor total.
* **Categorias (`Categoria`):** Organização e busca de categorias por nome.
* **Métodos de Pagamento (`PaymentMethod`):** Gestão das formas de pagamento.

---

## 🚀 Como Executar

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/jeffersonguilherme/ControledeDespesas.git](https://github.com/jeffersonguilherme/ControledeDespesas.git)
    ```
2.  **Configuração:** Ajuste a *Connection String* do seu banco de dados no arquivo `appsettings.json`.
3.  **Execução:**
    ```bash
    dotnet run --project ControleDeDespesas.Api
    ```
    Acesse o Swagger em sua `localhost` para testar os endpoints.

---

## 👤 Autor

**Jefferson Guilherme** *Desenvolvedor .NET em constante evolução, focado em boas práticas e arquitetura.*

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/jefferson-guilherme-15bab5250)
[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/jeffersonguilherme)
