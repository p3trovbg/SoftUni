const expect = require('chai').expect;
const sum = require('./04. Sum of Numbers');


describe('Sum of numbers', () => {
    it('Should return sum by array', () => {
        let numbers = [3, 3, 3];
        let expectedSum = 9;
        
        let actualSum = sum(numbers);

        expect(actualSum).to.equal(expectedSum);
    })

    it('Should return wrong result by sum on digits', () => {
        let numbers = [3, 3, 3];
        let expectedSum = 5;
        
        let actualSum = sum(numbers);

        expect(actualSum).to.not.equal(expectedSum);
    })

    it('Should return zero if array is empty', () => {
        let numbers = [];
        let expectedSum = 0;
        
        let actualResult = sum(numbers);

        expect(actualResult).to.equal(expectedSum);
    })

    it('Should return zero if array is empty', () => {
        let numbers = [2, 2, 'Gosho'];
        //let expectedSum = NaN;
        
        let actualResult = sum(numbers);

        expect(actualResult).to.be.NaN;
    })
})