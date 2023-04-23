import * as React from "react";

import { Col, Layout, Row, Switch, Typography } from "antd";
import Sidebar, { Feature } from "~/components/app/Sidebar";
import { useThemeContext } from "~/contexts/ThemeContext";

const { Header, Footer, Content } = Layout;
const { Text } = Typography;

const Settings: React.FC = () => {
    const { darkMode, setDarkMode } = useThemeContext();

    return (
        <Layout className="fixed top-0 left-0 h-screen w-full">
            <Sidebar currentFeature={Feature.SETTINGS} />
            <Layout className="m-5">
                <Content>
                    <Row gutter={20}>
                        <Col>
                            <Text>
                                Toggle dark mode (Currently{" "}
                                {darkMode ? "ON" : "OFF"})
                            </Text>
                        </Col>
                        <Col>
                            <Switch
                                checked={darkMode}
                                onChange={() => {
                                    localStorage.setItem(
                                        "dark_mode",
                                        `${!darkMode}`
                                    );
                                    setDarkMode(!darkMode);
                                }}
                            />
                        </Col>
                    </Row>
                </Content>
            </Layout>
        </Layout>
    );
};

export default Settings;
