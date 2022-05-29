class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = {
             picture:200,
             photo:50,
             item:250 
            }
        this.listOfArticles = [];
        this.guests = []; 
    }

    addArticle(articleModel, articleName, quantity ) {
        articleModel = articleModel.toLowerCase();
        if(!this.possibleArticles[articleModel]) {
            throw new Error("This article model is not included in this gallery!");
        }
        let currentArticle = this.listOfArticles.find(x => x.articleName == articleName);
        if (!currentArticle) {
            this.listOfArticles.push({articleModel, articleName, quantity});
        } else {
            currentArticle.quantity += quantity;
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest (guestName, personality) {
        if(!this.guests.find(x => x.guestName == guestName)) {
            this.guests.push({guestName, points: 0, purchaseArticle: 0})
        } else {
            throw Error(`${guestName} has already been invited.`);
        }
        let guest = this.guests.find(x => x.guestName == guestName);
        switch(personality) {
            case 'Vip': guest.points = 500; break;
            case 'Middle': guest.points = 250; break;
            default:
                guest.points = 50;
                break;
        }

        return `You have successfully invited ${guestName}!`;
    }

    buyArticle (articleModel, articleName, guestName) {
        let currentArticle = this.listOfArticles.find(x => x.articleName == articleName);
        if(!currentArticle || currentArticle.articleModel !== articleModel) {
            throw new Error("This article is not found.");
        }
        if(currentArticle.quantity == 0) {
            return `The ${articleName} is not available.`;
        }
        let guest = this.guests.find(x => x.guestName == guestName);
        if (!guest) {
            return "This guest is not invited.";
        }
        articleModel = articleModel.toLowerCase();
       let necessaryPoints = this.possibleArticles[articleModel];
       if(guest.points < necessaryPoints) {
           return "You need to more points to purchase the article.";
       } 
       guest.points -= necessaryPoints;
       currentArticle.quantity --;
       guest.purchaseArticle++;

       return `${guestName} successfully purchased the article worth ${necessaryPoints} points.`;
    }

    showGalleryInfo (criteria) {
        let result = '';
        if(criteria == 'article') {
            result += "Articles information:\n";
            for (const currentArticle of this.listOfArticles) {
                result += `${currentArticle.articleModel} - ${currentArticle.articleName} - ${currentArticle.quantity}\n`;
            }
        } else {
            result += "Guests information:\n";
            for (const guest of this.guests) {
                result += `${guest.guestName} - ${guest.purchaseArticle}\n`;
            }
        }
        return result.trimEnd();
    }
}

const artGallery = new ArtGallery('Curtis Mayfield');
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
console.log(artGallery.buyArticle('picture', 'Mona Liza', 'John'));
console.log(artGallery.buyArticle('item', 'Ancient vase', 'Peter'));
console.log(artGallery.buyArticle('item', 'Mona Liza', 'John'));


