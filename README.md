# 🏍️ Smart Yard Manager - API RESTful

## 📘 Descrição

API desenvolvida em .NET 8 para controle de **movimentação de motos dentro dos estabelecimentos da Mottu**, integrando sensores, operadores e registros de entrada/saída.

---

## 🔧 Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- Banco de Dados Oracle
- AutoMapper
- Swagger (OpenAPI)

---

## 📡 Endpoints Disponíveis

### 📂 `Moviment`

| Método | Rota                    | Descrição                         |
|--------|-------------------------|-----------------------------------|
| `GET`  | `/api/Moviment`         | Lista todas as movimentações      |
| `POST` | `/api/Moviment`         | Cria uma nova movimentação        |
| `GET`  | `/api/Moviment/{id}`    | Retorna uma movimentação por ID   |
| `DELETE` | `/api/Moviment/{id}` | Remove uma movimentação por ID    |

---

### 🛰️ `Sensor`

| Método | Rota                  | Descrição                      |
|--------|-----------------------|--------------------------------|
| `GET`  | `/api/Sensor`         | Lista todos os sensores        |
| `POST` | `/api/Sensor`         | Cria um novo sensor            |
| `GET`  | `/api/Sensor/{id}`    | Retorna um sensor por ID       |
| `PUT`  | `/api/Sensor/{id}`    | Atualiza um sensor por ID      |
| `DELETE` | `/api/Sensor/{id}` | Remove um sensor por ID        |

---

## ▶️ Como Executar o Projeto

### Pré-requisitos

- .NET 8 SDK
- Banco Oracle configurado
- Ferramenta para consumir APIs (Postman, Insomnia ou Swagger)

### Passos

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio

2. Configure a connection string em appsettings.json:
"ConnectionStrings": {
  "OracleConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=SEU_SERVIDOR"
}

3. Execute o projeto
```bash
dotnet run

4. Acesse a documentação interativa via Swagger:
https://localhost:7197/swagger/index.html

