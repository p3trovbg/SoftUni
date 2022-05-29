const expect = require('chai').expect;
const isSymmetric = require('./05. Check for Symmetry');

describe('Function cheks for Symmetry', () => {
    it('Should return false if input is array', () => {
        let input = 5;
        let secondInput= '5';
        let thirdInput = {name: "gosho"};
        let expectedSum = false;

        let actualResult = isSymmetric(input);
        actualResult = isSymmetric(secondInput);
        actualResult = isSymmetric(thirdInput);
        expect(actualResult).to.equal(expectedSum);
    })

    it('Should return true if array is symmetryic', () => {
        let input = [1, 2, 3, 2, 1];
        let expectedSum = true;

        let actualResult = isSymmetric(input);
        expect(actualResult).to.equal(expectedSum);
    })

    it('Should return false if array is not symmetryic', () => {
        let input = [1, 2, 3, 2, 1, 1, 2];
        let expectedSum = false;

        let actualResult = isSymmetric(input);
        expect(actualResult).to.equal(expectedSum);
    })

    it('Should return true if array is empty', () => {
        let input = [];
        let expectedSum = true;

        let actualResult = isSymmetric(input);
        expect(actualResult).to.equal(expectedSum);
    })

    it('Should return true if in array exist same digits which are negative and positive', () => {
        let input = [-5, 5];
        let expectedSum = false;

        let actualResult = isSymmetric(input);
        expect(actualResult).to.equal(expectedSum);
    })

    it('Should return false if in array exist different element by others', () => {
        let input = ['5', '2,', 5];
        let expectedSum = false;

        let actualResult = isSymmetric(input);
        expect(actualResult).to.equal(expectedSum);
    })
})