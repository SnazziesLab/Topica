
import useSignIn from 'react-auth-kit/hooks/useSignIn';
import { useCookieState } from 'ahooks';
import { loginApi } from '../api/api';
import { JwtPayload, jwtDecode } from 'jwt-decode';
import useAuthUser from 'react-auth-kit/hooks/useAuthUser';
import useSignOut from 'react-auth-kit/hooks/useSignOut';
export interface Login{
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
export function useAuth()  {

  const signIn = useSignIn<User>();
  const signOut = useSignOut();
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const [_, setCookie] = useCookieState("token", {
    defaultValue: "",
  })

  const authenticate = (values: Login) => {

    return loginApi.loginRaw(values).then(response => {
      const jwtHeaderValue = response.raw.headers.get("WWW-Authenticate");

      if(jwtHeaderValue === null)
        throw new Error("WWW-Authenticate header is null");

      const jwt = jwtDecode<MyDecodedToken>(jwtHeaderValue);
      const success = signIn({
        auth: {
          token: jwtHeaderValue!,
          type: "basic"
        },
        userState: {
         name: jwt['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'],
         roles: jwt["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"],
        }
      })
      setCookie(jwtHeaderValue)
      
      return success
    }).catch(e=> {
      console.error(e);
      return Promise.reject;
    })

  }


  return {authenticate, signOut};
}

