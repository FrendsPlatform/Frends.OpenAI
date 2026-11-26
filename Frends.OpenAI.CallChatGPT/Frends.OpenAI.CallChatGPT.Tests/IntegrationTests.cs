using System;
using System.IO;
using System.Threading.Tasks;
using dotenv.net;
using Frends.OpenAI.CallChatGPT.Definitions;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Frends.OpenAI.CallChatGPT.Tests;

/// <summary>
/// Test class.
/// </summary>
[TestFixture]
internal class IntegrationTests
{
    private readonly string apiKey;

    public IntegrationTests()
    {
        var envFile = Path.Combine(AppContext.BaseDirectory, ".env");
        if (File.Exists(envFile))
        {
            DotEnv.Load(options: new DotEnvOptions(
                ignoreExceptions: false,
                envFilePaths: new[] { envFile },
                overwriteExistingVars: false));
        }

        this.apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
            ?? throw new InvalidOperationException("Missing required env var: OPENAI_API_KEY");
    }

    [Test]
    public async Task TestCompletion()
    {
        var connection = new Connection
        {
            Model = "gpt-4.1-mini",
            ApiKey = this.apiKey,
        };
        var input = new Input
        {
            Messages = new[]
            {
                new InputMessage
                {
                    Content = "How are you?",
                    Role = "user",
                },
            },
        };

        var options = new Options();

        var ret = await OpenAI.CallChatGPT(input, connection, options, default);
        ClassicAssert.IsTrue(ret.ChatCompletion.Model.StartsWith("gpt-4.1-mini"));
        ClassicAssert.IsTrue(ret.ChatCompletion.Created > 0);
        ClassicAssert.AreEqual(1, ret.ChatCompletion.Choices.Count);
        ClassicAssert.IsFalse(string.IsNullOrWhiteSpace(ret.ChatCompletion.Choices[0].Message.Content));
        ClassicAssert.IsTrue(ret.ChatCompletion.Usage.PromptTokens > 0);
    }
}
