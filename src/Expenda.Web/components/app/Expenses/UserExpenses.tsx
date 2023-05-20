import { Table } from "antd";
import { ExpenseResponse } from "models/ExpenseResponse";
import { TransactionResult } from "models/TransactionResult";
import * as React from "react";

const UserExpenses: React.FC = () => {
    const [expenses, setExpenses] = React.useState<Array<ExpenseResponse>>([]);

    const columns = [
        {
            title: "Item Name",
            dataIndex: "name",
            key: "name",
        },
        {
            title: "Item Description",
            dataIndex: "description",
            key: "description",
        },
        {
            title: "Quantity",
            dataIndex: "quantity",
            key: "quantity",
        },
        {
            title: "Price",
            dataIndex: "price",
            key: "price",
        },
        {
            title: "Transaction Date",
            dataIndex: "transaction_date",
            key: "transaction_date",
        },
    ];

    React.useEffect(() => {
        let fetchExpenses = async () => {
            let response = await fetch("/api/expenses", {
                method: "GET",
            });

            let data: TransactionResult<Array<ExpenseResponse>> =
                await response.json();
            setExpenses(data.result_object);
        };

        fetchExpenses();
    }, []);

    return <Table dataSource={expenses} columns={columns} />
}

export default UserExpenses;
