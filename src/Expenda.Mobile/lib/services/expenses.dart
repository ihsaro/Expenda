import 'dart:convert';

import 'package:http/http.dart' as http;

import 'package:expenda/models/expense.dart';
import 'package:expenda/models/transaction_result.dart';

/*
TransactionResult<ExpenseResponse> createExpense(ExpenseRequest expense) {
  return TransactionResult<ExpenseResponse>();
}

TransactionResult<ExpenseResponse?> updateExpense(int id, ExpenseRequest expense) {
  return TransactionResult<ExpenseResponse>();
}
*/
Future<TransactionResult<List<ExpenseResponse>>> getExpenses() async {
  final response = await http
      .get(Uri.parse('http://localhost:5000/api/v1/expenses'));

  if (response.statusCode == 200) {
    return TransactionResult<List<ExpenseResponse>>.fromJson(jsonDecode(response.body));
  } else {
    throw Exception('Failed to fetch expenses');
  }
}
/*
TransactionResult<ExpenseResponse?> getExpense(int id) {
  return TransactionResult<ExpenseResponse>();
}

TransactionResult<bool> deleteExpense(int id) {
  return TransactionResult<bool>();
}
*/