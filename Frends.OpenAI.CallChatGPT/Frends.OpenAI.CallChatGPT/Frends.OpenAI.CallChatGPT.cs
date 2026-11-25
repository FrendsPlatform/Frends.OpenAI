namespace Frends.OpenAI.CallChatGPT;

using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Frends.OpenAI.CallChatGPT.Definitions;
using Frends.OpenAI.CallChatGPT.Helpers;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.Json;

/// <summary>
/// Main class of the Task.
/// </summary>
public static class OpenAI
{
    private const string ApiBaseUrl = "https://api.openai.com";

    /// <summary>
    /// Task for calling ChatGPT API.
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends.OpenAI.CallChatGPT).
    /// </summary>
    /// <param name="input">Task input.</param>
    /// <param name="options">Task options.</param>
    /// <param name="cancellationToken">Cancellation token given by Frends.</param>
    /// <returns>object {
    ///     bool Success,
    ///     object Error { string Message, Exception AdditionalInfo },
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
        try
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
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException(
                    $"OpenAI API call failed with status code {response.StatusCode} and content {response.Content}",
                    response.ErrorException);
            }

            return new Result
            {
                Success = true,
                ChatCompletion = response.Data,
                Error = null,
            };
        }
        catch (Exception ex)
        {
            return ex.Handle(options);
        }
    }

    private static RestClient CreateClient(Input input)
    {
        var auth = new JwtAuthenticator(input.ApiKey);
        var restClientOptions = new RestClientOptions
        {
            BaseUrl = new Uri(ApiBaseUrl),
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
