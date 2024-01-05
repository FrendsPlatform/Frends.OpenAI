namespace Frends.OpenAI.CallChatGPT.Tests;

using System;
using System.Collections.Generic;
using Frends.OpenAI.CallChatGPT.Definitions;
using NUnit.Framework;

/// <summary>
/// Test class.
/// </summary>
[TestFixture]
internal class BasicPropertyTests
{
    [Test]
    public void UsageProperties_SetAndGetCorrectly()
    {
        // Arrange
        var usage = new Usage();

        // Act
        usage.PromptTokens = 10;
        usage.CompletionTokens = 20;
        usage.TotalTokens = 30;

        // Assert
        Assert.AreEqual(10, usage.PromptTokens);
        Assert.AreEqual(20, usage.CompletionTokens);
        Assert.AreEqual(30, usage.TotalTokens);
    }

    [Test]
    public void InputProperties_SetAndGetCorrectly()
    {
        // Arrange
        var input = new Input();
        var messages = new[]
        {
            new InputMessage { Content = "How are you?", Role = "User" },
            new InputMessage { Content = "I'm fine, thanks. How about you?", Role = "System" },
            new InputMessage { Content = "I'm fine too.", Role = "User" },
        };

        // Act
        input.Model = "gpt-3.5-turbo";
        input.Messages = messages;

        // Assert
        Assert.AreEqual("gpt-3.5-turbo", input.Model);
        CollectionAssert.AreEqual(messages, input.Messages);
    }

    [Test]
    public void OptionsProperties_SetAndGetCorrectly()
    {
        // Arrange
        var options = new Options();

        // Act
        options.MaxTokens = 100;
        options.N = 3;
        options.Seed = 12345;
        options.User = "test-user";

        // Assert
        Assert.AreEqual(100, options.MaxTokens);
        Assert.AreEqual(3, options.N);
        Assert.AreEqual(12345, options.Seed);
        Assert.AreEqual("test-user", options.User);
    }

    [Test]
    public void InputMessageProperties_SetAndGetCorrectly()
    {
        // Arrange
        var message = new InputMessage();

        // Act
        message.Content = "Hello, world.";
        message.Role = "user";

        // Assert
        Assert.AreEqual("Hello, world.", message.Content);
        Assert.AreEqual("user", message.Role);
    }

    [Test]
    public void ChatCompletionProperties_SetAndGetCorrectly()
    {
        // Arrange
        var chatCompletion = new ChatCompletion();
        var choices = new List<Choice>();
        var usage = new Usage();
        var created = DateTimeOffset.Now.ToUnixTimeSeconds();

        // Act
        chatCompletion.Id = "123";
        chatCompletion.Created = created;
        chatCompletion.Model = "gpt-3.5-turbo";
        chatCompletion.SystemFingerprint = "fingerprint123";
        chatCompletion.Choices = choices;
        chatCompletion.Usage = usage;

        // Assert
        Assert.AreEqual("123", chatCompletion.Id);
        Assert.AreEqual(created, chatCompletion.Created); // Allow a small margin for time difference
        Assert.AreEqual("gpt-3.5-turbo", chatCompletion.Model);
        Assert.AreEqual("fingerprint123", chatCompletion.SystemFingerprint);
        CollectionAssert.AreEqual(choices, chatCompletion.Choices);
        Assert.AreEqual(usage, chatCompletion.Usage);
    }

    [Test]
    public void ChoiceProperties_SetAndGetCorrectly()
    {
        // Arrange
        var choice = new Choice();
        var message = new Message();

        // Act
        choice.Index = 1;
        choice.Message = message;
        choice.FinishReason = "stop";

        // Assert
        Assert.AreEqual(1, choice.Index);
        Assert.AreEqual(message, choice.Message);
        Assert.AreEqual("stop", choice.FinishReason);
    }

    [Test]
    public void MessageProperties_SetAndGetCorrectly()
    {
        // Arrange
        var message = new Message();

        // Act
        message.Role = "User";
        message.Content = "Hello, world.";

        // Assert
        Assert.AreEqual("User", message.Role);
        Assert.AreEqual("Hello, world.", message.Content);
    }
}
