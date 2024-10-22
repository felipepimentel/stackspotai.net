Aqui está o arquivo `README.md` em inglês para o repositório **stackspotai.net**:

```markdown
# stackspotai.net

[![.NET Version](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

`stackspotai.net` is a .NET library designed to simplify interactions with the [Stackspot AI API](https://ai.stackspot.com/docs/). It provides developers with a clean and easy-to-use interface for managing Personal Access Tokens (PAT), handling knowledge sources, and executing remote quick commands.

## Features

- **Token Management**: Generate and manage Personal Access Tokens (PAT) for API authentication.
- **Knowledge Source Management**: Create, update, and retrieve knowledge sources using Stackspot AI's knowledge management API.
- **Remote Quick Commands**: Execute and monitor remote quick commands via the API.

## Installation

To use this library in your .NET project, add the package via NuGet:

```bash
dotnet add package StackspotAI
```

## Usage

### 1. Initializing the Stackspot AI Client

To start using the library, initialize the `StackspotAIClient` with your client ID and client secret:

```csharp
var client = new StackspotAIClient("your_client_id", "your_client_secret");
```

### 2. Token Management

You can generate a Personal Access Token (PAT) to authenticate API requests:

```csharp
var tokenManager = new TokenManager("your_client_id", "your_client_secret");
var accessToken = await tokenManager.GenerateTokenAsync();
Console.WriteLine($"Access Token: {accessToken}");
```

### 3. Knowledge Source Management

Create, update, or retrieve knowledge sources with the following examples:

- **Create a new knowledge source**:

```csharp
var knowledgeSourceManager = new KnowledgeSourceManager(client);
var newKnowledgeSource = new KnowledgeSource
{
    Name = "My Knowledge Source",
    Description = "This is a test source."
};

var createdSource = await knowledgeSourceManager.CreateKnowledgeSourceAsync(newKnowledgeSource);
Console.WriteLine($"Knowledge Source Created: {createdSource.Name}");
```

- **Retrieve an existing knowledge source**:

```csharp
var knowledgeSource = await knowledgeSourceManager.GetKnowledgeSourceAsync("knowledgeSourceId");
Console.WriteLine($"Knowledge Source: {knowledgeSource.Name}");
```

- **Update a knowledge source**:

```csharp
var updatedSource = new KnowledgeSource
{
    Name = "Updated Knowledge Source",
    Description = "This is an updated description."
};

var result = await knowledgeSourceManager.UpdateKnowledgeSourceAsync("knowledgeSourceId", updatedSource);
Console.WriteLine($"Knowledge Source Updated: {result.Name}");
```

### 4. Remote Quick Commands

Execute remote quick commands and monitor their status:

- **Create and execute a remote quick command**:

```csharp
var quickCommandExecutor = new QuickCommandExecutor(client);
var command = new QuickCommand
{
    Name = "Test Command",
    Command = "echo 'Hello, World!'"
};

var result = await quickCommandExecutor.CreateRemoteQuickCommandAsync(command);
Console.WriteLine($"Quick Command Executed: {result.Name}");
```

- **Check the status of a quick command**:

```csharp
var status = await quickCommandExecutor.GetQuickCommandStatusAsync("commandId");
Console.WriteLine($"Quick Command Status: {status.Status}");
```

## Requirements

- **.NET 8.0** or higher
- A valid [Stackspot AI API](https://ai.stackspot.com/docs/) account to get `client_id` and `client_secret`.

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Repository

You can find the source code for this library at: [https://github.com/felipepimentel/stackspotai.net](https://github.com/felipepimentel/stackspotai.net)
```

### Explicação

- O `README.md` inclui uma introdução sobre o que a biblioteca faz, as principais funcionalidades, e exemplos de como utilizá-la.
- Também há uma seção sobre como instalar a biblioteca e links para a documentação do **Stackspot AI**.
- Foram adicionados exemplos de código para gerar tokens, gerenciar knowledge sources, e executar quick commands.
- A estrutura é compatível com repositórios modernos, incluindo um link para o repositório do GitHub.

Isso fornece uma base sólida para que os desenvolvedores possam entender e usar o **stackspotai.net**.