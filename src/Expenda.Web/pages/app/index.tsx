import * as React from "react";

import { Layout, Table } from "antd";
import Sidebar, { Feature } from "components/app/Sidebar";
import { UserDataMetrics } from "components/app/Dashboard";
import { ExpenseResponse } from "models/ExpenseResponse";

const { Header, Content } = Layout;

const Home: React.FC = () => {
    const columns = [
        {
            title: 'Item Name',
            dataIndex: 'name',
            key: 'name',
        },
        {
            title: 'Item Description',
            dataIndex: 'description',
            key: 'description',
        },
        {
            title: 'Quantity',
            dataIndex: 'quantity',
            key: 'quantity',
        },
        {
            title: 'Unit Price',
            dataIndex: 'unit_price',
            key: 'unit_price',
        },
        {
            title: 'Transaction Date',
            dataIndex: 'transaction_date',
            key: 'transaction_date',
        },
    ];

    const [expenses, setExpenses] = React.useState<Array<ExpenseResponse>>([]);

    React.useEffect(() => {
        let fetchExpenses = async () => {
            let response = await fetch("api/expenses", {
                method: "GET"
            });
    
            let data = await response.json();
            setExpenses(data);
        }
    }, []);

    return (
        <Layout className="fixed top-0 left-0 h-screen w-full">
            <Sidebar currentFeature={Feature.DASHBOARD} />
            <Layout>
                <Header className="h-max bg-inherit">
                    <UserDataMetrics />
                </Header>
                <Content className="pl-12 pt-5 pr-12">
                    <Table dataSource={expenses} columns={columns} />;
                </Content>
            </Layout>
        </Layout>
    );
};

export default Home;
