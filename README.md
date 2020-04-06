## Desafio Sistema de Identificação

Para o teste é necessário:

**POSTMAN** (https://www.postman.com/downloads/)<br/>
**Visual Studio 2019**<br/>
**SQLServer 2019**<br/>

<b>PACOTES NUGET</b><br/>
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 3.1.0<br/>
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 3.1.0<br/>
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 3.1.0<br/>
Install-Package IdentityModel.Tokens.Jwt -Version 5.6.0<br/>
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 3.1.0<br/>
Install-Package Microsoft.AspNetCore.Mvc.NewtonsoftJson<br/>

## Preparativos
Criar o Banco de Dados,tabelas e inserção de dados iniciais (Arquivo SQL na Solução)<br/>
Instalar os pacotes Nuget, configurar o acesso a base com parâmtetros locais (appsettings.json)<br/>

## Teste
Através do POSTMAN, obter o Bearer através das credenciais que estão na tabela Usuarios.<br/><br/>
A PORTA será obtida quando o IIS Express rodar a solução pela primeira vez.<br/>
Para todas as requisições:<br/> 
Header - (KEY) Content-type - (VALUE) application/json<br/> 

### Credenciais
POST - https://localhost:PORTA/api/token<br>
Será obtido algo como abaixo:<br>

Bearer<br>
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJJbnZlbnRvcnlTZXJ2aWNlQWNjZXNzVG9rZW4iLCJqdGkiOiJmYzRjNWUzOC0wOTgxLTRjYjEtOWMxNS1hYTBkYmJiMjczNTUiLCJpYXQiOiIwNS8wNC8yMDIwIDE3OjQ5OjEyIiwiSWQiOiIxIiwiRW1haWwiOiJ0ZXN0QHRoLmNvbSIsImV4cCI6MTU4NjE5NTM1MiwiaXNzIjoiSW52ZW50b3J5QXV0aGVudGljYXRpb25TZXJ2ZXIiLCJhdWQiOiJJbnZldG9yeVNlcnZpY2VQb3N0bWFuQ2xpZW50In0.d1w-fCuu0d2X0ZeEKIM7sKyZqEE5Y09rLdNDA8X_I5E<br>


### GET (obter dados)
Para todas as requisições:<br/> 
Header - (KEY) Authorization - (VALUE) Bearer gerado<br/>
Header - (KEY) Content-type - (VALUE) application/json<br/> 
GET - https://localhost:PORTA/api/logradouros/<br>
GET - https://localhost:PORTA/api/clientes/<br>
GET - https://localhost:PORTA/api/clientes/1<br>
***Exemplo de resultado:***<br>
```json
[
    {
        "clienteId": 1,
        "nome": "Joao Correa",
        "email": "jscorrea2@gmail.com",
        "logotipo": "TESTE",
        "logradouros": [
            {
                "logradouroId": 1,
                "logradouro": "Rua Teste, 288",
                "clienteId": 1
            },
            {
                "logradouroId": 2,
                "logradouro": "Rua Tesye, 566",
                "clienteId": 1
            }
        ]
    },
    {
        "clienteId": 3,
        "nome": "Joao Correa",
        "email": "jscorrea3@gmail.com",
        "logotipo": "TESTE",
        "logradouros": []
    },
    {
        "clienteId": 10,
        "nome": "Joao Correa",
        "email": "jscorrea4@gmail.com",
        "logotipo": "TESTE",
        "logradouros": []
    }
]
```
### PUT (atualizar dados)
Para todas as requisições:<br/> 
Header - (KEY) Authorization - (VALUE) Bearer gerado<br/>
Header - (KEY) Content-type - (VALUE) application/json<br/> 
KEY - Chave Primária <br>
PUT - https://localhost:PORTA/api/logradouros/KEY<br>
PUT - https://localhost:PORTA/api/clientes/KEY<br>
Para atualizar deve-se escrever no Body a mesma estrutura recebida, sem a chave primária na notação JSON.<br>
***Exemplo:***<br>
```json
    {        
        "nome": "Joao Correa",
        "email": "jscorrea3@gmail.com",
        "logotipo": "TESTE",       
    }
```

### DEL (apagar dados)
Para todas as requisições:<br/> 
Header - (KEY) Authorization - (VALUE) Bearer gerado<br/>
Header - (KEY) Content-type - (VALUE) application/json<br/> 
KEY - Chave Primária <br>
DEL - https://localhost:PORTA/api/logradouros/KEY<br>
DEL - https://localhost:PORTA/api/clientes/KEY<br>
Para apagar deve-se escrever no Body a mesma estrutura recebida, com a chave primária na notação JSON.<br>


### POST (adicionar dados)
Para todas as requisições:<br/> 
Header - (KEY) Authorization - (VALUE) Bearer gerado<br/>
Header - (KEY) Content-type - (VALUE) application/json<br/> 
POST - https://localhost:PORTA/api/logradouros/<br>
POST - https://localhost:PORTA/api/clientes/<br>
Para inserir deve-se escrever no Body a mesma estrutura recebida, sem a chave primária na notação JSON.<br>
***Exemplo:***<br>
```json
{        
    "nome": "Joao Correa",
    "email": "jscorrea30@gmail.com",
    "logotipo": "TESTE"
        
}
```



