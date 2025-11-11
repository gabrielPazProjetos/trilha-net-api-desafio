--- Trilha .NET - API de Tarefas
API RESTful para gerenciamento de tarefas, utilizando ASP.NET
Core e Entity Framework Core.

--- Funcionalidades
- Criar uma nova tarefa
- Listar todas as tarefas
- Buscar tarefas por:
- ID
- Título
- Data
- Status (Pendente, EmAndamento, Concluida)
- Atualizar uma tarefa existente
- Deletar uma tarefa

--- Estrutura da Tabela SQL
-- Se você estiver criando o banco manualmente, execute o seguinte script:
- sql
CREATE TABLE Tarefas (
    Id INT PRIMARY KEY IDENTITY,
    Titulo NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(MAX),
    Data DATETIME NOT NULL,
    Status INT NOT NULL CHECK (Status IN (0, 1, 2))
);

--- Testes Unitários
-- Os testes foram implementados com xUnit e Moq. Exemplo de teste:
- csharp
Fact
public void Criar_TarefaValida_DeveRetornarCreated()
{
    var controller = GetControllerWithContext();
    var tarefa = new Tarefa { ... };
    var resultado = controller.Criar(tarefa);
    Assert.IsType<CreatedAtActionResult>(resultado);
}

--- Tecnologias Utilizadas
-  ASP.NET Core
- Entity Framework Core
- SQL Server
- xUnit
- Swagger

--- Referência do Enum
csharp
public enum EnumStatusTarefa
{
    Pendente,
    EmAndamento,
    Concluida
}

--- NOTA Migration Manual
-- Como parte da estrutura do Entity Framework, normalmente as migrations são geradas automaticamente via CLI com o comando dotnet ef migrations add. No entanto,
neste projeto optei por criar a migration manualmente, simulando o comportamento do EF Core, por dois motivos principais:
- Controle total do código via GitHub Como estou desenvolvendo e versionando diretamente pelo GitHub, sem executar comandos locais, criar a migration manualmente
me permite manter o projeto 100% rastreável e editável via interface web.
- Padronização e rastreabilidade Nomeei o arquivo de migration com um prefixo de data (20251111153000_Inicial.cs) para seguir a convenção usada pelo EF Core. Isso
facilita a organização cronológica das alterações e mantém a compatibilidade com práticas comuns de versionamento de banco de dados.
-- O conteúdo da migration define a estrutura da tabela Tarefas, conforme o modelo Tarefa.cs, e pode ser usado como referência para criar a tabela manualmente no
banco de dados.

Não compromete a funcionalidade Você ainda entrega a estrutura da tabela, o script SQL, e deixa claro que o projeto funciona mesmo sem o comando dotnet ef database update.
