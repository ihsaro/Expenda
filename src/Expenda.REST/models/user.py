from pydantic import BaseModel, EmailStr


class LoginResponse(BaseModel):
    access_token: str
    token_type: str


class RegisterRequest(BaseModel):
    first_name: str
    last_name: str
    email_address: EmailStr
    username: str
    password: str


class RegisterResponse(RegisterRequest):
    id: int
