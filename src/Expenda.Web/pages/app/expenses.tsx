import * as React from "react";

import { Button, Col, Layout, Modal, Row } from "antd";
import Sidebar, { Feature } from "components/app/Sidebar";
import { DeleteOutlined, PlusOutlined } from "@ant-design/icons";
import { UserExpenses } from "components/app/Expenses";
import UpsertExpense from "components/app/Expenses/UpsertExpense";
import { ExpenseResponse } from "models/ExpenseResponse";
import { useExpensesContext } from "contexts/ExpensesContext";

const { Header, Content } = Layout;

const Expenses: React.FC = () => {
    const [isUpsertExpenseModalOpen, setIsUpsertExpenseModalOpen] =
        React.useState<boolean>(false);

    const [selectedExpenses, setSelectedExpenses] = React.useState<Array<ExpenseResponse>>([]);

    const { expenses, setExpenses } = useExpensesContext();

    const openUpsertExpenseModal = () => setIsUpsertExpenseModalOpen(true);

    const closeUpsertExpenseModal = () => setIsUpsertExpenseModalOpen(false);

    const handleRowSelection = (expenses: Array<ExpenseResponse>) => setSelectedExpenses(expenses);

    const onDeleteClickHandler = async () => {
        if (selectedExpenses.length === 1) {
            const id = selectedExpenses[0].id;
            let response = await fetch(`/api/expenses/${id}`, {
                method: "DELETE"
            });

            switch (response.status) {
                case 204:
                    setExpenses(expenses.filter(expense => expense.id === id));
                    break;
                case 404:
                    break;
                case 500:
                    break;
                default:
                    break;
            }
        }
        else {

        }
    }

    return (
        <Layout className="fixed top-0 left-0 h-screen w-full">
            <Sidebar currentFeature={Feature.EXPENSES} />
            <Layout>
                <Header className="h-max bg-inherit">
                    <Row gutter={16}>
                        <Col>
                            <Button
                                type="primary"
                                icon={<PlusOutlined />}
                                onClick={openUpsertExpenseModal}
                            >
                                Add
                            </Button>
                        </Col>
                        <Col>
                            <Button
                                type="primary"
                                danger
                                icon={<DeleteOutlined />}
                                disabled={selectedExpenses.length === 0}
                                onClick={onDeleteClickHandler}
                            >
                                Delete Selected
                            </Button>
                        </Col>
                    </Row>
                </Header>
                <Content className="pl-12 pt-5 pr-12">
                    <UserExpenses selectable rowSelectionHandler={handleRowSelection} />
                    {isUpsertExpenseModalOpen && (
                        <UpsertExpense
                            onCloseUpsertExpenseModal={closeUpsertExpenseModal}
                            type="ADD"
                            visible={isUpsertExpenseModalOpen}
                        />
                    )}
                </Content>
            </Layout>
        </Layout>
    );
};

export default Expenses;
