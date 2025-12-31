const headerFallback = `
<header class="site-header block-flame">
  <div class="site-header__bar">
    <a class="site-header__brand" href="index.html" aria-label="Home">NikitaForest</a>
    <nav class="site-header__nav">
      <a href="index1.html">About me</a>
      <a href="index2.html">Contacts</a>
    </nav>
    <button class="btnLogin-popup">Login</button>
  </div>
</header>
`;

const footerFallback = `
<footer class="site-footer block-flame">
  <div class="site-footer__glow" aria-hidden="true"></div>
  <div class="site-footer__content">
    <div class="site-footer__col">
      <div class="site-footer__brand">NIKITAFOREST</div>
      <p class="site-footer__text">Crafting things I enjoy. Ping me if you want to chat.</p>
    </div>
    <div class="site-footer__col">
      <div class="site-footer__links">
        <a href="index.html">Home</a>
        <a href="index1.html">About me</a>
        <a href="index2.html">Contacts</a>
      </div>
    </div>
    <div class="site-footer__col">
      <div class="site-footer__heading">Contacts</div>
      <ul class="site-footer__list">
        <li><a href="+37124665552">+371 2466 5552</a></li>
        <li><a href="https://www.instagram.com/nekijtak/" target="_blank" rel="noopener">Instagram</a></li>
      </ul>
    </div>
  </div>
</footer>
`;

function loadPartials() {
  const includes = document.querySelectorAll('[data-include]');

  includes.forEach((node) => {
    const name = node.getAttribute('data-include');
    if (!name) return;

    const fallback = name === 'header' ? headerFallback : name === 'footer' ? footerFallback : '';
    const url = `partials/${name}.html`;

    fetch(url)
      .then((res) => {
        if (!res.ok) throw new Error(res.statusText);
        return res.text();
      })
      .catch(() => fallback)
      .then((html) => {
        node.innerHTML = html;
        if (name === 'header') {
          wireLogin(node);
        }
      });
  });
}

function wireLogin(root) {
  const loginBtn = root.querySelector('.btnLogin-popup');
  if (!loginBtn) return;
  loginBtn.addEventListener('click', () => {
    // Placeholder for future auth flow
    console.log('Login clicked');
  });
}

document.addEventListener('DOMContentLoaded', loadPartials);
