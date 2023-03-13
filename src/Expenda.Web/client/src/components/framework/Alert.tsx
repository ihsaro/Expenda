import * as React from "react";

import { Alert as AntdAlert, AlertProps } from "antd";

interface Props extends AlertProps {
    className: string;
}

const Alert: React.FC<Props> = (props) => {
    return (
        <AntdAlert
            {...props}
            className={`font-montserrat ${props.className}`}
        />
    );
};

export default Alert;
