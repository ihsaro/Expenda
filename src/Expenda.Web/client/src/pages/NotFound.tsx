import * as React from "react";

import { Typography } from "antd";

const NotFound: React.FC = () => {
    const { Title } = Typography;

    return <Title className="text-center">Not found</Title>;
};

export default NotFound;
