import * as React from "react";

interface Props {
    darkMode: boolean;
    setDarkMode: (value: boolean) => void;
}

export const ThemeContext = React.createContext<Props>({
    darkMode: false,
    setDarkMode: () => {},
});

export const useThemeContext = () => React.useContext(ThemeContext);
