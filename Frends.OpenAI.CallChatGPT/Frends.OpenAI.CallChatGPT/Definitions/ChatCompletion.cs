using System.Collections.Generic;

namespace Frends.OpenAI.CallChatGPT.Definitions;

/// <summary>
/// Chat completion object.
/// </summary>
public class ChatCompletion
{
    /// <summary>
    /// A unique identifier for the chat completion.
    /// </summary>
    /// <example>chatcmpl-123</example>
    public string Id { get; set; }

    /// <summary>
    /// The Unix timestamp (in seconds) of when the chat completion was created.
    /// </summary>
    /// <example>1677652288</example>
    public long Created { get; set; }

    /// <summary>
    /// The model used for the chat completion.
    /// </summary>
    /// <example>gpt-3.5-turbo-0613</example>
    public string Model { get; set; }

    /// <summary>
    /// This fingerprint represents the backend configuration that the model runs with.
    /// </summary>
    /// <example>fp_44709d6fcb</example>
    public string SystemFingerprint { get; set; }

    /// <summary>
    /// A list of chat completion choices.
    /// </summary>
    /// <example>object[] { object { int Index, object Message, string FinishReason } }</example>
    public List<Choice> Choices { get; set; }

    /// <summary>
    /// Usage statistics for the completion request.
    /// </summary>
    /// <example>object { int PromptTokens, int CompletionTokens, int TotalTokens }</example>
    public Usage Usage { get; set; }
}
