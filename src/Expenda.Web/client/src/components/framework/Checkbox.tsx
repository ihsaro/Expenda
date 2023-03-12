import * as React from "react";

import { Checkbox as AntdCheckbox, CheckboxProps } from "antd";

interface Props extends CheckboxProps {}

const Checkbox: React.FC<Props> = (props) => {
    return <AntdCheckbox {...props} className="font-montserrat" />;
};

export default Checkbox;
