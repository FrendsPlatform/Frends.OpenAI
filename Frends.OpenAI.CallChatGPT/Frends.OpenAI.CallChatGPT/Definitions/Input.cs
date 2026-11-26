namespace Frends.OpenAI.CallChatGPT.Definitions;

/// <summary>
/// Input for the task.
/// </summary>
public class Input
{
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
