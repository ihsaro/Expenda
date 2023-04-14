using System.Text.Json.Serialization;

namespace Expenda.Application.Architecture.Localization.Models;

public class BaseMessage
{
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    public BaseMessage(string code, string value) => (Code, Value) = (code, value);
}
