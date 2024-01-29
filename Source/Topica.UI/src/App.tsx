import "./App.css";
import {
  BrowserRouter,
  Outlet,
  Route,
  Routes,
  useNavigate,
} from "react-router-dom";
import { User, useAuth } from "./pages/useAuth";
import { SignInPage } from "./pages/SignInPage";
import useAuthUser from "react-auth-kit/hooks/useAuthUser";
import { Children, useEffect } from "react";
import { Button } from "antd";

export function App() {
  const user = useAuthUser<User>();
  console.log(user);
  return (
    <Routes>
      <Route path="/login" element={<SignInPage />} />
      <Route element={<Layout />}>
        <Route element={<RequireAuth />}>
          <Route path="/" element={<>{user?.name}</>} />
        </Route>
      </Route>
    </Routes>
  );
}

export function RequireAuth() {
  const user = useAuthUser<User>();
  const navigation = useNavigate();
  useEffect(() => {
    if (user === null) navigation("/login");
  });
  return (
    <>
      <Outlet />
    </>
  );
}

export function Layout() {
  const user = useAuthUser<User>();
  const { signOut } = useAuth();
  const navigation = useNavigate();
  return (
    <div>
      <div>
        header
        <Button
          onClick={() => {
            signOut();
            navigation("/login");
          }}
        >
          Sign Out
        </Button>
      </div>
      <Outlet />
    </div>
  );
}
