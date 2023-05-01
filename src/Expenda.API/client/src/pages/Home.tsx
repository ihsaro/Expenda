import * as React from "react";

import { Col, Row, Tabs, Typography } from "antd";
import { Login, Register } from "~/components/home";

const Home: React.FC = () => {
    const { Title } = Typography;

    return (
        <Row justify="space-around" className="mt-60">
            <Col xs={24} md={6} className="text-center">
                <Title level={1} className="font-montserrat">
                    Welcome to Expenda
                </Title>
                <Title level={4} className="font-montserrat">
                    Create & track your expenses
                </Title>
                <Title level={5} className="font-montserrat">
                    Control it with monthly budgets
                </Title>
            </Col>
            <Col xs={24} md={6}>
                <Tabs
                    centered
                    defaultActiveKey="1"
                    items={[
                        { key: "1", label: "Login", children: <Login /> },
                        { key: "2", label: "Register", children: <Register /> },
                    ]}
                />
            </Col>
        </Row>
    );
};

export default Home;
