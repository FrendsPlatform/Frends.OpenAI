namespace Frends.OpenAI.CallChatGPT.Definitions;

/// <summary>
/// Result.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="success">Success.</param>
    /// <param name="error">Error.</param>
    /// <param name="chatCompletion">ChatCompletion.</param>
    internal Result(bool success, string error, ChatCompletion chatCompletion)
    {
        this.ChatCompletion = chatCompletion;
        this.Success = success;
        this.Error = error;
    }

    /// <summary>
    /// Contains the input repeated the specified number of times.
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
    public ChatCompletion ChatCompletion { get; private set; }

    /// <summary>
    /// Indicates whether the operation was successful.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; private set; }

    /// <summary>
    /// Error message, if the operation was not successful. Otherwise null.
    /// </summary>
    /// <example>OpenAI API call failed with status code 500 and content ...</example>
    public string Error { get; private set; }
}