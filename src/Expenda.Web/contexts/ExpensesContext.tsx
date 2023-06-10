import { ExpenseResponse } from "models/ExpenseResponse";
import * as React from "react";

interface Props {
    expenses: Array<ExpenseResponse>;
    setExpenses: (value: Array<ExpenseResponse>) => void;
}

export const ExpensesContext = React.createContext<Props>({
    expenses: [],
    setExpenses: () => {},
});

export const useExpensesContext = () => React.useContext(ExpensesContext);
