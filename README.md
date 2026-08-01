# MyProductApp
 
API REST para gerenciamento de produtos, construída em **.NET** seguindo os princípios de **Clean Architecture** e **CQRS**, com **MediatR** para orquestração de comandos e queries, **FluentValidation** para validação de entrada e **Entity Framework Core** (SQLite) para persistência.
 
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet)
![MediatR](https://img.shields.io/badge/MediatR-CQRS-blue?style=flat)
![EF Core](https://img.shields.io/badge/EF%20Core-SQLite-green?style=flat)
![License](https://img.shields.io/badge/license-MIT-lightgrey)
 
## ✨ Sobre o projeto
 
O **MyProductApp** é uma API para cadastro, consulta, atualização e exclusão de produtos, desenvolvida como estudo/portfólio aplicando arquitetura em camadas desacopladas:
 
- **Domain** — entidades e regras de negócio (ex: `Product`, com invariantes protegidas por construtor e métodos de atualização)
- **Application** — casos de uso via CQRS (Commands/Queries + Handlers), DTOs, validações e contratos de repositório
- **Infrastructure** — implementação de persistência com EF Core (`AppDbContext`, `ProductRepository`)
- **Api** — controllers HTTP finos, apenas delegando ao `IMediator`
## 🏗️ Arquitetura
 
```
MyProductApp/
└── src/
    ├── MyProductApp.Api/              → Controllers, Program.cs, configuração da aplicação
    ├── MyProductApp.Application/      → Features (Commands/Queries), DTOs, Interfaces, Validators
    │   └── Features/
    │       └── Products/
    │           ├── Commands/
    │           │   ├── CreateProduct/
    │           │   └── UpdateProduct/
    │           └── Queries/
    │               └── GetProductById/
    ├── MyProductApp.Domain/           → Entidades (Product) e regras de domínio
    ├── MyProductApp.Infrastructure/   → AppDbContext, Repositories (EF Core)
    └── MyProductApp.sln
```
 
**Fluxo de uma requisição:** `Controller` → `IMediator.Send()` → `Handler` (Application) → `IProductRepository` (Infrastructure) → `AppDbContext` (EF Core / SQLite)
 
## 🚀 Tecnologias
 
| Camada | Tecnologia |
|---|---|
| Framework | ASP.NET Core Web API |
| Padrão de arquitetura | Clean Architecture + CQRS |
| Mediação | MediatR |
| Validação | FluentValidation |
| ORM | Entity Framework Core |
| Banco de dados | SQLite |
| Documentação | Swagger / OpenAPI |
 
## 📌 Endpoints
 
| Método | Rota | Descrição |
|---|---|---|
| `POST` | `/api/product` | Cria um novo produto |
| `GET` | `/api/product/{id}` | Busca um produto pelo `Guid` |
 
### Exemplo — Criar produto
 
```http
POST /api/product
Content-Type: application/json
 
{
  "name": "Teclado Mecânico",
  "price": 349.90,
  "description": "Teclado mecânico ABNT2 com switches azuis"
}
```
 
**Resposta (201 Created)**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "name": "Teclado Mecânico",
  "description": "Teclado mecânico ABNT2 com switches azuis",
  "price": 349.90
}
```
 
## ▶️ Como executar
 
### Pré-requisitos
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
### Passos
 
```bash
# Clone o repositório
git clone https://github.com/seu-usuario/MyProductApp.git
cd MyProductApp/src
 
# Restaure as dependências
dotnet restore
 
# Execute as migrations (se aplicável)
dotnet ef database update --project MyProductApp.Infrastructure --startup-project MyProductApp.Api
 
# Rode a aplicação
dotnet run --project MyProductApp.Api
```
 
A API estará disponível em `https://localhost:{porta}` com o Swagger em `/swagger`.
 
## 🧭 Roadmap
 
- [ ] Endpoint `PUT /api/product/{id}` (Update)
- [ ] Endpoint `DELETE /api/product/{id}` (Delete)
- [ ] Endpoint `GET /api/product` (listagem)
- [ ] Testes unitários dos Handlers
- [ ] Migração para PostgreSQL / SQL Server (produção)
- [ ] Autenticação e autorização

---

Desenvolvido por **Jefferson Guilherme**
