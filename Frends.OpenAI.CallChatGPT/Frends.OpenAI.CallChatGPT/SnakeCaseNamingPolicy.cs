using System.Linq;
using System.Text.Json;

namespace Frends.OpenAI.CallChatGPT;

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

    /// <summary>
    /// Converts a property name to snake_case.
    /// </summary>
    /// <param name="name">Property name.</param>
    /// <returns>Name converted to snake_case.</returns>
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
