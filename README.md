# | Backend na DevPartner

## | Considerações iniciais
* A minha resolução ao problema proposto utiliza uma stack ASP.NET Core com Entity Framework Core e SQL Server.
* Deixei comentários ao longo da solução que começam em
```c#
// [note]
```
A partir deles vocês podem observar melhor os pontos que criei para chegar à solução necessária. Espero que possam ler todos, escrevi para vocês.
* A validação de CNPJ não foi feita, mas a estrutura para tal está montada, mas este não é o objetivo do teste, mas sim a noção da estrutura e organização.

## | Antes de executar a Solução

**1. Restaurar dependências**
Execute o comando, na pasta onde está o arquivo **API.csproj**:
```sh
dotnet restore
```
Para recuperar as dependências do projeto.

**2. Criar banco de dados**
Execute o comando, na pasta onde está o arquivo **API.csproj**:
```sh
dotnet ef database update
```
Isto fará o banco de dados ser criado. Caso algo dê errado, um arquivo *.sql está na pasta onde está o arquivo *.sln.

## | Controladores da Solução

**1. NotaFiscalController (/api/v1/notafiscal)**
Neste controlador está toda a tarefa proposta pelo desafio.

### | Endpoints
1. *POST* Create (/)
Recebe um objeto _NotaFiscalCreate_, valida os valores e salva no banco de dados.
* Tipos de resposta:
- 201 Created: nota fiscal recém criada com campos calculados e Id para recuperação posterior.
- 400 Bad Request: erro de validação, com detalhes no corpo da resposta.
- 500 Internal Server Error: código de erro para identificação posterior.

2. *GET* Get (/)
Lista todas as Notas Fiscais do banco de dados.
* Tipos de resposta:
- 200 OK: array de notas fiscais.
- 500 Internal Server Error: código de erro para identificação posterior.

3. *GET* Get By Id ("/{id}")
Lista uma das notas fiscais de acordo com o Id, se esta for encontrada.
* Tipos de resposta:
- 200 OK: nota fiscal a partir do banco de dados.
- 404 Not Found: nota fiscal com o Id não encontrada.
- 500 Internal Server Error: código de erro para identificação posterior.

4. *DELETE* Delete By Id ("/{id}")
* Tipos de resposta:
- 200 OK: nota fiscal deletada com sucesso.
- 500 Internal Server Error: código de erro para identificação posterior.

5. *UPDATE* Update By Id ("/{id}")
* Tipos de resposta:
- 200 OK: nota fiscal atualizada com sucesso.
- 500 Internal Server Error: código de erro para identificação posterior.

## | Coleção de Requests no PostMan
Para acessar os endpoints criados no PostMan para esta API [accesse este link](https://www.getpostman.com/collections/73be7862dc1117b92b3e).