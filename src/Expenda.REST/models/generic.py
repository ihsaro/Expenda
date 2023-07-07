from datetime import datetime
from typing import Generic, List, TypeVar

from pydantic import BaseModel

T = TypeVar("T")


class TransactionResult(BaseModel, Generic[T]):
    success: bool
    error_messages: List["ErrorMessage"]
    result_object: T
    transaction_utc_timestamp: datetime


class ErrorMessage:
    code: str
    value: str
