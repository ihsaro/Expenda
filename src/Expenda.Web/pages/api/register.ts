import { Endpoints } from "constants/endpoints";
import { RegisterResponse } from "models/RegisterResponse";
import { TransactionResult } from "models/TransactionResult";
import type { NextApiRequest, NextApiResponse } from "next";

export default async (
    req: NextApiRequest,
    res: NextApiResponse<TransactionResult<RegisterResponse>>
) => {
    if (req.method === "POST") {
        const response = await fetch(
            `${process.env.REST_HOST}/${Endpoints.REGISTER}`,
            {
                method: "POST",
                body: req.body,
                headers: {
                    "Content-Type": "application/json",
                },
            }
        );

        const data: TransactionResult<RegisterResponse> = await response.json();

        res.status(data.success ? 200 : 400);
        res.json(data);
    }
};
