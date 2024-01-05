namespace Frends.OpenAI.CallChatGPT;

using System;
using RestSharp;
using RestSharp.Authenticators;
using System.ComponentModel;
using System.Threading;
using Definitions;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp.Serializers.Json;

/// <summary>
/// Main class of the Task.
/// </summary>
public static class OpenAI
{
    /// <summary>
    /// Task for calling ChatGPT API.
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends.OpenAI.CallChatGPT).
    /// </summary>
    /// <param name="input">Task input.</param>
    /// <param name="options">Task options.</param>
    /// <param name="cancellationToken">Cancellation token given by Frends.</param>
    /// <returns>object {
    ///     bool Success,
    ///     string Error
    ///     object ChatCompletion {
    ///         string Id,
    ///         long Created,
    ///         string Model,
    ///         string SystemFingerprint,
    ///         object[] Choices {
    ///             int Index,
    ///             object Message {
    ///                 string Role,
    ///                 string Content
    ///             }
    ///         },
    ///     }
    /// }</returns>
    public static async Task<Result> CallChatGPT(
        [PropertyTab] Input input,
        [PropertyTab] Options options,
        CancellationToken cancellationToken)
    {
        using var client = CreateClient(input);
        var request = new RestRequest("v1/chat/completions");
        request.AddJsonBody(new
        {
            input.Messages,
            input.Model,
            options.MaxTokens,
            options.N,
            options.Seed,
            options.User,
        });

        var response = await client.ExecutePostAsync<ChatCompletion>(request, cancellationToken);
        return response.IsSuccessful
            ? new Result(response.IsSuccessful, null, response.Data)
            : HandleErrorResponse(options, response);
    }

    private static Result HandleErrorResponse(Options options, RestResponse<ChatCompletion> response)
    {
        var errorText =
            $"OpenAI API call failed with status code {response.StatusCode} and content {response.Content}";
        if (options.ThrowExceptionOnErrorResponse)
        {
            throw new HttpRequestException(
                errorText,
                response.ErrorException);
        }

        return new Result(false, errorText, null);
    }

    private static RestClient CreateClient(Input input)
    {
        var auth = new JwtAuthenticator(input.ApiKey);
        var restClientOptions = new RestClientOptions
        {
            // S1075 is complaining about hardcoded URL, but this is the host
            // for ChatGPT API, thus we hardcode it here.
#pragma warning disable S1075
            BaseUrl = new Uri("https://api.openai.com"),
#pragma warning restore S1075
            Authenticator = auth,
        };
        var defaultSettings = new JsonSerializerOptions
        {
            PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
        };
        var client = new RestClient(
            restClientOptions,
            configureSerialization: s => s.UseSystemTextJson(defaultSettings));
        return client;
    }
}
