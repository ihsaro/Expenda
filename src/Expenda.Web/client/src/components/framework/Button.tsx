import * as React from "react";

import { Button as AntdButton, ButtonProps } from "antd";

interface Props extends ButtonProps {}

const Button: React.FC<Props> = (props) => {
    return <AntdButton {...props} className="font-montserrat" />;
};

export default Button;
