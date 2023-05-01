import { ErrorMessage } from "models/ErrorMessage";

export interface TransactionResult<T> {
    success: boolean;
    error_messages: Array<ErrorMessage>;
    result_object?: T;
    transaction_utc_timestamp: Date;
}
