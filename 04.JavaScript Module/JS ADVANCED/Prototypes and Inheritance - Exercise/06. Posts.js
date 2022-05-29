function solution() {
    class Post{
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post{
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = Number(likes);
            this.dislikes = Number(dislikes);
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let result = '';
            result += super.toString() + '\n';
            result += `Rating: ${this.likes - this.dislikes}\n`;
            if(this.comments.length > 0) {
                result += `Comments:\n`;
                for (const comment of this.comments) {
                    result += ` * ${comment}\n`;
                }
            }
            return result.trimEnd();
        }
    }

    class BlogPost extends Post{
        constructor(name, content, views) {
            super(name, content);
            this.views = Number(views);
        }

        view() {
            this.views += 1;
            return this;
        }

        toString() {
            let result = '';
            result += super.toString() + '\n';
            result += `Views: ${this.views}`;
            return result;
        }
    }

    return {Post, SocialMediaPost, BlogPost}
}

const classes = solution();
let post = new classes.Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!


