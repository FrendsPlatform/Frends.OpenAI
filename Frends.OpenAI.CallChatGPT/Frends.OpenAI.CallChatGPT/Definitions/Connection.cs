using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.OpenAI.CallChatGPT.Definitions;

/// <summary>
/// Connection settings for the task.
/// </summary>
public class Connection
{
    /// <summary>
    /// Chat GPT model to use.
    /// Find a list of available models from https://platform.openai.com/docs/models.
    /// </summary>
    /// <example>gpt-4.1-mini</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("gpt-4.1-mini")]
    public string Model { get; set; } = "gpt-3.5-turbo";

    /// <summary>
    /// ChatGPT API key.
    /// </summary>
    /// <example>1234567qwerty</example>
    [DisplayFormat(DataFormatString = "Text")]
    [PasswordPropertyText]
    public string ApiKey { get; set; }
}
