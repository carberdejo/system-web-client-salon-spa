const colors = require('tailwindcss/colors');
module.exports = {
    purge: {
        enabled: true,
        content: [
            './**/*.{js,jsx,ts,tsx,cshtml}',
        ],
    },
    theme: {
        extend: {},
    },
    plugins: [],
}