import * as React from "react";

import { Button, Col, Layout, Row } from "antd";
import Sidebar, { Feature } from "components/app/Sidebar";
import { DeleteOutlined, PlusOutlined } from "@ant-design/icons";
import { UserExpenses } from "components/app/Expenses";

const { Header, Footer, Content } = Layout;

const Expenses: React.FC = () => {
    return (
        <Layout className="fixed top-0 left-0 h-screen w-full">
            <Sidebar currentFeature={Feature.EXPENSES} />
            <Layout>
                <Header className="h-max bg-inherit">
                    <Row gutter={16}>
                        <Col>
                            <Button type="primary" icon={<PlusOutlined />}>Add</Button>
                        </Col>
                        <Col>
                            <Button type="primary" danger icon={<DeleteOutlined />}>Delete Selected</Button>
                        </Col>
                    </Row>
                </Header>
                <Content className="pl-12 pt-5 pr-12">
                    <UserExpenses />
                </Content>
            </Layout>
        </Layout>
    );
};

export default Expenses;
