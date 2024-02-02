

import * as eventsClient from "@topica/client"
import {notification} from "antd"

const preAuthMiddlewares: eventsClient.Middleware[] = [
    {
        pre(e) {
            console.debug("pre middleware");
            const req = { ...e };
            const requestHeaders = new Headers(req.init.headers);
            requestHeaders.append("Access-Control-Allow-Origin", "*");
            req.init.headers = requestHeaders;
            return Promise.resolve(req);
        },
        post(e) {
            console.debug("post middleware");
            if (!e.response.ok) {
                {
                    const msg = `request failed: ${e.url}`;
                    notification.error({
                        message: msg,
                        placement: "bottomRight"
                    });
                    console.debug(e.init, msg);
                }
            }
            return Promise.resolve(e.response);
        }
    }
];

const postAuthMiddlewares: eventsClient.Middleware[] = [
    {
        pre(e) {
            console.debug("pre middleware");
            const req = { ...e };
            const requestHeaders = new Headers(req.init.headers);
            getCookie("token") && requestHeaders.append("Authorization", `${getCookie("_auth")} ${getCookie("token")}`);
            requestHeaders.append("Access-Control-Allow-Origin", "*");
            req.init.headers = requestHeaders;
            return Promise.resolve(req);
        },
        post(e) {
            console.debug("post middleware");
            if (!e.response.ok) {
                {
                    const msg = `request failed: ${e.url}`;
                    notification.error({
                        message: msg,
                        placement: "bottomRight"
                    });
                    console.debug(e.init, msg);
                }
            }
            return Promise.resolve(e.response);
        }
    }
];

// eslint-disable-next-line @typescript-eslint/no-var-requires, @typescript-eslint/ban-ts-comment
// @ts-ignore
const url = import.meta.env.VITE_API_URL;

const eventsConfig = () =>
    new eventsClient.Configuration({
        basePath: url,
        middleware: postAuthMiddlewares
    });


export const topicsApi = new eventsClient.TopicsApi(eventsConfig());
export const messageApi = new eventsClient.MessagesApi(eventsConfig());
export const loginApi = new eventsClient.LoginApi( new eventsClient.Configuration({
    basePath: url,
    middleware: preAuthMiddlewares
}));

export function getCookie(name: string) {
    const match = document.cookie.match(new RegExp("(^| )" + name + "=([^;]+)"));
    if (match) return match[2];

    return "";
}
