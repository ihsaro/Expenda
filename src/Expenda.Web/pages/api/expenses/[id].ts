import { Endpoints } from "constants/endpoints";
import { TransactionResult } from "models/TransactionResult";
import type { NextApiRequest, NextApiResponse } from "next";

export default async (
    req: NextApiRequest,
    res: NextApiResponse<TransactionResult<boolean>>
) => {
    const { id } = req.query;
    if (req.method === "DELETE") {
        const response = await fetch(
            `${process.env.REST_HOST}/${Endpoints.EXPENSES}/${id}`,
            {
                method: "DELETE",
                headers: {
                    Authorization: `Bearer ${req.cookies["at"]}`,
                },
            }
        );

        res.status(response.status);

        if (response.status === 204) {
            res.end();
        }
        else if (response.status === 404) {
            const data: TransactionResult<boolean> = await response.json();
            res.json(data);
        }
    }
};
