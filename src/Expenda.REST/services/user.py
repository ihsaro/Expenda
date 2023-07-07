from models.generic import TransactionResult
from models.user import RegisterRequest, RegisterResponse


def command_login(username: str, password: str):
    pass


def command_register(request: RegisterRequest) -> TransactionResult[RegisterResponse]:
    pass


def query_metrics():
    pass
