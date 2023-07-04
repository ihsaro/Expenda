class LoginResponse {
  String accessToken;
  DateTime expiresAt;

  LoginResponse(this.accessToken, this.expiresAt);

  factory LoginResponse.fromJson(Map<String, dynamic> json) {
    return LoginResponse(json['access_token'], json['expires_at']);
  }
}
