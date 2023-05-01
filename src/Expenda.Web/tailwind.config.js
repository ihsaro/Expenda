/** @type {import('tailwindcss').Config} */
export default {
    content: [
        "./pages/**/*.{html,js,jsx,ts,tsx}",
        "./components/**/*.{html,js,jsx,ts,tsx}",
    ],
    corePlugins: {
        preflight: false,
    },
    theme: {
        extend: {},
    },
    plugins: [],
    important: true,
};
