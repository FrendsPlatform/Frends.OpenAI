namespace Frends.OpenAI.CallChatGPT.Definitions;

using System.Collections.Generic;

/// <summary>
/// Chat completion object.
/// </summary>
public class ChatCompletion
{
    /// <summary>
    /// A unique identifier for the chat completion.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The Unix timestamp (in seconds) of when the chat completion was created.
    /// </summary>
    public long Created { get; set; }

    /// <summary>
    /// The model used for the chat completion.
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// This fingerprint represents the backend configuration that the model runs with.
    /// </summary>
    public string SystemFingerprint { get; set; }

    /// <summary>
    /// A list of chat completion choices.
    /// </summary>
    public List<Choice> Choices { get; set; }

    /// <summary>
    /// Usage statistics for the completion request.
    /// </summary>
    public Usage Usage { get; set; }
}