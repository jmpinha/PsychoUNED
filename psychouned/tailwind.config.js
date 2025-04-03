// Configuración básica de Tailwind CSS incluyendo DaisyUI
module.exports = {
  content: [
    './src/**/*.{html,ts}',
    './src/**/*.scss'
  ],
  theme: {
    extend: {},
  },
  plugins: [
    require('daisyui')
  ],
};

