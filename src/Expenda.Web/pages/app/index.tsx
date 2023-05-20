import * as React from "react";

import { Layout } from "antd";
import Sidebar, { Feature } from "components/app/Sidebar";
import { UserDataMetrics } from "components/app/Dashboard";
import { UserExpenses } from "components/app/Expenses";

const { Header, Content } = Layout;

const Home: React.FC = () => {
    return (
        <Layout className="fixed top-0 left-0 h-screen w-full">
            <Sidebar currentFeature={Feature.DASHBOARD} />
            <Layout>
                <Header className="h-max bg-inherit">
                    <UserDataMetrics />
                </Header>
                <Content className="pl-12 pt-5 pr-12">
                    <UserExpenses />
                </Content>
            </Layout>
        </Layout>
    );
};

export default Home;
