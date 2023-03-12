import * as React from "react";

import { Col as AntdCol, ColProps } from "antd";

interface Props extends ColProps {}

const Col: React.FC<Props> = (props) => {
    return <AntdCol {...props} />;
};

export default Col;
