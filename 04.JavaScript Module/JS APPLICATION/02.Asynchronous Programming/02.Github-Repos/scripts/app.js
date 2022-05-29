function loadRepos() {
	let usernameElement = document.getElementById('username').value;
	const url = `https://api.github.com/users/${usernameElement}/repos`;
	let repos = document.getElementById('repos');

	fetch(url)
	.then(result => {
		if(result.status == 404) {
			throw new Error('Not found!');
		}
		return result.json();
	})
	.then(result => {
		while(repos.firstChild) {
			repos.removeChild(repos.firstChild);
		}

		for (const currentRepo of result) {
			let liElement = document.createElement('li');
			let aElement = document.createElement('a');

			aElement.setAttribute("href", currentRepo.html_url);
			//aElement.textContent = currentRepo.full_name;
			aElement.textContent = currentRepo.name;

			liElement.appendChild(aElement);
			repos.appendChild(liElement);
		}
	})
	.catch(error => {
		repos.textContent = `${error.message}` 
	})
}