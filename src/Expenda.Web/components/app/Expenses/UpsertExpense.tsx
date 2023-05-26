import * as React from "react";
import { Button, Checkbox, Col, DatePicker, Form, Input, InputNumber, Row } from "antd";

import { ExpenseResponse } from "models/ExpenseResponse";
import { TransactionResult } from "models/TransactionResult";
import { ExpenseRequest } from "models/ExpenseRequest";

interface Props {
    id?: number;
    type: "ADD" | "EDIT";
}

const UpsertExpense: React.FC<Props> = (props) => {
    const [loading, setLoading] = React.useState<boolean>(
        props.type === "EDIT"
    );
    const [expense, setExpense] = React.useState<ExpenseRequest>({
        name: "",
        description: "",
        price: 0,
        quantity: 0,
        transaction_date: new Date(),
    });

    React.useEffect(() => {
        let fetchExpense = async () => {
            let response = await fetch("/api/expenses", {
                method: "GET",
            });

            let data: TransactionResult<ExpenseResponse> =
                await response.json();

            setExpense(data.result_object);
            setLoading(false);
        };

        if (
            (props.id === null || props.id === undefined) &&
            props.type === "EDIT"
        )
            console.error("Type 'EDIT' should have a defined Id");

        if (props.type === "EDIT") fetchExpense();
    }, []);

    const saveExpense = async () => { };

    return (
        <Form
            name="upsert-expense"
            layout="vertical"
            onFinish={saveExpense}
        >
            <Form.Item
                label="Name"
                name="name"
                rules={[
                    { required: true, message: "Please input the item name" },
                ]}
            >
                <Input />
            </Form.Item>

            <Form.Item
                label="Description"
                name="description"
            >
                <Input.TextArea />
            </Form.Item>

            <Row gutter={16}>
                <Col>
                    <Form.Item
                        label="Quantity"
                        name="quantity"
                        rules={[
                            { required: true, message: "Please input the item quantity" },
                        ]}
                    >
                        <InputNumber defaultValue={1} min={1} />
                    </Form.Item>
                </Col>
                <Col>
                    <Form.Item
                        label="Price"
                        name="price"
                        rules={[
                            { required: true, message: "Please input the item price" },
                        ]}
                    >
                        <InputNumber defaultValue={0} min={0} precision={2} keyboard={false} controls={false} />
                    </Form.Item>
                </Col>
            </Row>

            <Form.Item
                label="Transaction Date"
                name="date"
                rules={[
                    { required: true, message: "Please input the transaction date" },
                ]}
            >
                <DatePicker />
            </Form.Item>

            <Form.Item>
                <Button type="primary" htmlType="submit">
                    Submit
                </Button>
            </Form.Item>
        </Form>
    );
};

export default UpsertExpense;
