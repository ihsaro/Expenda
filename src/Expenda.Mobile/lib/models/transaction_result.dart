class TransactionResult<T> {
  bool success;
  List<ErrorMessage> errorMessages;
  T? resultObject;
  DateTime transactionUtcTimestamp;

  TransactionResult(this.success, this.errorMessages, this.resultObject, this.transactionUtcTimestamp);
}

class ErrorMessage {
  String code;
  String value;

  ErrorMessage(this.code, this.value);
}