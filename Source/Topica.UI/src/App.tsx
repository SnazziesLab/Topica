import { Outlet, Route, Routes, useNavigate } from "react-router-dom";
import { useAuth } from "./pages/useAuth";
import { SignInPage } from "./pages/SignInPage";
import { Button, Menu, MenuProps } from "antd";
import { useEffect, useState } from "react";
import { DashboardOutlined, UserOutlined } from "@ant-design/icons";
import { DashboardPage } from "./pages/DashboardPage";

export function App() {
  const { user } = useAuth();
  console.log(user);
  return (
    <Routes>
      <Route path="/login" element={<SignInPage />} />
      <Route element={<Layout />}>
        <Route element={<RequireAuth />}>
          <Route path="/" element={<DashboardPage />} />
        </Route>
      </Route>
    </Routes>
  );
}

export function RequireAuth() {
  const { user } = useAuth();
  const navigation = useNavigate();

  useEffect(() => {
    if (user === null) navigation("/login");
  }, [navigation, user]);

  console.log(user);
  return (
    <>
      <Outlet />
    </>
  );
}

export function Layout() {
  const { signOut } = useAuth();
  const navigation = useNavigate();
  const [current, setCurrent] = useState("dashboard");

  const onClick: MenuProps["onClick"] = (e) => {
    console.log("click ", e);
    setCurrent(e.key);
  };
  return (
    <div>
      <Menu
        onClick={onClick}
        selectedKeys={[current]}
        mode="horizontal"
        items={items}
      >
        <Button
          onClick={() => {
            signOut();
            navigation("/login");
          }}
        >
          Sign Out
        </Button>
      </Menu>
      <div style={{ margin: 20 }}>
        <Outlet />
      </div>
    </div>
  );
}

const items: MenuProps["items"] = [
  {
    label: "Dashboard",
    key: "dashboard",
    icon: <DashboardOutlined />,
  },
  {
    label: "User",
    key: "user",
    icon: <UserOutlined />,
  },
];
