namespace Frends.OpenAI.CallChatGPT.Definitions;

/// <summary>
/// Choice generated by the Chat GPT model.
/// </summary>
public class Choice
{
    /// <summary>
    /// The index of the choice in the list of choices.
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// A chat completion message generated by the model.
    /// </summary>
    public Message Message { get; set; }

    /// <summary>
    /// The reason the model stopped generating tokens. This will be stop if
    /// the model hit a natural stop point or a provided stop sequence,
    /// length if the maximum number of tokens specified in the request was
    /// reached, content_filter if content was omitted due to a flag from our
    /// content filters, tool_calls if the model called a tool, or
    /// function_call (deprecated)  if the model called a function.
    /// </summary>
    public string FinishReason { get; set; }
}