using Expenda.Application.Architecture.Extensions;
using System.Text.Json.Serialization;

namespace Expenda.Application.Architecture;

public class TransactionResult<T>
{
    private bool success { get; set; }

    [JsonPropertyName("success")]
    public bool Success
    {
        get => success;
        set => success = !ErrorMessages.IsNullOrEmpty() && value;
    }

    [JsonPropertyName("error_messages")]
    public List<ErrorMessage> ErrorMessages { get; init; }

    [JsonPropertyName("result_object")]
    public T? ResultObject { get; set; }

    [JsonPropertyName("transaction_utc_timestamp")]
    public DateTime TransactionUtcTimestamp { get; private set; }

    public TransactionResult()
    {
        Success = true;
        ErrorMessages = new List<ErrorMessage>();
        TransactionUtcTimestamp = DateTime.UtcNow;
    }

    public TransactionResult(T resultObject) : this() => ResultObject = resultObject;

    public void AddErrorMessage(ErrorMessage message)
    {
        ErrorMessages.Add(message);
        Success = false;
    }

    public void AddBatchErrorMessages(IEnumerable<ErrorMessage> messages)
    {
        ErrorMessages.AddRange(messages);
        Success = false;
    }
}

public class ErrorMessage
{
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    public ErrorMessage(string code, string value)
    {
        Code = code;
        Value = value;
    }
}