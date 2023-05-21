import { Endpoints } from "constants/endpoints";
import { UserDataMetrics } from "models/UserDataMetrics";
import { TransactionResult } from "models/TransactionResult";
import type { NextApiRequest, NextApiResponse } from "next";

export default async (
    req: NextApiRequest,
    res: NextApiResponse<TransactionResult<UserDataMetrics>>
) => {
    if (req.method === "GET") {
        const response = await fetch(
            `${process.env.REST_HOST}/${Endpoints.USER_DATA_METRICS}`,
            {
                method: "GET",
                headers: {
                    Authorization: `Bearer ${req.cookies["at"]}`,
                },
            }
        );

        const data: TransactionResult<UserDataMetrics> = await response.json();

        res.status(200);
        res.json(data);
    }
};
