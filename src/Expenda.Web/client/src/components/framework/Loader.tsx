import * as React from "react";

import { Spin, SpinProps } from "antd";
import { LoadingOutlined } from "@ant-design/icons";

interface Props extends SpinProps {}

const Loader: React.FC<Props> = (props) => {
    return (
        <Spin
            {...props}
            tip="LOADING"
            className="font-montserrat"
            indicator={<LoadingOutlined style={{ fontSize: 24 }} spin />}
        />
    );
};

export default Loader;
