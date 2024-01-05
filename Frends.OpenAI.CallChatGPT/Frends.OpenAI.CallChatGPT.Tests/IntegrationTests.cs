namespace Frends.OpenAI.CallChatGPT.Tests;

using System;
using System.Threading.Tasks;
using Frends.OpenAI.CallChatGPT.Definitions;
using NUnit.Framework;

/// <summary>
/// Test class.
/// </summary>
[TestFixture]
internal class IntegrationTests
{
    private readonly string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

    [Test]
    public async Task TestCompletion()
    {
        var input = new Input
        {
            Model = "gpt-3.5-turbo",
            Messages = new[]
            {
                new InputMessage
                {
                    Content = "How are you?",
                    Role = "user",
                },
            },
        };

        var options = new Options { ApiKey = this.apiKey };

        var ret = await OpenAI.CallChatGPT(input, options, default);
        Assert.IsTrue(ret.ChatCompletion.Model.StartsWith("gpt-3.5-turbo"));
        Assert.IsTrue(ret.ChatCompletion.Created > 0);
        Assert.AreEqual(1, ret.ChatCompletion.Choices.Count);
        Assert.IsFalse(string.IsNullOrWhiteSpace(ret.ChatCompletion.Choices[0].Message.Content));
        Assert.AreEqual(11, ret.ChatCompletion.Usage.PromptTokens);
    }
}
