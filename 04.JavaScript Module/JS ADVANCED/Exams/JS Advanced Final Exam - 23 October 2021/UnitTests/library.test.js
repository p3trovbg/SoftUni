const library = require('./UnitTests/library');
const expect = require('chai').expect;

describe('Testing on library object', () => {
    describe('Test function - calc price of book', () => {
        it('Should throw exception if book name is not string or year is not digit', () => {
            expect(function() {library.calcPriceOfBook(5, 2005)}).throw('Invalid input');
            expect(function() {library.calcPriceOfBook("The dark", "One")}).throw('Invalid input');
            expect(function() {library.calcPriceOfBook(true, 2005)}).throw('Invalid input');
            expect(function() {library.calcPriceOfBook("The dark", false)}).throw('Invalid input');
        })

        it('If year of book is less or equal on 1980, it should decrease price with 50%', () => {
            expect(library.calcPriceOfBook("The Dark", 1975)).to.equal(`Price of The Dark is 10.00`);
            expect(library.calcPriceOfBook("The Dark", 1980)).to.equal(`Price of The Dark is 10.00`);
        })

        it('If the year is bigger than 1980, price must be 20.00 dollars', () => {
            expect(library.calcPriceOfBook("The Dark", 1999)).to.equal(`Price of The Dark is 20.00`);
            expect(library.calcPriceOfBook("The Dark", 1981)).to.equal(`Price of The Dark is 20.00`);
        })
    })

    describe('Test function - find book', () => {
        it('Should throw exception if input is empty string', () => {
            expect(function() {library.findBook([], "The dark")}).throw('No books currently available');
        })
        it('Should throw exception if desired book is find out', () => {
            expect(library.findBook(["The Ice", "Tupac"], "Tupac")).to.equal("We found the book you want.");
        })
        it('Should throw exception if desired book is not found out', () => {
            expect(library.findBook(["The Ice", "Tupac"], "The Dark")).to.equal("The book you are looking for is not here!");
        })
    })

    describe('Arrange ot the books', () => {
        it('Should throw exception if counts is less than 0 or is not digit', () => {
            expect(function() {library.arrangeTheBooks(-5)}).throw('Invalid input');
            expect(function() {library.arrangeTheBooks('Gosho')}).throw('Invalid input');
            expect(function() {library.arrangeTheBooks(false)}).throw('Invalid input');
            expect(function() {library.arrangeTheBooks([])}).throw('Invalid input');
        })

        it('Should return successful arrange if count is less or equal on avaliable space', () => {
            expect(library.arrangeTheBooks(35)).to.equal('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(40)).to.equal('Great job, the books are arranged.');
        })

        it('Should return note if count is bigger than on avaliable space', () => {
            expect(library.arrangeTheBooks(55)).to.equal('Insufficient space, more shelves need to be purchased.');
        })
    })
})