import * as React from "react";

import { Button, Col, Form, Input, Row } from "antd";

const Register: React.FC = () => {
    const [form] = Form.useForm();

    return (
        <Form
            layout="vertical"
            form={form}
            initialValues={{ layout: "vertical" }}
            onValuesChange={(e) => {}}
        >
            <Row gutter={16}>
                <Col span={12}>
                    <Form.Item
                        name="firstName"
                        label="First Name"
                        rules={[
                            {
                                required: true,
                                message: "Please input your first name!",
                            },
                        ]}
                    >
                        <Input placeholder="Enter first name" />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="lastName"
                        label="Last Name"
                        rules={[
                            {
                                required: true,
                                message: "Please input your last name!",
                            },
                        ]}
                    >
                        <Input placeholder="Enter last name" />
                    </Form.Item>
                </Col>
            </Row>
            <Form.Item
                name="emailAddress"
                label="Email Address"
                rules={[
                    {
                        required: true,
                        message: "Please input your email address!",
                    },
                ]}
            >
                <Input placeholder="Enter email address" />
            </Form.Item>
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
            <Form.Item
                name="confirmPassword"
                label="Confirm Password"
                rules={[
                    {
                        required: true,
                        message: "Please confirm your password!",
                    },
                ]}
            >
                <Input.Password placeholder="Confirm password" />
            </Form.Item>
            <Form.Item>
                <Button type="primary">Register</Button>
            </Form.Item>
        </Form>
    );
};

export default Register;
