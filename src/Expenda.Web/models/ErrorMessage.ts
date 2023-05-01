export interface ErrorMessage {
    code: string;
    value: string;
}

export const getInternalServerErrorMessage = (): ErrorMessage => {
    return {
        code: "INTERNAL_SERVER_ERROR",
        value: "Server error, please wait some time before trying again!",
    };
};
