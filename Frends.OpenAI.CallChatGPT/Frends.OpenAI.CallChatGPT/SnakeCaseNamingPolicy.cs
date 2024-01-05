namespace Frends.OpenAI.CallChatGPT;

using System.Linq;
using System.Text.Json;

/// <summary>
/// This class is used to convert property names to snake_case in JSON
/// serialization.
/// </summary>
internal class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    /// <summary>
    /// Singleton instance.
    /// </summary>
    internal static SnakeCaseNamingPolicy Instance { get; } = new SnakeCaseNamingPolicy();

    /// <inheritdoc/>
    public override string ConvertName(string name)
    {
        // Conversion to other naming convention goes here. Like SnakeCase, KebabCase etc.
        return ToSnakeCase(name);
    }

    private static string ToSnakeCase(string str)
    {
        return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
    }
}