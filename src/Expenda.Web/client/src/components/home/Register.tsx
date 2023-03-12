import * as React from "react";

import { Button, Form, Input } from "~/components/framework";

const Register: React.FC = () => {
    const [form] = Form.useForm();

    return (
        <Form
            layout="vertical"
            form={form}
            initialValues={{ layout: "vertical" }}
            onValuesChange={(e) => {}}
        >
            <Form.Item label="Username">
                <Input placeholder="Enter username" />
            </Form.Item>
            <Form.Item label="Password">
                <Input type="password" placeholder="Enter password" />
            </Form.Item>
            <Form.Item>
                <Button type="primary">Login</Button>
            </Form.Item>
        </Form>
    );
};

export default Register;
