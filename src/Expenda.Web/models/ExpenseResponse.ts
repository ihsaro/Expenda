import { ExpenseRequest } from "models/ExpenseRequest";

export interface ExpenseResponse extends ExpenseRequest {
    id: number;
}
