## 🚀 Api10-EF-Jwt
Exemplo de criação de API em Clean Arquitetura com Autorização utilizando JWT, desenvolvido em .NET 10 com banco de dados SQLite.

#### O que você vai encontrar neste projeto

| Tecnologia | Descrição |
|-----------|-----------|
| **JWT** | Implementação de autenticação e autorização em WebAPI |
| **Injeção de Dependência** |EntityFramework com utilização de Code First |
| **Service** | Separação da criação de objetos e de sua reutilização, ideal para a realização de testes unitários |
| **Testes Unitários** | Separação da criação de objetos e de sua reutilização, ideal para a realização de testes unitários |

#### Requisitos do Projeto

No Visual Studio Abra (Ferramentas) > (Gerenciador de Pacotes NuGet) > (Console do Gerenciador de Pacotes Nuget)  
Necessário para Atualizar o Depurador com a Solução. 

Certificar em Definir o Projeto Padrão como (SistemaERPOnlineForcaDeVendasAPI.WebAPI)

* Instalar pacotes necessários (Obrigatório)
```bash
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design
```
* Usar o comando Add-Migration para Code First

```bash
Add-Migration InitialCreate -Project "InfraEstrutura" -StartupProject "SistemaERPOnlineForcaDeVendasAPI.WebAPI"
```
* Como aplicar as mudanças no banco

```bash
Update-Database -Project "InfraEstrutura" -StartupProject "SistemaERPOnlineForcaDeVendasAPI.WebAPI"
```

#### 🔄 Executar a Aplicação
- Após o Migrations, executar a aplicação **https://localhost:7092/Swagger/index.html** (ou na porta exibida no terminal). 

- O banco SQLite **(`SistemaERPOnlineForcaDeVendasAPI.db`)** é criado na raiz do projeto, após o (Build).

#### 🧪 Executar Endpoints

**1 -Registrar usuário**
- Enviar POST / Usuario: **https://localhost:7092/api/auth/registro**, selecionar Guia Body e enviar RAW e enviar o seguinte JSON 

   ```json
	{ 
    		"idempresa": 1, 
    		"email": "email@email.com", 
    		"senha": "123456", 
    		"nome": "Usuario", 
    		"taxapercentual": 10.00
	}
   ```

**2 - Fazer Login e Copiar o Token Postman**
- Enviar POST / Usuario: **https://localhost:7092/api/auth/login**, selecionar Guia Body e enviar RAW e enviar o seguinte Content-Type: application/json

   ```json
	{
		"email": "email@email.com",
		"senha": "123456"
	}
   ```
   
**3 - Fazer Login e Colar o Token Postman**
- Clique na Aba do Arquivo ou para todos os arquivos, na pasta **Authorizathion** no Postman e cole **(Token)** (sem "Bearer") e salve 

**4 -Teste Autenticação**
Enviar POST / Produto: https://localhost:7092/api/Produtos, selecionar Guia Body e enviar RAW e enviar o seguinte Content-Type: application/json

   ```json
	{
  		"idempresa": 1,
  		"idproduto": 1,
  		"valorultimacompra": 95.6836,
  		"lucrominimo": 27.50,
  		"lucromaximo": 50.00,
  		"precovendaminimo": 121.99659,
  		"precosugerido": 143.5304
	}
   ```


- **Health** Checa o servidor, verifica o estado da API e do banco de dados (útil para monitorização e orquestração).
- **GET (http://localhost:7092/health)**

```bash
Metodo: POST /api/auth/registro            Função: Registo de novo admin                JWT: Não 
Metodo: POST /api/auth/login               Função: Login e obter token JWT              JWT: Não
Metodo: GET /health                        Função: Health check (API + base de dados)   JWT: Não
Metodo: GET/POST /api/Produtos             Função: Listar / Criar produtos              JWT: Sim
Metodo: GET/PUT/DELETE /api/Produtos/{id}  Função: Obter / Atualizar / Excluir produto  JWT: Sim
```

#### Executar Testes Unitários (Developer PowerShell)
```bash
dotnet test SistemaERPOnlineForcaDeVendasAPI.Testes/SistemaERPOnlineForcaDeVendasAPI.Testes.csproj
```
Os testes cobrem a camada **Aplicacao** (ProdutoService), com mocks dos repositórios.

#### ⚙️ Configuração
- **Banco:** SQLite, arquivo `SistemaERPOnlineForcaDeVendasAPI.db` na raiz do projeto (não versionado). Connection string em `appsettings.json` (`ConnectionStrings:DefaultConnection`).
- **JWT:** Em `appsettings.json`, substitua `Jwt:Key` por uma chave segura com **mínimo 32 caracteres** (ou defina a variável de ambiente `Jwt__Key`). Em produção use sempre variáveis de ambiente ou User Secrets.

## 🌍 Frontend-Razor-Consumir-Api-Jwt
Exemplo de criação de CRUD com Autenticação JWT em .NET8 Razor, para Consumo de API.

#### O que você vai encontrar neste projeto
| Tecnologia | Descrição |
|-----------|-----------|
| **JWT** | Uso de autorização em WebAPI |
| **Razor** | Atua como o motor de renderização que combina C# com HTML para criar páginas dinâmicas |
| **Service** | Prática utilizada com Interfaces e Injeção de Dependência para Arquitetura em Camadas (ou Clean Architecture ) |

#### 🔄 Executar a aplicação
Executar a aplicação Backend **https://github.com/Marcelofazan/API-EF10-JWT** que se encontra no Github.

  - [API-EF10-JWT](https://github.com/Marcelofazan/API-EF10-JWT)
  
O banco de dados é SQLite **(`SistemaERPOnlineForcaDeVendasAPI.db`)** , onde será maninupado por essa aplicação como Frontend.

#### 🧪 Executar Endpoints ( Inicial Obrigatório)

**1 -dadosadmin.json** (Arquivo de configuração que consta no projeto)
- Enviar POST / Registro para criação do usuario:**https://localhost:7092/api/auth/registro**, selecionar Guia Body e enviar RAW e enviar o seguinte JSON  

```json
{ 
   "idempresa": 1, 
   "email": "email@email.com", 
   "senha": "123456", 
   "nome": "Usuario", 
   "taxapercentual": 10.00
}
```

#### Rotas dos métodos 
| Metodo | Descrição |
|-----------|-----------|
| Metodo: GET/POST | /api/Produtos  |
| Metodo: GET/PUT/DELETE  | /api/Produtos/{id} |

