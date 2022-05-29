 class Story {
     constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
        this._ids = {};
     }

    get likes() {
        if(this._likes.length == 0) {
            return `${this.title} has 0 likes`;
        } else if (this._likes.length == 1) {
            return `${this._likes[0]} likes this story!`;
        } else {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
        }
    }

    like(username) {
        if(this._likes.includes(username)) {
            throw new Error(`You can't like the same story twice!`);
        } else if (username == this.creator) {
            throw new Error("You can't like your own story!");
        } else {
            this._likes.push(username);
            return `${username} liked ${this.title}!`;
        }
    }

    dislike(username) {
        if(!this._likes.includes(username)) {
            throw new Error("You can't dislike this story!");
        } else {
            let idx = this._likes.indexOf(username);
            this._likes.splice(idx, 1);
            return `${username} disliked ${this.title}`;
        }
    }

    comment(username, content, id) {
        let result = '';
        let currentCommentar = this._comments.find(x => x.id == id);
        if(!currentCommentar) {
            id = this._comments.length + 1;
            this._comments.push({id, username, content, replies: [] });
            return result = `${username} commented on ${this.title}`;
        } else {
            if(!this._ids[currentCommentar.id]) {
                this._ids[currentCommentar.id] = 0.1;
            } else {
                this._ids[currentCommentar.id] += 0.1;
            }
            let repliesId = currentCommentar.id + this._ids[currentCommentar.id];
            currentCommentar.replies.push({repliesId, username, content});  
            return "You replied successfully";
        }
    }

    toString(parameter) {
        if(parameter == 'username') {
           this._comments.sort((a, b) => a.username.localeCompare(b.username)).map(x => x.replies.sort((a, b) =>  a.username.localeCompare(b.username)));
        } else if (parameter == 'desc') {
            this._comments.sort((a, b) => b.id - a.id).map(x => x.replies.sort((a, b) => b.repliesId - a.repliesId));
        } else if (parameter == 'asc') {
            this._comments.sort((a, b) => a.id - b.id).map(x => x.replies.sort((a, b) => a.repliesId - b.repliesId));
        }

        let result = '';
        result += `Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}\nComments:\n`; 
        for (const comment of this._comments) {
            result += `-- ${comment.id}. ${comment.username}: ${comment.content}\n`;
            if(comment.replies.length > 0) {
                for (const reply of comment.replies) {
                    result += `--- ${reply.repliesId}. ${reply.username}: ${reply.content}\n`;
                }
            }
        }
        return result.trimEnd();
    }
 }
