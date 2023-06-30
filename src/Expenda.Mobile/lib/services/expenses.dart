import 'package:expenda/models/expense.dart';
import 'package:expenda/models/transaction_result.dart';

TransactionResult<Expense> createExpense(Expense expense) {
  return TransactionResult<Expense>();
}

TransactionResult<Expense?> updateExpense(int id, Expense expense) {
  return TransactionResult<Expense>();
}

TransactionResult<List<Expense>> getExpenses() {
  return TransactionResult<List<Expense>>();
}

TransactionResult<Expense?> getExpense(int id) {
  return TransactionResult<Expense>();
}

TransactionResult<bool> deleteExpense(int id) {
  return TransactionResult<bool>();
}
