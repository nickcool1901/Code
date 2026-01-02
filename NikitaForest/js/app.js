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

  const padding = 40;

  const getBounds = () => {
    const header = document.querySelector('.site-header');
    const footer = document.querySelector('.site-footer');
    const headerHeight = header ? header.offsetHeight : 70;
    const footerHeight = footer ? footer.offsetHeight : 160;
    const halfW = flame.offsetWidth / 2;
    const halfH = flame.offsetHeight / 2;
    const container = document.querySelector('.content');
    const containerWidth = container ? container.clientWidth : document.documentElement.clientWidth;
    const containerHeight = container ? container.scrollHeight : document.documentElement.scrollHeight;

    const minX = padding + halfW;
    const maxX = containerWidth - padding - halfW;
    const minY = headerHeight + padding + halfH;
    const maxY = containerHeight - footerHeight - padding - halfH;

    return { minX, maxX, minY, maxY };
  };

  const clampToBounds = (x, y) => {
    const { minX, maxX, minY, maxY } = getBounds();
    const clampedX = Math.min(maxX, Math.max(minX, x));
    const clampedY = Math.min(maxY, Math.max(minY, y));
    return { x: clampedX, y: clampedY };
  };

  const randomPoint = () => {
    const { minX, maxX, minY, maxY } = getBounds();
    const rangeX = Math.max(maxX - minX, 0);
    const rangeY = Math.max(maxY - minY, 0);
    const x = minX + Math.random() * (rangeX || 1);
    const y = minY + Math.random() * (rangeY || 1);
    return { x, y };
  };

  const place = (x, y) => {
    const offsetX = flame.offsetWidth / 2;
    const offsetY = flame.offsetHeight / 2;
    const { x: boundedX, y: boundedY } = clampToBounds(x, y);
    const nextLeft = `${boundedX - offsetX}px`;
    const nextTop = `${boundedY - offsetY}px`;

    if (window.gsap) {
      gsap.to(flame, {
        left: nextLeft,
        top: nextTop,
        duration: 0.7,
        ease: 'power2.out'
      });
    } else {
      flame.style.left = nextLeft;
      flame.style.top = nextTop;
    }
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
