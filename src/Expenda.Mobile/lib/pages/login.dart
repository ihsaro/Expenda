import 'package:flutter/material.dart';

class Login extends StatefulWidget {
  const Login({super.key, required this.title});

  final String title;

  @override
  State<Login> createState() => _LoginState();
}

class _LoginState extends State<Login> {
  final _formKey = GlobalKey<FormState>();

  String _username = "";
  String _password = "";

  void _login() {
    // Validate returns true if the form is valid, or false otherwise.
    if (_formKey.currentState!.validate()) {
      // If the form is valid, display a snackbar. In the real world,
      // you'd often call a server or save the information in a database.
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Processing Data')),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Form(
        key: _formKey,
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            const Padding(
              padding: EdgeInsets.only(left: 25.0, right: 25.0, bottom: 15.0),
              child: Text(
                "Welcome to Expenda",
                style: TextStyle(fontSize: 30),
              ),
            ),
            const Padding(
              padding: EdgeInsets.only(left: 25.0, right: 25.0, bottom: 15.0),
              child: Text(
                "Create & track your expenses",
                style: TextStyle(fontSize: 20),
              ),
            ),
            const Padding(
              padding: EdgeInsets.only(left: 25.0, right: 25.0, bottom: 15.0),
              child: Text(
                "Control it with monthly budgets",
                style: TextStyle(fontSize: 15),
              ),
            ),
            Padding(
                padding: const EdgeInsets.only(
                    left: 25.0, right: 25.0, bottom: 25.0),
                child: TextFormField(
                  decoration: const InputDecoration(
                    labelText: 'Username',
                  ),
                  initialValue: _username,
                  onChanged: (value) {
                    setState(() {
                      _username = value;
                    });
                  },
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Username is required';
                    }
                    return null;
                  },
                )),
            Padding(
                padding: const EdgeInsets.only(
                    left: 25.0, right: 25.0, bottom: 25.0),
                child: TextFormField(
                  decoration: const InputDecoration(
                    labelText: 'Password',
                  ),
                  initialValue: _password,
                  obscureText: true,
                  onChanged: (value) {
                    setState(() {
                      _password = value;
                    });
                  },
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Password is required';
                    }
                    return null;
                  },
                )),
            OutlinedButton(onPressed: _login, child: const Text('LOGIN'))
          ],
        ),
      ),
    );
  }
}
