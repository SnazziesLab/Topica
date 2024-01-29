import "./App.css";
import {
  Outlet,
  Route,
  Routes,
  useNavigate,
} from "react-router-dom";
import { useAuth } from "./pages/useAuth";
import { SignInPage } from "./pages/SignInPage";
import { Button } from "antd";
import { useEffect} from "react";

export function App() {
  const { user } = useAuth();
  console.log(user);
  return (
    <Routes>
      <Route path="/login" element={<SignInPage />} />
      <Route element={<Layout />}>
        <Route element={<RequireAuth />}>
          <Route path="/" element={<>{user?.name} {user?.roles}</>} />
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
