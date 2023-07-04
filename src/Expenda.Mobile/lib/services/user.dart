import 'dart:convert';

import 'package:http/http.dart' as http;

import 'package:expenda/models/login_response.dart';
import 'package:expenda/models/transaction_result.dart';

Future<TransactionResult<LoginResponse>> authenticate(
    String username, String password) async {
  final response =
      await http.post(Uri.parse('http://localhost:5000/api/v1/user/login'),
          body: jsonEncode(<String, String>{
            'username': username,
            'password': password,
          }),
          headers: <String, String>{"Content-Type": "application/json"});

  if (response.statusCode == 200) {
    return TransactionResult<LoginResponse>.fromJson(jsonDecode(response.body));
  } else {
    throw Exception('Invalid credentials');
  }
}
