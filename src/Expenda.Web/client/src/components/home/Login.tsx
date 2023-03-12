import * as React from "react";

import {
    Button,
    Checkbox,
    Form,
    Input,
    Typography,
} from "~/components/framework";

type FormFields = {
    username: string;
    password: string;
};

const Login: React.FC = () => {
    const [form] = Form.useForm();

    const onFinish = async (values: FormFields) => {
        let response = await fetch("api/v1/authentication/login", {
            method: "POST",
            body: JSON.stringify({
                username: values.username,
                password: values.password,
            }),
            credentials: "same-origin",
            headers: {
                "Content-Type": "application/json",
            },
        });

        console.log(response);
    };

    return (
        <Form
            layout="vertical"
            form={form}
            onValuesChange={(e) => {}}
            onFinish={onFinish}
            className="m-5"
        >
            <Form.Item
                name="username"
                label="Username"
                rules={[
                    { required: true, message: "Please input your username!" },
                ]}
            >
                <Input placeholder="Enter username" />
            </Form.Item>
            <Form.Item
                name="password"
                label="Password"
                rules={[
                    { required: true, message: "Please input your password!" },
                ]}
            >
                <Input.Password placeholder="Enter password" />
            </Form.Item>
            <Form.Item name="remember" valuePropName="checked">
                <Checkbox>Remember me</Checkbox>
            </Form.Item>
            <Form.Item>
                <Button type="primary" htmlType="submit">
                    Login
                </Button>
            </Form.Item>
        </Form>
    );
};

export default Login;
