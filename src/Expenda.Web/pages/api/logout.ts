import type { NextApiRequest, NextApiResponse } from "next";

export default async (req: NextApiRequest, res: NextApiResponse<boolean>) => {
    if (req.method === "POST") {
        res.setHeader("set-cookie", "at=deleted; Max-Age=0; path=/");
        res.status(200);
        res.json(true);
    }
};
