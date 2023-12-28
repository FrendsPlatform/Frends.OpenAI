namespace Frends.OpenAI.CallChatGPT.Definitions;

/// <summary>
/// A chat completion message generated by the model.
/// </summary>
public class Message
{
    /// <summary>
    /// The role of the author of this message.
    /// </summary>
    public string Role { get; set; }

    /// <summary>
    /// The contents of the message.
    /// </summary>
    public string Content { get; set; }
}