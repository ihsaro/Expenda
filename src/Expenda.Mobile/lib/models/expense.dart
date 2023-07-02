class ExpenseRequest {
  final String name;
  final String description;
  final int quantity;
  final double price;
  final DateTime transactionDate;

  ExpenseRequest(this.name, this.description, this.quantity, this.price,
      this.transactionDate);
}

class ExpenseResponse extends ExpenseRequest {
  final int id;

  ExpenseResponse(this.id, String name, String description, int quantity,
      double price, DateTime transactionDate)
      : super(name, description, quantity, price, transactionDate);

  factory ExpenseResponse.fromJson(Map<String, dynamic> json) {
    return ExpenseResponse(json['id'], json['name'], json['description'],
        json['quantity'], json['price'], json['transaction_date']);
  }
}
