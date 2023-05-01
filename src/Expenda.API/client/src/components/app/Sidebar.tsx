import * as React from "react";

import { useNavigate } from "react-router-dom";

import { Layout, Menu, Modal } from "antd";

import type { MenuProps } from "antd";

import {
    DashboardOutlined,
    CalendarOutlined,
    DollarOutlined,
    SettingOutlined,
    LogoutOutlined,
} from "@ant-design/icons";
import { useSidebarContext } from "~/contexts/SidebarContext";

interface Props {
    currentFeature: Feature;
}

export enum Feature {
    DASHBOARD = "/app/dashboard",
    EXPENSES = "/app/expenses",
    MONTHLY_BUDGETS = "/app/monthly-budgets",
    SETTINGS = "/app/settings",
    LOGOUT = "",
}

const Sidebar: React.FC<Props> = (props) => {
    const navigate = useNavigate();

    const getCurrentFeatureIndex = () => {
        switch (props.currentFeature) {
            case Feature.DASHBOARD:
                return 0;
            case Feature.EXPENSES:
                return 1;
            case Feature.MONTHLY_BUDGETS:
                return 2;
            case Feature.SETTINGS:
                return 3;
            default:
                return 0;
        }
    };

    const [currentFeatureIndex, setCurrentFeatureIndex] = React.useState(
        getCurrentFeatureIndex()
    );
    const [logoutModalOpen, setLogoutModalOpen] = React.useState(false);
    const { expanded, setExpanded } = useSidebarContext();

    React.useEffect(() => {
        switch (props.currentFeature) {
            case Feature.DASHBOARD:
                setCurrentFeatureIndex(0);
                break;
            case Feature.EXPENSES:
                setCurrentFeatureIndex(1);
                break;
            case Feature.MONTHLY_BUDGETS:
                setCurrentFeatureIndex(2);
                break;
            case Feature.SETTINGS:
                setCurrentFeatureIndex(3);
                break;
            default:
                break;
        }
    }, []);

    const handleFeatureChange = (feature: Feature) => navigate(feature);

    const handleLogoutInvocation = async () => {
        let response = await fetch("/api/logout", {
            method: "POST",
        });

        if (response.status === 200) {
            // Router.push("/");
        }
    };

    const features = [
        {
            icon: <DashboardOutlined />,
            label: "Dashboard",
            code: Feature.DASHBOARD,
            onClick: () => handleFeatureChange(Feature.DASHBOARD),
        },
        {
            icon: <DollarOutlined />,
            label: "Expenses",
            code: Feature.EXPENSES,
            onClick: () => handleFeatureChange(Feature.EXPENSES),
        },
        {
            icon: <CalendarOutlined />,
            label: "Monthly Budgets",
            code: Feature.MONTHLY_BUDGETS,
            onClick: () => handleFeatureChange(Feature.MONTHLY_BUDGETS),
        },
        {
            icon: <SettingOutlined />,
            label: "Settings",
            code: Feature.SETTINGS,
            onClick: () => handleFeatureChange(Feature.SETTINGS),
        },
        // {
        //     icon: <LogoutOutlined />,
        //     label: "Logout",
        //     code: Feature.LOGOUT,
        //     onClick: () => setLogoutModalOpen(true),
        // },
    ];

    const items: MenuProps["items"] = features.map((feature, index) => {
        return {
            key: `feature-${index}`,
            icon: feature.icon,
            label: feature.label,
            onClick: () => feature.onClick(),
            className: `${
                feature.code === Feature.LOGOUT
                    ? "absolute bottom-12 text-red-500"
                    : ""
            }`,
        };
    });

    const { Sider } = Layout;

    return (
        <>
            <Sider
                theme="light"
                collapsed={!expanded}
                collapsible
                onCollapse={(value) => {
                    localStorage.setItem("expanded", `${!value}`);
                    setExpanded(!value);
                }}
            >
                <Menu
                    mode="inline"
                    defaultSelectedKeys={[`feature-${currentFeatureIndex}`]}
                    className="h-screen"
                    items={items}
                    selectable={false}
                />
            </Sider>
            <Modal
                open={logoutModalOpen}
                title="Do you want to log out?"
                okText="Yes"
                onOk={() => handleLogoutInvocation()}
                onCancel={() => setLogoutModalOpen(false)}
            ></Modal>
        </>
    );
};

export default Sidebar;
