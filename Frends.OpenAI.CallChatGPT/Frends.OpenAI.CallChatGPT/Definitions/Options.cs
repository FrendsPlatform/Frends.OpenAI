namespace Frends.OpenAI.CallChatGPT.Definitions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

/// <summary>
/// Options.
/// </summary>
public class Options
{
    /// <summary>
    /// The maximum number of tokens that can be generated in the chat
    /// completion. Set to 0 for unlimited tokens.
    /// The total length of input tokens and generated tokens is still limited
    /// by the model's context length.
    /// </summary>
    /// <example>100</example>
    [DefaultValue(null)]
    public int? MaxTokens { get; set; }

    /// <summary>
    /// How many chat completion choices to generate for each input message.
    /// Note that you will be charged based on the number of generated tokens
    /// across all of the choices. Keep n as 1 to minimize costs.
    /// </summary>
    /// <internalnote>
    /// This property name comes directly from ChatGPT API, thus is called
    /// just N and not somethings else. We want to keep the task as close to
    /// the API as possible.
    /// </internalnote>
    /// <example>3</example>
    [DefaultValue(1)]
    public int N { get; set; } = 1;

    /// <summary>
    /// If specified, ChatGPT system will make a best effort to sample
    /// deterministically, such that repeated requests with the same seed and
    /// parameters should return the same result. Determinism is not guaranteed,
    /// and you should refer to the system_fingerprint response parameter to
    /// monitor changes in the backend.
    /// Set to null for non-deterministic results.
    /// </summary>
    /// <example>12345</example>
    [DefaultValue(null)]
    public int? Seed { get; set; }

    /// <summary>
    /// A unique identifier representing your end-user, which can help OpenAI to
    /// monitor and detect abuse.
    /// </summary>
    /// <example>User12345</example>
    public string User { get; set; }

    /// <summary>
    /// Whether to throw an exception if the API returns an error. Otherwise
    /// the error is returned as part of the result.
    /// </summary>
    /// <example>true</example>
    [DefaultValue(true)]
    public bool ThrowExceptionOnErrorResponse { get; set; } = true;
}