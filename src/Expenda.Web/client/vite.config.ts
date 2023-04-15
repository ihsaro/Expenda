import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

import { fileURLToPath } from "url";

// https://vitejs.dev/config/
export default defineConfig({
    build: {
        emptyOutDir: true,
    },
    plugins: [react()],
    resolve: {
        alias: {
            "~": fileURLToPath(new URL("./src", import.meta.url)),
        },
    },
});
