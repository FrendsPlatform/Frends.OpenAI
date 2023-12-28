namespace Frends.OpenAI.CallChatGPT.Definitions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

/// <summary>
/// Options.
/// </summary>
public class Options
{
    /// <summary>
    /// Chat GPT API key.
    /// </summary>
    /// <example>1234567qwerty</example>
    [DisplayFormat(DataFormatString = "Text")]
    [PasswordPropertyText]
    public string ApiKey { get; set; }

    /// <summary>
    /// Whether to throw an exception if the API returns an error. Otherwise
    /// the error is returned as part of the result.
    /// </summary>
    /// <example>true</example>
    [DefaultValue(true)]
    public bool ThrowExceptionOnErrorResponse { get; set; } = true;
}