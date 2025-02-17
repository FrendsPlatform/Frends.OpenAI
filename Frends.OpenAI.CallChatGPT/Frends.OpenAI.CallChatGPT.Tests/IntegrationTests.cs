namespace Frends.OpenAI.CallChatGPT.Tests;

using System;
using System.Threading.Tasks;
using Frends.OpenAI.CallChatGPT.Definitions;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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
            ApiKey = this.apiKey,
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

        var ret = await OpenAI.CallChatGPT(input, options, default);
        ClassicAssert.IsTrue(ret.ChatCompletion.Model.StartsWith("gpt-3.5-turbo"));
        ClassicAssert.IsTrue(ret.ChatCompletion.Created > 0);
        ClassicAssert.AreEqual(1, ret.ChatCompletion.Choices.Count);
        ClassicAssert.IsFalse(string.IsNullOrWhiteSpace(ret.ChatCompletion.Choices[0].Message.Content));
        ClassicAssert.AreEqual(11, ret.ChatCompletion.Usage.PromptTokens);
    }
}
