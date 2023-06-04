import { Endpoints } from "constants/endpoints";
import { ExpenseResponse } from "models/ExpenseResponse";
import { TransactionResult } from "models/TransactionResult";
import type { NextApiRequest, NextApiResponse } from "next";

export default async (
    req: NextApiRequest,
    res: NextApiResponse<
        | TransactionResult<Array<ExpenseResponse>>
        | TransactionResult<ExpenseResponse>
    >
) => {
    if (req.method === "GET") {
        const response = await fetch(
            `${process.env.REST_HOST}/${Endpoints.EXPENSES}`,
            {
                method: "GET",
                headers: {
                    Authorization: `Bearer ${req.cookies["at"]}`,
                },
            }
        );

        const data: TransactionResult<Array<ExpenseResponse>> =
            await response.json();

        res.status(200);
        res.json(data);
    } else if (req.method === "POST") {
        const response = await fetch(
            `${process.env.REST_HOST}/${Endpoints.EXPENSES}`,
            {
                method: "POST",
                headers: {
                    Authorization: `Bearer ${req.cookies["at"]}`,
                    "Content-Type": "application/json",
                },
                body: req.body,
            }
        );

        const data: TransactionResult<ExpenseResponse> = await response.json();

        res.status(response.status);
        res.json(data);
    }
};
