const button = document.querySelector('#sidebarToggle');



button.addEventListener('click', () => {
  let id = null;
  const navbar = document.querySelector('#layoutSidenav_nav');
  let pos = navbar.style.left === ''?  0 : parseInt(navbar.style.left);
  if(navbar.style.display === 'none') {
    navbar.style.display = 'block';
    clearInterval(id);
    id = setInterval(frame, 10);
    function frame() {
      if(pos === 0) {
	clearInterval(id);
	return;
      }
      pos += 30;
      navbar.style.left = pos + 'px';
    }

  }
  else {
    clearInterval(id);
    id = setInterval(frame, 10);
    function frame() {
      if(pos === -300) {
	clearInterval(id);
	navbar.style.display = 'none';
	return;
      }
      pos -= 30;
      navbar.style.left = pos + 'px';
    }
  }
});
