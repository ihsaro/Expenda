import * as React from "react";

interface Props {
    expanded: boolean;
    setExpanded: (value: boolean) => void;
}

export const SidebarContext = React.createContext<Props>({
    expanded: false,
    setExpanded: () => {},
});

export const useSidebarContext = () => React.useContext(SidebarContext);
