import * as React from "react";

import { Button as AntdButton, ButtonProps } from "antd";

interface Props extends ButtonProps {}

const Button: React.FC<Props> = (props) => {
    return <AntdButton {...props} />;
};

export default Button;
