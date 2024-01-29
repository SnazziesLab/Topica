import './App.css'
import {
  Route,  Routes,
} from "react-router-dom";
import { useAuth } from './pages/useAuth';
import { SignInPage } from "./pages/SignInPage";
import AuthOutlet from '@auth-kit/react-router/AuthOutlet'
export function App() {
  const {user} = useAuth();
  return (
      <Routes>
          <Route path="" element={<SignInPage/>}/>
          <Route element={<AuthOutlet fallbackPath='/login'/>}>
            <Route path='/' element={<>{user?.name}</>}/>
          </Route>
      </Routes>
  )
}


