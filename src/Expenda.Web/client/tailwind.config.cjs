/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./src/**/*.{html,tsx}"],
    theme: {
        extend: {},
        fontFamily: {
            montserrat: ["Montserrat"],
        },
    },
    plugins: [],
    corePlugins: {
        preflight: false,
    },
};
