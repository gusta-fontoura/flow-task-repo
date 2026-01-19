# FlowTask API 🚀

API desenvolvida em C# (.NET) para o sistema de gerenciamento de tarefas **FlowTask**. O objetivo deste projeto é fornecer um backend robusto para criação, organização e acompanhamento de tarefas, visando produtividade e organização.

## 🛠 Tecnologias Utilizadas

* **Linguagem:** C#
* **Framework:** .NET 8 (ou a versão que estamos usando)
* **Banco de Dados:** (Ex: SQL Server / PostgreSQL - *preencher conforme nossa implementação*)
* **ORM:** Entity Framework Core
* **Documentação:** Swagger / OpenAPI

## ⚙️ Funcionalidades Principais

* **Gerenciamento de Tarefas:** CRUD completo (Criação, Leitura, Atualização e Exclusão) de tarefas.
* **Organização:** Estruturação de dados para suportar o fluxo de trabalho.
* **API RESTful:** Endpoints padronizados e documentados.

## 🚀 Como Executar o Projeto

### Pré-requisitos
* [.NET SDK](https://dotnet.microsoft.com/download) instalado.
* SQL Server (ou o banco que configuramos).

### Passos
1.  Clone o repositório:
    ```bash
    git clone [https://github.com/gusta-fontoura/flow-task-repo.git](https://github.com/gusta-fontoura/flow-task-repo.git)
    ```
2.  Entre na pasta do projeto:
    ```bash
    cd flow-task-repo
    ```
3.  Restaure as dependências:
    ```bash
    dotnet restore
    ```
4.  Execute a aplicação:
    ```bash
    dotnet run
    ```
5.  Acesse o Swagger para testar os endpoints:
    * Geralmente em: `http://localhost:5000/swagger`

## 📝 Status do Projeto

🚧 **Em desenvolvimento.** Focando atualmente na implementação dos endpoints principais e regras de negócio.

---
Desenvolvido por Gustavo Fontoura.