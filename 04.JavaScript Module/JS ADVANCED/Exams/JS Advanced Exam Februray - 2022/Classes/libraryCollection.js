class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];

    }

    addBook(bookName, bookAuthor) {
        if(this.books.length == this.capacity) {
            throw new Error("Not enough space in the collection.");
        }

        this.books.push({bookName, bookAuthor, payed: false})
        return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }

    payBook(bookName) {
        let currentBook = this.books.find(x => x.bookName == bookName);

        if (!currentBook) {
            throw new Error(`${bookName} is not in the collection.`);
        }
        if(currentBook.payed == true) {
            throw new Error (`${bookName} has already been paid.`);
        }

        currentBook.payed = true;
        return `${bookName} has been successfully paid.`;
    } 
    
    removeBook(bookName) {
        let currentBook = this.books.find(x => x.bookName == bookName);

        if (!currentBook) {
            throw new Error (`The book, you're looking for, is not found.`);
        }

        if(currentBook.payed == false) {
            throw new Error (`${bookName} need to be paid before removing from the collection.`);
        }

        this.books = this.books.filter(x => x.bookName !== bookName);
        return `${bookName} remove from the collection.`;
    }

    getStatistics(bookAuthor) {
        if(bookAuthor == undefined) {
            let result = '';
            result += `The book collection has ${this.capacity - this.books.length} empty spots left.\n`;
            this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));
            for (const book of this.books) {
                result += `${book.bookName} == ${book.bookAuthor} - ${book.payed == false ? 'Not Paid' : 'Has Paid'}.\n`;
            }
            return result.trimEnd();

        } else {
            let book = this.books.find(x => x.bookAuthor);
            if (book) {
                return `${book.bookName} == ${book.bookAuthor} - ${book.payed == false ? 'Not Paid' : 'Has Paid'}.`;
            } else {
                throw new Error(`${bookAuthor} is not in the collection.`);
            }
         }  
    }
}

const library = new LibraryCollection(2)
library.addBook('In Search of Lost Time', 'Marcel Proust');
console.log(library.payBook('In Search of Lost Time'));
console.log(library.payBook('Don Quixote'));

