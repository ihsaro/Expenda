using Expenda.Application.Architecture.Extensions;
using Expenda.Application.Architecture.Localization.Models;
using System.Text.Json.Serialization;

namespace Expenda.Application.Architecture;

public class TransactionResult<T>
{
    private bool success { get; set; }

    [JsonPropertyName("success")]
    public bool Success
    {
        get => success;
        private set => success = ErrorMessages.IsNullOrEmpty() && value;
    }

    [JsonPropertyName("error_messages")]
    public List<ErrorMessage> ErrorMessages { get; }

    [JsonPropertyName("result_object")]
    public T? ResultObject { get; }

    [JsonPropertyName("transaction_utc_timestamp")]
    public DateTime TransactionUtcTimestamp { get; private set; }

    public TransactionResult()
    {
        ErrorMessages = new List<ErrorMessage>();
        Success = true;
        TransactionUtcTimestamp = DateTime.UtcNow;
    }

    public TransactionResult(T resultObject) : this() => ResultObject = resultObject;

    public TransactionResult<T> AddErrorMessage(ErrorMessage message)
    {
        ErrorMessages.Add(message);
        Success = false;
        return this;
    }

    public TransactionResult<T> AddBatchErrorMessages(IEnumerable<ErrorMessage> messages)
    {
        ErrorMessages.AddRange(messages);
        Success = false;
        return this;
    }
}

public class ErrorMessage : BaseMessage
{
    public ErrorMessage(string code, string value) : base(code, value) {}

    public ErrorMessage(BaseMessage message) : base(message.Code, message.Value) { }
}