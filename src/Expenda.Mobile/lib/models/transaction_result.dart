class TransactionResult<T> {
  bool success;
  List<ErrorMessage> errorMessages;
  T? resultObject;
  DateTime transactionUtcTimestamp;

  TransactionResult(this.success, this.errorMessages, this.resultObject,
      this.transactionUtcTimestamp);

  factory TransactionResult.fromJson(Map<String, dynamic> json) {
    return TransactionResult(json['success'], json['error_messages'],
        json['result_object'], json['transaction_utc_timestamp']);
  }
}

class ErrorMessage {
  String code;
  String value;

  ErrorMessage(this.code, this.value);
}
