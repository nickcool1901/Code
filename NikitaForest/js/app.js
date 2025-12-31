window.addEventListener('scroll', () => {
  document.documentElement.style.setProperty('--scrollTop', `${window.scrollY}px`);
});

if (window.gsap) {
  gsap.registerPlugin(ScrollTrigger, ScrollSmoother);
  ScrollSmoother.create({
    wrapper: '.wrapper',
    content: '.content'
  });
}

function initFlame() {
  const flame = document.getElementById('flame');
  if (!flame) return;

  const randomPoint = () => {
    const padding = 40;
    const x = Math.random() * (window.innerWidth - padding * 2) + padding;
    const y = Math.random() * (window.innerHeight - padding * 2) + padding;
    return { x, y };
  };

  const place = (x, y) => {
    const offsetX = flame.offsetWidth / 2;
    const offsetY = flame.offsetHeight / 2;
    flame.style.left = `${x - offsetX}px`;
    flame.style.top = `${y - offsetY}px`;
  };

  const placeRandom = () => {
    const { x, y } = randomPoint();
    place(x, y);
  };

  const showFlame = () => {
    flame.style.display = 'block';
    placeRandom();
  };

  const trigger = document.querySelector('.button__white');
  if (trigger) {
    trigger.addEventListener('click', showFlame);
  }

  flame.addEventListener('click', placeRandom);
  flame.addEventListener('touchstart', (event) => {
    event.preventDefault();
    placeRandom();
  }, { passive: false });

  window.addEventListener('resize', () => {
    if (flame.style.display === 'block') {
      placeRandom();
    }
  });
}

document.addEventListener('DOMContentLoaded', () => {
  initFlame();
});
