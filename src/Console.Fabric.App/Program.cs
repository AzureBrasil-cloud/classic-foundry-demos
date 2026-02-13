using Azure.AI.Agents.Persistent;
using Azure.Identity;
using dotenv.net;

DotEnv.Load();

var url = Environment.GetEnvironmentVariable("PROJECT_URL");
var agentId = Environment.GetEnvironmentVariable("AGENT_ID");

var agentClient = new PersistentAgentsClient(url, new DefaultAzureCredential());

PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

await agentClient.Messages.CreateMessageAsync(thread.Id, MessageRole.User, content: "Me de o mapa de clientes");

var runTask = agentClient.Runs.CreateRunStreamingAsync(
    thread.Id, 
    agentId);
    
ThreadRun? currentRun;

do
{
    currentRun = null;
    await foreach (var update in runTask)
    {
        Console.WriteLine(update);
        switch (update)
        {
            case RunUpdate runUpdate:
                currentRun = runUpdate;
                break;
            case MessageContentUpdate messageContentUpdate:
                Console.WriteLine(messageContentUpdate.Text);
                break;
        }
    }
}while (currentRun?.Status != RunStatus.Cancelled ||
        currentRun?.Status != RunStatus.Cancelling ||
        currentRun?.Status != RunStatus.Completed ||
        currentRun?.Status != RunStatus.Failed);
        
        