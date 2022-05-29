function attachEvents() {
    let postButton = document.getElementById('btnLoadPosts');
    let commentButton = document.getElementById('btnViewPost')
    let posts = document.getElementById('posts');
    let postComments = document.getElementById('post-comments');

    postButton.addEventListener('click', getInfo);
    commentButton.addEventListener('click', getInfo);

            async function getInfo(e) {
                try{
                    if(e.target.textContent == 'Load Posts')
                    {
                        let allPosts = await getAllPosts();     
                        for (const key in allPosts) {
                            let post = allPosts[key];
                            let option = document.createElement('option');
                            option.value = key;
                            option.textContent = post['title'];
                            posts.appendChild(option);
                        }
                    } else {
                        
                        let currentPostId = document.getElementById('posts').value;
                        let currentPost = await getCurrentPost(currentPostId);
                        let comments = await getComments(currentPostId);

                        document.getElementById('post-title').textContent = currentPost.title;
                        document.getElementById('post-body').textContent = currentPost.body;

                        postComments.replaceChildren();
                        for (const comment of comments) {
                            let li = document.createElement('li');
                            li.textContent = comment.text;
                            postComments.appendChild(li);
                        }                 
                    }
                }
                catch(error){
                    document.getElementById('post-title').textContent = error.message;
                }
            }
        }
       
        async function getCurrentPost(id) {
            let baseUrl = 'http://localhost:3030/jsonstore/blog/posts/' + id;
            let response = await fetch(baseUrl);
            if(response.status !== 200) {
                throw new Error('Invalid URL!');
            }
            return response.json();
        }

        async function getAllPosts() {
            let baseUrl = `http://localhost:3030/jsonstore/blog/posts`;
            let response = await fetch(baseUrl);
            if(response.status !== 200) {
                throw new Error('Invalid URL!');
            }
            return response.json();
        }

        async function getComments(id) {
            let baseUrl = `http://localhost:3030/jsonstore/blog/comments`;
            let response = await fetch(baseUrl);
            if(response.status !== 200) {
                throw new Error('Invalid URL!');
            }
            let data = await response.json();

            return Object.values(data).filter(c => c.postId == id);
        }

attachEvents();