/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Pages/**/*.{razor,html}',
    './Shared/**/*.{razor,html}',
    './Components/**/*.{razor,html}',
    './wwwroot/**/*.html'
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}