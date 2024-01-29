import React, { createContext, useState } from "react";
import { User } from "../pages/useAuth";

interface AuthContextProps {
    user: User | null;
    setUser: (value: User | null) => void
    isLoggedIn: boolean;
}

export const AuthContext = createContext<Partial<AuthContextProps>>({});

const AuthProvider: React.FunctionComponent<{ children: React.ReactNode }> = (
  props
) => {

  const [user, setUser] = useState<User | null>(null);

  const isLoggedIn = user != null;

  return (
    <AuthContext.Provider value={{ isLoggedIn, user, setUser }}>
      {props.children}
    </AuthContext.Provider>
  );
};

export default AuthProvider;



