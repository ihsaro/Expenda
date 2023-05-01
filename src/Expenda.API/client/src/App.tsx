import { ConfigProvider, theme } from "antd";
import * as React from "react";
import { Home, NotFound } from "~/pages";
import { Dashboard, Expenses, MonthlyBudgets, Settings } from "~/pages/app";
import { ThemeContext } from "~/contexts/ThemeContext";
import {
    Navigate,
    RouterProvider,
    createBrowserRouter,
} from "react-router-dom";
import { SidebarContext } from "~/contexts/SidebarContext";

const App: React.FC = () => {
    const [darkMode, setDarkMode] = React.useState(false);
    const [sidebarExpanded, setSidebarExpanded] = React.useState(false);

    const { defaultAlgorithm, darkAlgorithm } = theme;

    const router = createBrowserRouter([
        {
            path: "/",
            element: <Home />,
        },
        {
            path: "/app/dashboard",
            element: <Dashboard />,
        },
        {
            path: "/app/expenses",
            element: <Expenses />,
        },
        {
            path: "/app/monthly-budgets",
            element: <MonthlyBudgets />,
        },
        {
            path: "/app/settings",
            element: <Settings />,
        },
        {
            path: "/app",
            element: <Navigate to="/app/dashboard" />,
        },
        {
            path: "*",
            element: <NotFound />,
        },
    ]);

    React.useEffect(() => {
        const isDarkMode = localStorage.getItem("dark_mode");

        if (
            isDarkMode !== undefined &&
            isDarkMode !== null &&
            (isDarkMode === "true" || isDarkMode === "false")
        ) {
            setDarkMode(JSON.parse(isDarkMode));
        }
    }, []);

    React.useEffect(() => {
        const isExpanded = localStorage.getItem("expanded");

        if (
            isExpanded !== undefined &&
            isExpanded !== null &&
            (isExpanded === "true" || isExpanded === "false")
        ) {
            setSidebarExpanded(JSON.parse(isExpanded));
        }
    }, []);

    return (
        <ConfigProvider
            theme={{
                algorithm: darkMode ? darkAlgorithm : defaultAlgorithm,
                token: {
                    fontFamily: "Montserrat",
                    colorPrimary: "#138585",
                },
                components: {},
            }}
        >
            <SidebarContext.Provider
                value={{
                    expanded: sidebarExpanded,
                    setExpanded: setSidebarExpanded,
                }}
            >
                <ThemeContext.Provider
                    value={{
                        darkMode: darkMode,
                        setDarkMode: setDarkMode,
                    }}
                >
                    <RouterProvider router={router} />
                </ThemeContext.Provider>
            </SidebarContext.Provider>
        </ConfigProvider>
    );
};

export default App;
