import * as React from "react";

import { Alert, Button, Checkbox, Form, Input } from "antd";

type FormFields = {
    username: string;
    password: string;
};

const Login: React.FC = () => {
    const [form] = Form.useForm();

    const [errors, setErrors] = React.useState<Array<string>>([]);

    const onFinish = async (values: FormFields) => {
        let response = await fetch("api/login", {
            method: "POST",
            body: JSON.stringify({
                username: values.username,
                password: values.password,
            }),
        });

        setErrors(response.status === 401 ? ["Invalid credentials"] : []);

        if (response.status === 200) {
            window.location.reload();
        } else if (response.status === 401) {
            setErrors(["Invalid credentials"]);
        } else {
            setErrors(["Unknown error, please try again!"]);
        }
    };

    return (
        <>
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
                        {
                            required: true,
                            message: "Please input your username!",
                        },
                    ]}
                >
                    <Input placeholder="Enter username" />
                </Form.Item>
                <Form.Item
                    name="password"
                    label="Password"
                    rules={[
                        {
                            required: true,
                            message: "Please input your password!",
                        },
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
            {errors.map((error, index) => {
                return (
                    <Alert
                        key={`error-${index}`}
                        type="error"
                        closable
                        message={error}
                        className="fixed bottom-0 right-0 m-5"
                        onClose={(e) => setErrors([])}
                    />
                );
            })}
        </>
    );
};

export default Login;
