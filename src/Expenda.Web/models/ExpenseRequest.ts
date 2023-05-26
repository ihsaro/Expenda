export interface ExpenseRequest {
    name: string;
    description?: string;
    price: number;
    quantity: number;
    transaction_date: Date;
}
