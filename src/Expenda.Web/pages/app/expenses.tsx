import * as React from "react";

import { Button, Col, Layout, Modal, Row } from "antd";
import Sidebar, { Feature } from "components/app/Sidebar";
import { DeleteOutlined, PlusOutlined } from "@ant-design/icons";
import { UserExpenses } from "components/app/Expenses";
import UpsertExpense from "components/app/Expenses/UpsertExpense";

const { Header, Content } = Layout;

const Expenses: React.FC = () => {
    const [isUpsertExpenseModalOpen, setIsUpsertExpenseModalOpen] =
        React.useState<boolean>(false);

    const openUpsertExpenseModal = () => setIsUpsertExpenseModalOpen(true);

    const closeUpsertExpenseModal = () => setIsUpsertExpenseModalOpen(false);

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
                            >
                                Delete Selected
                            </Button>
                        </Col>
                    </Row>
                </Header>
                <Content className="pl-12 pt-5 pr-12">
                    <UserExpenses selectable />
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
