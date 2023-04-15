import { ConfigProvider, theme } from "antd";
import * as React from "react";
import Home from "~/pages/Home";
import AppHome from "~/pages/app/Home";
import { ThemeContext } from "~/contexts/ThemeContext";
import { RouterProvider, createBrowserRouter } from "react-router-dom";

const App: React.FC = () => {
    const [darkMode, setDarkMode] = React.useState(false);

    const { defaultAlgorithm, darkAlgorithm } = theme;

    const router = createBrowserRouter([
        {
            path: "/",
            element: <Home />,
        },
        {
            path: "/app",
            element: <AppHome />,
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
            <ThemeContext.Provider
                value={{
                    darkMode: darkMode,
                    setDarkMode: setDarkMode,
                }}
            >
                <RouterProvider router={router} />
            </ThemeContext.Provider>
        </ConfigProvider>
    );
};

export default App;
