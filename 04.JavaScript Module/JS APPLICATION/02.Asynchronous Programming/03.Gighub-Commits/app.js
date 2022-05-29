function loadCommits() {
    let username = document.getElementById('username');
    let repo = document.getElementById('repo');
    let commitsElement = document.getElementById('commits');

   const url = `https://api.github.com/repos/${username.value}/${repo.value}/commits`;

    fetch(url)
    .then(data => {
        if(data.status == 404) {
            throw new Error('Not found!');
        }
        return data.json();
    })
    .then(result => {
        while(commitsElement.firstChild) {
            commitsElement.removeChild(commitsElement.firstChild);
        }

        for (const commit of result) {
            let liElement = document.createElement('li');
            let aElement = document.createElement('a');
            aElement.textContent = `${commit.commit.author.name}: ${commit.commit.message}`; 
            liElement.appendChild(aElement);

            commitsElement.appendChild(liElement);
        }
    })
    .catch(error => {
        commitsElement.textContent = `${error.message}`; 
    })
}