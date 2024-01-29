import React, { createContext, useState } from "react";

interface AuthContextProps {
  isLoggedIn: boolean;
  login: () => void;
  logout: () => void;
}

export const AuthContext = createContext<Partial<AuthContextProps>>({});

const AuthProvider: React.FunctionComponent<{ children: React.ReactNode }> = (
  props
) => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const login = () => setIsLoggedIn(true);
  const logout = () => setIsLoggedIn(false);

  return (
    <AuthContext.Provider value={{ isLoggedIn, login, logout }}>
      {props.children}
    </AuthContext.Provider>
  );
};

export default AuthProvider;
