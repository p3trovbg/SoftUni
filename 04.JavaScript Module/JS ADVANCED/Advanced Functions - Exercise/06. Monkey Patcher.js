function solution(command) {
    if(command == 'upvote') {
        return this.upvotes++;
    } else if (command == 'downvote') {
        return this.downvotes++;
    } else {
        let votes = this.upvotes + this.downvotes;
        let score = this.upvotes - this.downvotes;
        let inflation = Math.ceil(Math.max(this.downvotes, this.upvotes) * 0.25);
        let inflatedUpvotes = votes > 50 ? this.upvotes + inflation : this.upvotes;
        let inflatedDownvotes = votes > 50 ? this.downvotes + inflation : this.downvotes;
        let rating = 'new';

        if (votes < 10) {
            rating = 'new';
        } else if (this.upvotes > votes * 0.66) {
            rating = 'hot';
        } else if (score >= 0 && votes > 100) {
            rating = 'controversial';
        } else if (score < 0) {
            rating = 'unpopular';
        }

        return [inflatedUpvotes, inflatedDownvotes, score, rating];
    }
}
let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};
solution.call(post, 'upvote');
solution.call(post, 'downvote');
let score = solution.call(post, 'score'); // [127, 127, 0, 'controversial']
solution.call(post, 'downvote');         // (executed 50 times)
score = solution.call(post, 'score');     // [139, 189, -50, 'unpopular']
