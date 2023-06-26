import 'package:expenda/pages/login.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(const ExpendaMain());
}

class ExpendaMain extends StatelessWidget {
  const ExpendaMain({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        useMaterial3: true,
      ),
      darkTheme: ThemeData(
        useMaterial3: true,
        brightness: Brightness.dark,
        fontFamily: 'Montserrat',
      ), // standard dark theme
      themeMode: ThemeMode.system, // device controls theme
      home: const Login(title: 'Flutter Demo Home Page 2'),
      debugShowCheckedModeBanner: false,
    );
  }
}
