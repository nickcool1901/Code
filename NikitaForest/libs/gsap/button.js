const button = document.getElementById('myButton');

// Устанавливаем случайные начальные координаты для кнопки
button.style.top = Math.random() * window.innerHeight + 'px';
button.style.left = Math.random() * window.innerWidth + 'px';

// Обрабатываем событие клика на кнопке
button.addEventListener('click', () => {
  // Генерируем случайные координаты для кнопки
  const x = Math.random() * window.innerWidth;
  const y = Math.random() * window.innerHeight;
  // Устанавливаем новые координаты кнопки
  button.style.top = y + 'px';
  button.style.left = x + 'px';
});
