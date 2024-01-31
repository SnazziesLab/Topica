import { useCookieState } from "ahooks";
import { loginApi } from "../api/api";
import { JwtPayload, jwtDecode } from "jwt-decode";
import { useContext} from "react";
import { AuthContext } from "../Auth/ContextProvider";
import { ResponseError } from "@topica/client";
export interface Login {
  username: string;
  password: string;
}
export interface User {
  name: string;
  roles: string[];
}

interface MyDecodedToken extends JwtPayload {
  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier": string;
  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role": string[];
}
export function useAuth() {

  const authContext = useContext(AuthContext);
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const [_, setToken] = useCookieState("token", {
    defaultValue: "",
  });


  const signOut = () => {
    setToken("");
    authContext.setUser?.(null);
  };
  const authenticate = (values: Login): Promise<void | ResponseError>  => {
    return loginApi
      .loginRaw({loginModel: values})
      .then(async (response) => {
        const jwtHeaderValue = response.raw.headers.get("WWW-Authenticate");

        if (!jwtHeaderValue)
          throw new Error("WWW-Authenticate header is null");
        debugger
        if( jwtHeaderValue.toLowerCase() === "bearer"){
            const jwt = jwtDecode<MyDecodedToken>(await response.value());
            authContext.setUser?.({
              name: jwt[
                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
              ],
              roles:
                jwt["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"],
            });
            setToken(`Bearer ${response}`);
        }
        
        return Promise.resolve();
      })
      .catch((e: ResponseError) => {
        console.error(e);
        return Promise.reject(e);
      });
  };

  return { authenticate,user: authContext.user, signOut };
}
