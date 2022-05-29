function loadRepos() {
   let result = document.getElementById('res');

   fetch("https://api.github.com/users/testnakov/repos")
   .then(res => res.text())
   .then((res) => {
      result.textContent = res;
   })

}