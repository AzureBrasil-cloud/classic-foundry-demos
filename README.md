# classic-foundry-demos

Este projeto demonstra o uso do Azure AI Agents Persistent SDK em um aplicativo de console .NET.

## Descrição

O projeto executa um fluxo de interação com um agente persistente do Azure, enviando mensagens e recebendo respostas em tempo real via streaming. As variáveis de ambiente são carregadas de um arquivo `.env` para configurar a URL do projeto e o ID do agente.

## Estrutura do Projeto

- `src/Console.Fabric.App/Program.cs`: Código principal do aplicativo de console.
- `classic-foundry-demos.sln`: Solução do Visual Studio.
- `README.md`: Este arquivo.

## Pré-requisitos

- .NET 10.0 ou superior
- Azure Subscription com acesso ao serviço Azure AI Agents
- Variáveis de ambiente configuradas (`PROJECT_URL`, `AGENT_ID`)
- Arquivo `.env` (opcional, para facilitar o carregamento das variáveis)

> **Importante:**
> Certifique-se de definir a propriedade de cópia do arquivo `.env` para **Copy Always** (Copiar sempre) nas propriedades do arquivo no Visual Studio. Isso garante que o arquivo seja copiado para o diretório de saída e esteja disponível em tempo de execução.

## Instalação

1. Clone o repositório:
   ```sh
   git clone <url-do-repositorio>
   cd classic-foundry-demos
   ```
2. Configure as variáveis de ambiente em um arquivo `.env` na raiz do projeto:
   ```env
   PROJECT_URL=<sua-url-do-projeto>
   AGENT_ID=<seu-id-do-agente>
   ```
3. Restaure os pacotes NuGet:
   ```sh
   dotnet restore
   ```

## Execução

1. Compile o projeto:
   ```sh
   dotnet build
   ```
2. Execute o aplicativo:
   ```sh
   dotnet run --project src/Console.Fabric.App
   ```

## Como funciona

O aplicativo:
- Carrega variáveis de ambiente do arquivo `.env`.
- Cria um cliente de agente persistente usando `PersistentAgentsClient`.
- Cria uma nova thread de agente.
- Envia uma mensagem para o agente.
- Recebe e exibe as respostas do agente em tempo real.

## Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
