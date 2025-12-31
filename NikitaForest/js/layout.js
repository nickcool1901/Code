const headerFallback = `
<nav class="block-flame">
  <ul>
    <li><a href="index.html">Home</a></li>
    <li><a href="index1.html">About me</a></li>
    <li><a href="index2.html">Contacts</a></li>
  </ul>
  <button class="btnLogin-popup">Login</button>
</nav>
`;

const footerFallback = `
<footer class="site-footer block-flame">
  <div class="site-footer__glow" aria-hidden="true"></div>
  <div class="site-footer__brand">I play WOW!</div>
  <div class="site-footer__links">
    <a href="index.html">Home</a>
    <a href="index1.html">About me</a>
    <a href="index2.html">Contacts</a>
  </div>
  <div class="site-footer__note">Click the flame to move it. Login coming soon.</div>
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
