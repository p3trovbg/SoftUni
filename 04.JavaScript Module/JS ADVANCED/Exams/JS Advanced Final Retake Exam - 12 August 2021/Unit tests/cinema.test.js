let cinema = require('./Unit tests/cinema');
let expect = require('chai').expect;

describe("Tests cinema object", () => {
    describe("Testing on show movies function", () => {
        it("Should return that it is not have movies to show", () => {
            expect(cinema.showMovies([])).to.equal('There are currently no movies to show.');
        });
        it('Should return movies separate with comma and interval', () => {
            expect(cinema.showMovies(['The Dark', 'Transporter'])).to.equal('The Dark, Transporter');
        })
     });

     describe("Testing on ticket price function", () => {
        it("Should throw error if obj isn't possessions current parameter", () => {
            expect(function() {cinema.ticketPrice('What') }).to.throw('Invalid projection type.');
            expect(function() {cinema.ticketPrice(true) }).to.throw('Invalid projection type.');
            expect(function() {cinema.ticketPrice(2) }).to.throw('Invalid projection type.');
        });

        it('Should return price on current movie', () => {
            expect(cinema.ticketPrice('Premiere')).to.equal(12.00);
            expect(cinema.ticketPrice('Normal')).to.equal(7.50);
            expect(cinema.ticketPrice('Discount')).to.equal(5.50);
        })
        
     });

     describe("Testing on Swap seats In Hall", () => {
        it("Successful swap", () => {
            expect(cinema.swapSeatsInHall(5, 19)).to.equal("Successful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(1, 15)).to.equal("Successful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(5, 1)).to.equal("Successful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(5, 1)).to.equal("Successful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(20, 1)).to.equal("Successful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(2, 20)).to.equal("Successful change of seats in the hall.");
        })

        it("Unsuccessfull swap", () => {
            expect(cinema.swapSeatsInHall(-5, 19)).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(0, 15)).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(21, 1)).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall('g', 1)).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(true, 1)).to.equal("Unsuccessful change of seats in the hall.");

            expect(cinema.swapSeatsInHall(5, 0)).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(0, 10)).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(5, 21)).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(5, true)).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(5, 'g')).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(5, 5)).to.equal("Unsuccessful change of seats in the hall.");
        })     
     });
});
