import * as React from "react";

import { Tabs as AntdTabs, TabsProps } from "antd";

interface Props extends TabsProps {}

const Tabs: React.FC<Props> = (props) => {
    return <AntdTabs {...props} className="font-montserrat" />;
};

export default Tabs;
