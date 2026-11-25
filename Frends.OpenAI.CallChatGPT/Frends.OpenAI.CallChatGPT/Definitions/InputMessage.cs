namespace Frends.OpenAI.CallChatGPT.Definitions;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
