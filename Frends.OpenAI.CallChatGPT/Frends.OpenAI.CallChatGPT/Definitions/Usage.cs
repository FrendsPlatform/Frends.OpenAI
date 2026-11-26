namespace Frends.OpenAI.CallChatGPT.Definitions;

/// <summary>
/// Usage statistics for the completion request.
/// </summary>
public class Usage
{
    /// <summary>
    /// Number of tokens in the prompt.
    /// </summary>
    /// <example>9</example>
    public int PromptTokens { get; set; }

    /// <summary>
    /// Number of tokens in the generated completion.
    /// </summary>
    /// <example>12</example>
    public int CompletionTokens { get; set; }

    /// <summary>
    /// Total number of tokens used in the request (prompt + completion).
    /// </summary>
    /// <example>21</example>
    public int TotalTokens { get; set; }
}
