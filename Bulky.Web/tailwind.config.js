/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Pages/**/*.cshtml",
    "./Views/**/*.cshtml",
    "wwwroot/**/*.{js,css}",
  ],
  daisyui: {
    themes: ["dim", "dark", "dracula", "nord"],
  },
  theme: {
    container: {
      center: true,
      padding: "2rem",
      screens: {
        "2xl": "1400px",
      },
    },
    fontSize: {
      sm: "0.833rem",
      base: "1rem",
      xl: "1.200rem",
      "2xl": "1.440rem",
      "3xl": "1.728rem",
      "4xl": "2.074rem",
      "5xl": "2.489rem",
    },
    fontFamily: {
      heading: "Nixie One",
      body: "Proza Libre",
    },
    fontWeight: {
      normal: "400",
      bold: "700",
    },
    extend: {},
  },
  plugins: [
    require("@tailwindcss/typography"),
    require("@tailwindcss/aspect-ratio"),
    require("tailwind-scrollbar"),
    require("daisyui"),
  ],
};
