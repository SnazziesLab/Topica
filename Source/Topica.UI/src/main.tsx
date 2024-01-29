import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import { BrowserRouter } from "react-router-dom";
import createStore from "react-auth-kit/createStore";
import AuthProvider from 'react-auth-kit';
import { App } from "./App";
const store = createStore<object>({
  authName:'_auth',
  authType:'cookie',
  cookieDomain: window.location.hostname,
  cookieSecure: false,
});


ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
          <AuthProvider store={store}>

      <BrowserRouter>
              <App />
      </BrowserRouter>
      </AuthProvider>


  </React.StrictMode>
);
