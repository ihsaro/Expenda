import { Table } from "antd";
import { ColumnsType } from "antd/es/table";
import { useExpensesContext } from "contexts/ExpensesContext";
import { ExpenseResponse } from "models/ExpenseResponse";
import { TransactionResult } from "models/TransactionResult";
import * as React from "react";

interface Props {
    selectable?: boolean;
}

const UserExpenses: React.FC<Props> = (props) => {
    const [loading, setLoading] = React.useState<boolean>(true);

    const { expenses, setExpenses } = useExpensesContext();

    const columns: ColumnsType<ExpenseResponse> = [
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
            render: (value: string) => value.split("T")[0],
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
            setLoading(false);
        };

        fetchExpenses();
    }, []);

    return (
        <Table
            rowSelection={
                props.selectable
                    ? {
                          type: "checkbox",
                          onChange: (
                              selectedRowKeys: React.Key[],
                              selectedRows: ExpenseResponse[]
                          ) => {
                              console.log(
                                  `selectedRowKeys: ${selectedRowKeys}`,
                                  "selectedRows: ",
                                  selectedRows
                              );
                          },
                      }
                    : null
            }
            rowKey="id"
            dataSource={expenses}
            columns={columns}
            loading={loading}
        />
    );
};

export default UserExpenses;
