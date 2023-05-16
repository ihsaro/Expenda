export interface ExpenseResponse {
    id: number,
    name: string,
    description?: string,
    price: number,
    quantity: number,
    transaction_date: Date
}