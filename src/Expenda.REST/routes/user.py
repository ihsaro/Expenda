from typing import Annotated

from fastapi import APIRouter, Depends, status
from fastapi.security import OAuth2PasswordRequestForm

from models.user import (
    LoginResponse,
    RegisterRequest,
    RegisterResponse
)

from services.user import (
    command_login
)

router = APIRouter()


@router.post("api/v1/user/login", response_model=LoginResponse, tags=["user"])
async def login(request: Annotated[OAuth2PasswordRequestForm, Depends()]):
    user = command_login(request.username, request.password)
    if not user:
        raise HTTPException(
            status_code=status.HTTP_401_UNAUTHORIZED,
            detail="Incorrect username or password",
            headers={"WWW-Authenticate": "Bearer"},
        )
    access_token_expires = timedelta(minutes=ACCESS_TOKEN_EXPIRE_MINUTES)
    access_token = create_access_token(
        data={"sub": user.username}, expires_delta=access_token_expires
    )
    return {"access_token": access_token, "token_type": "bearer"}


@router.post("api/v1/user/register", response_model=RegisterResponse, tags=["user"])
async def register(request: RegisterRequest):
    return {"username": "fakecurrentuser"}


@router.get("api/v1/user/metrics", tags=["user"])
async def metrics(username: str):
    return {"username": username}
