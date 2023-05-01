import "styles/globals.css";

import * as React from "react";
import type { AppProps } from "next/app";
import { ConfigProvider, theme } from "antd";
import { SidebarContext } from "contexts/SidebarContext";
import { ThemeContext } from "contexts/ThemeContext";

export default function MyApp({ Component, pageProps }: AppProps) {
    const [sidebarExpanded, setSidebarExpanded] = React.useState(false);
    const [darkMode, setDarkMode] = React.useState(false);

    const { defaultAlgorithm, darkAlgorithm } = theme;

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
                <SidebarContext.Provider
                    value={{
                        expanded: sidebarExpanded,
                        setExpanded: setSidebarExpanded,
                    }}
                >
                    <Component {...pageProps} />
                </SidebarContext.Provider>
            </ThemeContext.Provider>
        </ConfigProvider>
    );
}
