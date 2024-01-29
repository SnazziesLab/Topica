import React from "react";
import { Form, Input, Button } from 'antd';
import {
  UserOutlined,
  LockOutlined
} from '@ant-design/icons';
import { useAuth, Login } from "./useAuth";


export const SignInPage: React.FunctionComponent = () => {

  const { authenticate } = useAuth();


  const onFinish =  (values: Login) => {

    authenticate(values);

  };


  return <Form<Login>
    name="normal_login"
    className="login-form"
    initialValues={{ remember: true }}
    onFinish={onFinish}
  >
    <Form.Item
      name="username"
      rules={[{ required: true, message: 'Please input your Username!' }]}
    >
      <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Username" />
    </Form.Item>
    <Form.Item
      name="password"
      rules={[{ required: true, message: 'Please input your Password!' }]}
    >
      <Input
        prefix={<LockOutlined className="site-form-item-icon" />}
        type="password"
        placeholder="Password" />
    </Form.Item>
    <Form.Item>
      <Button type="primary" htmlType="submit" className="login-form-button">
        Log in
      </Button>
    </Form.Item>
  </Form>;
};
