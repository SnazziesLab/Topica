import React, { useState } from "react";
import { Form, Input, Button } from "antd";
import { UserOutlined, LockOutlined } from "@ant-design/icons";
import { useAuth, Login } from "./useAuth";
import { useNavigate } from "react-router-dom";
import { ResponseError } from "@topica/client";

export const SignInPage: React.FunctionComponent = () => {
  const { authenticate } = useAuth();
  const navigation = useNavigate();
  const [error, setError] = useState<string>();
  const onFinish = (values: Login) => {
    authenticate(values)
      .then(() => {
        console.debug("navigate to /");
        navigation("/");
      })
      .catch(async (e: ResponseError) => setError(await e.response.text()));
  };

  return (
    <div
      style={{
        display: "flex",
        height: "inherit",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          padding: 50,
          justifyContent: "center",
          borderRadius:"10px",
          alignItems: "center",
          backgroundColor:"rgb(48, 58, 79)"
        }}
      >
        <img
          style={{ aspectRatio: "auto", height: 150 }}
          src="./Logo.svg"
        />
        <h2 style={{marginTop:-5, color:"white"}}>Topica</h2>
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
            {error && <div style={{ color: "red" }}>{error}</div>}
            <Button
              type="primary"
              htmlType="submit"
              className="login-form-button"
              style={{float:"right"}}
            >
              Log in
            </Button>
          </Form.Item>
        </Form>
      </div>
    </div>
  );
};
