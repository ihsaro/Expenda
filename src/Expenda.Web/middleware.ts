import { NextRequest, NextResponse } from "next/server";

import { isAccessTokenValid } from "lib/authentication";
import { validateToken } from "lib/csrf";

export const middleware = (request: NextRequest): NextResponse => {
    const response = NextResponse.next();

    if (
        ["POST", "PUT", "PATCH", "DELETE"].includes(request.method) &&
        (request.cookies["xs"] === undefined ||
            request.headers["xs"] === undefined ||
            request.cookies["xs"] !== request.headers["xs"] ||
            !validateToken(request.cookies["xs"]))
    ) {
        return NextResponse.rewrite(new URL("/500", request.url));
    }

    if (
        request.nextUrl.pathname !== "/" &&
        (request.cookies.get("at") === undefined ||
            (request.cookies.get("at") &&
                request.cookies.get("at").value &&
                !isAccessTokenValid(request.cookies.get("at").value)))
    ) {
        return NextResponse.redirect(new URL("/", request.url));
    } else if (
        request.nextUrl.pathname === "/" &&
        request.cookies.get("at") !== undefined &&
        request.cookies.get("at") &&
        request.cookies.get("at").value &&
        isAccessTokenValid(request.cookies.get("at").value)
    ) {
        return NextResponse.redirect(new URL("/app", request.url));
    }

    return response;
};

export const config = {
    matcher: [
        "/",
        "/app",
        "/app/expenses",
        "/app/monthly-budgets",
        "/app/settings",
    ],
};
