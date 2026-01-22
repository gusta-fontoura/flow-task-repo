# FlowTask API 🚀

API desenvolvida em C# (.NET) para o sistema de gerenciamento de tarefas **FlowTask**. O objetivo deste projeto é fornecer um backend robusto para criação, organização e acompanhamento de tarefas, visando produtividade e organização.

## 🛠 Tecnologias Utilizadas

* **Linguagem:** C#
* **Framework:** .NET 8 
* **Banco de Dados:** SQL Server
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

## 🚀 Roadmap e Progresso do Projeto

Este projeto está sendo desenvolvido em etapas, seguindo o padrão de **Arquitetura Limpa** e princípios **REST**. Abaixo, o status atual do desenvolvimento:

### 🏗️ Arquitetura e Configuração
- [x] Configuração da Solution (.sln) e camadas (API, Application, Domain, Infrastructure).
- [x] Configuração do **Entity Framework Core** com SQL Server.
- [x] Implementação do **Padrão Repository** (para desacoplamento do banco).
- [x] Configuração do **Swagger/OpenAPI** para documentação da API.
- [x] Implementação de **ViewModels** (para formatar saídas da API).
- [x] Implementação de **InputModels** (para receber dados limpos).

### 📝 Gestão de Tarefas (Kanban Core)
- [x] **Projetos:** CRUD completo (Criar, Listar, Detalhes, Deletar).
- [x] **Tarefas:** CRUD completo.
- [x] **Relacionamento:** Vinculação de Tarefas a Projetos.
- [x] **Ciclo de Vida:** Mudança de Status (ToDo -> InProgress -> Done) via PATCH.
- [x] **Priorização:** Sistema de Prioridade (Low, Medium, High) via Enum e PATCH.
- [x] **Limpeza:** Deleção em cascata (ao deletar projeto, deleta tarefas).

### 🛡️ Qualidade e Validação
- [x] Instalação do **FluentValidation**.
- [x] Validação de Campos Obrigatórios (Título, Descrição).
- [x] Validação de Regras de Negócio (Tamanho de texto, IDs válidos).
- [x] Tratamento de erros amigável (Bad Request automático).

### 🔐 Autenticação e Segurança (Fase Atual)
- [x] Criação da Entidade de Usuário e Migração do Banco.
- [ ] Cadastro de Usuários.
- [ ] Criptografia de Senhas (Hashing).
- [ ] Serviço de Login e Geração de Token JWT.
- [ ] Autorização (Proteger rotas apenas para usuários logados).
- [ ] Contexto de Usuário (Usuário só vê seus próprios projetos).

### 🔮 Próximos Passos (Backlog)
- [ ] Testes Unitários com xUnit.
- [ ] Implementação de logs de auditoria.
- [ ] Deploy na nuvem (Azure/AWS).

---
Desenvolvido por Gustavo Fontoura.
