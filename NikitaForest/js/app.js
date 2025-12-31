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

  const blockedSelectors = 'nav, footer, button, a, input, textarea, select, label, .site-footer, .page-shell, .main-article__content, .layers, .layer__header, .card, .button__white';

  const shouldIgnore = (target) => {
    return !target || target.closest(blockedSelectors);
  };

  const place = (x, y) => {
    const offsetX = flame.offsetWidth / 2;
    const offsetY = flame.offsetHeight / 2;
    flame.style.left = `${x - offsetX}px`;
    flame.style.top = `${y - offsetY}px`;
  };

  const centerFlame = () => {
    place(window.innerWidth * 0.5, window.innerHeight * 0.4);
  };

  document.addEventListener('click', (event) => {
    if (shouldIgnore(event.target)) return;
    place(event.clientX, event.clientY);
  });

  document.addEventListener('touchstart', (event) => {
    const touch = event.touches[0];
    if (!touch) return;
    if (shouldIgnore(event.target)) return;
    place(touch.clientX, touch.clientY);
  }, { passive: true });

  window.addEventListener('resize', centerFlame);
  centerFlame();
}

document.addEventListener('DOMContentLoaded', () => {
  initFlame();
});
