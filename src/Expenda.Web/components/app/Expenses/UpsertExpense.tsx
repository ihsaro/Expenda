import * as React from "react";
import {
    Button,
    Col,
    DatePicker,
    Form,
    Input,
    InputNumber,
    Modal,
    Row,
} from "antd";

import { ExpenseResponse } from "models/ExpenseResponse";
import { TransactionResult } from "models/TransactionResult";
import { ExpenseRequest } from "models/ExpenseRequest";
import { CloseCircleOutlined } from "@ant-design/icons";

interface Props {
    id?: number;
    type: "ADD" | "EDIT";
    visible?: boolean;

    onCloseUpsertExpenseModal(): void;
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
    const [form] = Form.useForm();

    React.useEffect(() => {
        let fetchExpense = async (id: number) => {
            let response = await fetch("/api/expenses", {
                method: "GET",
            });

            let data: TransactionResult<ExpenseResponse> =
                await response.json();

            setExpense(data.result_object);
            setLoading(false);
        };

        if (props.type === "EDIT") {
            if (props.id) fetchExpense(props.id);
            else console.error("Type 'EDIT' should have a defined Id");
        }
    }, []);

    const saveExpense = async (values: ExpenseRequest) => {
        console.log(values);
    };

    return (
        <Modal
            title={`${props.type === "ADD" ? "Add" : "Edit"} Expense`}
            open={props.visible}
            onCancel={props.onCloseUpsertExpenseModal}
            closeIcon={<CloseCircleOutlined />}
            footer={null}
        >
            <Form
                name="upsert-expense"
                layout="vertical"
                form={form}
                onFinish={saveExpense}
            >
                <Form.Item
                    label="Name"
                    name="name"
                    rules={[
                        {
                            required: true,
                            message: "Please input the item name",
                        },
                    ]}
                >
                    <Input />
                </Form.Item>

                <Form.Item label="Description" name="description">
                    <Input.TextArea />
                </Form.Item>

                <Row gutter={16}>
                    <Col>
                        <Form.Item
                            label="Quantity"
                            name="quantity"
                            rules={[
                                {
                                    required: true,
                                    message: "Please input the item quantity",
                                },
                            ]}
                            initialValue={1}
                        >
                            <InputNumber min={1} />
                        </Form.Item>
                    </Col>
                    <Col>
                        <Form.Item
                            label="Price"
                            name="price"
                            rules={[
                                {
                                    required: true,
                                    message: "Please input the item price",
                                },
                            ]}
                            initialValue={0}
                        >
                            <InputNumber
                                defaultValue={0}
                                min={0}
                                precision={2}
                                keyboard={false}
                                controls={false}
                            />
                        </Form.Item>
                    </Col>
                    <Col>
                        <Form.Item
                            label="Transaction Date"
                            name="transaction_date"
                            rules={[
                                {
                                    required: true,
                                    message:
                                        "Please input the transaction date",
                                },
                            ]}
                        >
                            <DatePicker />
                        </Form.Item>
                    </Col>
                </Row>

                <Form.Item>
                    <Button type="primary" htmlType="submit">
                        {props.type === "ADD" ? "Create" : "Update"}
                    </Button>
                </Form.Item>
            </Form>
        </Modal>
    );
};

export default UpsertExpense;
