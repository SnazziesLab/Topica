

import * as eventsClient from "@event-client"
import {notification} from "antd"
const middlewares: eventsClient.Middleware[] = [
    {
        pre(e) {
            console.debug("pre middleware");
            const req = { ...e };
            const requestHeaders = new Headers(req.init.headers);
            requestHeaders.append("Authorization", getCookie("token"));
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

const eventsConfig = () =>
    new eventsClient.Configuration({
        basePath: import.meta.env.API_URL,
        middleware: middlewares
    });
export const orgsApi = new eventsClient.EventsApi(eventsConfig());

export function getCookie(name: string) {
    const match = document.cookie.match(new RegExp("(^| )" + name + "=([^;]+)"));
    if (match) return match[2];

    return "";
}
