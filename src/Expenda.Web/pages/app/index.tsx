import * as React from "react";

import { Col, Layout, Row } from "antd";
import Sidebar, { Feature } from "components/app/Sidebar";
import { UserDataMetrics } from "components/app/Dashboard";
import { UserExpenses } from "components/app/Expenses";

const { Header, Content } = Layout;

const Home: React.FC = () => {
    return (
        <Layout className="fixed top-0 left-0 h-screen w-full">
            <Sidebar currentFeature={Feature.DASHBOARD} />
            <Layout>
                <Header className="mt-5 h-max bg-inherit">
                    <UserDataMetrics />
                </Header>
                <Content className="ml-12 mt-5 mr-12">
                    <Row>
                        <Col span={12}>
                            <UserExpenses />
                        </Col>
                    </Row>
                </Content>
            </Layout>
        </Layout>
    );
};

export default Home;
