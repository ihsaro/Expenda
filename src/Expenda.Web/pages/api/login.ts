import { Endpoints } from "constants/endpoints";
import { LoginResponse } from "models/LoginResponse";
import { TransactionResult } from "models/TransactionResult";
import type { NextApiRequest, NextApiResponse } from "next";

export default async (
    req: NextApiRequest,
    res: NextApiResponse<TransactionResult<LoginResponse>>
) => {
    if (req.method === "POST") {
        const response = await fetch(
            `${process.env.REST_HOST}/${Endpoints.LOGIN}`,
            {
                method: "POST",
                body: req.body,
                headers: {
                    "Content-Type": "application/json",
                },
            }
        );

        const data: TransactionResult<LoginResponse> = await response.json();

        console.log(data);

        if (data.success) {
            res.setHeader(
                "set-cookie",
                `at=${data.result_object.access_token}; Secure; HttpOnly; SameSite=Lax; Path=/`
            );
            res.status(200);
        } else {
            res.status(400);
        }
        res.json(data);
    }
};
