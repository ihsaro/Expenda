import * as React from "react";

import { Row as AntdRow, RowProps } from "antd";

interface Props extends RowProps {}

const Row: React.FC<Props> = (props) => {
    return <AntdRow {...props} />;
};

export default Row;
