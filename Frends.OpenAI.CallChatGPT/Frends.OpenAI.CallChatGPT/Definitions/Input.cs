namespace Frends.OpenAI.CallChatGPT.Definitions;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Input for the task.
/// </summary>
public class Input
{
    /// <summary>
    /// Chat GPT model to use.
    /// Find a list of available models from https://platform.openai.com/docs/models.
    /// </summary>
    /// <example>gpt-3.5-turbo</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("gpt-3.5-turbo")]
    public string Model { get; set; }

    /// <summary>
    /// Chat GPT API key.
    /// </summary>
    /// <example>1234567qwerty</example>
    [DisplayFormat(DataFormatString = "Text")]
    [PasswordPropertyText]
    public string ApiKey { get; set; }

    /// <summary>
    /// Array of messages to send to Chat GPT.
    /// </summary>
    /// <example>[
    ///     { "Content": "How are you?", "Role": "User" },
    ///     { "Content": "I'm fine, thanks. How about you?", "Role": "System" },
    ///     { "Content": "I'm fine too.", "Role": "User" }
    /// ]
    /// </example>
    public InputMessage[] Messages { get; set; }
}

/// <summary>
/// Input message class.
/// </summary>
public class InputMessage
{
    /// <summary>
    /// Message content.
    /// </summary>
    /// <example>Hello, world.</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("Hello, world.")]
    public string Content { get; set; }

    /// <summary>
    /// Role of the message. Example values: `user` or `system`.
    /// </summary>
    /// <example>User</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("user")]
    public string Role { get; set; }
}
