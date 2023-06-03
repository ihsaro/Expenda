import { Card, Col, Row, Statistic } from "antd";
import { TransactionResult } from "models/TransactionResult";
import { UserDataMetrics } from "models/UserDataMetrics";
import * as React from "react";

const UserDataMetrics: React.FC = () => {
    const [userDataMetrics, setUserDataMetrics] =
        React.useState<UserDataMetrics>({
            last_item_purchased: "",
            last_item_purchased_quantity: 0,
            last_item_purchased_total_price: 0,
            total_amount_spent: 0,
        });

    React.useEffect(() => {
        let fetchMetrics = async () => {
            let response = await fetch("/api/user-data-metrics", {
                method: "GET",
            });

            let data: TransactionResult<UserDataMetrics> =
                await response.json();

            setUserDataMetrics(data.result_object);
        };

        fetchMetrics();
    }, []);

    return (
        <Row gutter={16}>
            <Col md={6} className="w-full mb-2">
                <Card className="h-full w-full">
                    <Statistic
                        title="Last Item Purchased"
                        value={userDataMetrics.last_item_purchased}
                    />
                </Card>
            </Col>
            <Col md={6} className="w-full mb-2">
                <Card className="h-full w-full">
                    <Statistic
                        title="Last Item Purchased Quantity"
                        value={userDataMetrics.last_item_purchased_quantity}
                    />
                </Card>
            </Col>
            <Col md={6} className="w-full mb-2">
                <Card className="h-full w-full">
                    <Statistic
                        title="Last Item Purchased Total Price"
                        value={userDataMetrics.last_item_purchased_total_price}
                        precision={2}
                    />
                </Card>
            </Col>
            <Col md={6} className="w-full mb-2">
                <Card className="h-full">
                    <Statistic
                        title="Total Amount Spent"
                        value={userDataMetrics.total_amount_spent}
                        precision={2}
                    />
                </Card>
            </Col>
        </Row>
    );
};

export default UserDataMetrics;
