namespace Frends.OpenAI.CallChatGPT.Definitions;

/// <summary>
/// Result.
/// </summary>
public class Result
{
    /// <summary>
    /// Chat completion returned by the API.
    /// </summary>
    /// <example>
    /// {
    ///   Id: "chatcmpl-123",
    ///   Created: 1677652288,
    ///   Model: "gpt-3.5-turbo-0613",
    ///   SystemFingerprint: "fp_44709d6fcb",
    ///   Choices: [
    ///     {
    ///       Index: 0,
    ///       Message: {
    ///         Role: "assistant",
    ///         Content: "\n\nHello there, how may I assist you today?"
    ///       },
    ///       FinishReason: "stop"
    ///     }
    ///   ],
    ///   Usage: {
    ///     PromptTokens: 9,
    ///     CompletionTokens: 12,
    ///     TotalTokens: 21
    ///   }
    /// }
    /// </example>
    public ChatCompletion ChatCompletion { get; set; }

    /// <summary>
    /// Indicates whether the operation was successful.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; set; }

    /// <summary>
    /// Error that occurred during task execution.
    /// </summary>
    /// <example>object { string Message, Exception AdditionalInfo }</example>
    public Error Error { get; set; }
}
