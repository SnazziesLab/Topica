import React, { useState } from "react";
import { Form, Input, Button } from "antd";
import { UserOutlined, LockOutlined } from "@ant-design/icons";
import { useAuth, Login } from "./useAuth";
import { useNavigate } from "react-router-dom";
import { ResponseError } from "@topica/client";

export const SignInPage: React.FunctionComponent = () => {
  const { authenticate } = useAuth();
  const navigation = useNavigate();
  const [error, setError] = useState<string>()
  const onFinish = (values: Login) => {
    authenticate(values).then(() =>  {
      console.debug("navigate to /");
      navigation("/")}).catch(async (e: ResponseError) => setError(await e.response.text()));
  };

  return (
    <Form<Login>
      name="normal_login"
      className="login-form"
      initialValues={{ remember: true }}
      onFinish={onFinish}
    >
      <Form.Item
        name="username"
        
        rules={[{ required: true, message: "Please input your Username!" }]}
      >
        <Input
          prefix={<UserOutlined className="site-form-item-icon" />}
          placeholder="Username"
          autoComplete="on"
        />
      </Form.Item>
      <Form.Item
        name="password"
        rules={[{ required: true, message: "Please input your Password!" }]}
      >
        <Input
          prefix={<LockOutlined className="site-form-item-icon" />}
          type="password"
          placeholder="Password"
          autoComplete="on"
        />
      </Form.Item>

      <Form.Item>
      {error && <div style={{color:"red"}}>{error}</div>}
        <Button type="primary" htmlType="submit" className="login-form-button">
          Log in
        </Button>
      </Form.Item>
    </Form>
  );
};