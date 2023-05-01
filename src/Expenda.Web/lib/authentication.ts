import decode, { JwtPayload as Payload } from "jwt-decode";

export const isAccessTokenValid = (at: string): boolean => {
    try {
        return (
            decode<Payload>(at).exp > Math.round(new Date().getTime() / 1000)
        );
    } catch {
        return false;
    }
};
