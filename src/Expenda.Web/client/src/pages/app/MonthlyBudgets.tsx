import * as React from "react";

import { Layout } from "antd";
import Sidebar, { Feature } from "~/components/app/Sidebar";

const { Header, Footer, Content } = Layout;

const MonthlyBudgets: React.FC = () => {
    return (
        <Layout className="fixed top-0 left-0 h-screen w-full">
            <Sidebar currentFeature={Feature.MONTHLY_BUDGETS} />
            <Layout>
                <Header className="h-max bg-inherit">
                </Header>
                <Content className="pl-12 pt-5 pr-12">
                    
                </Content>
            </Layout>
        </Layout>
    );
};

export default MonthlyBudgets;
