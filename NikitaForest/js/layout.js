function loadPartials() {
  const includes = document.querySelectorAll('[data-include]');

  includes.forEach((node) => {
    const name = node.getAttribute('data-include');
    if (!name) return;

    fetch(`partials/${name}.html`)
      .then((res) => res.text())
      .then((html) => {
        node.innerHTML = html;
        if (name === 'header') {
          wireLogin(node);
        }
      })
      .catch((err) => {
        console.error(`Failed to load partial "${name}"`, err);
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
