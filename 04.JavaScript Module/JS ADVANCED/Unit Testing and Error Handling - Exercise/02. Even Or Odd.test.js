const expect = require('chai').expect;
const isOddOrEven = require('./02. Even Or Odd');

describe('Functon should return odd/even/undefined', () => {
    it('Funtion should return undefined if paramater is not string', () => {
        expect(isOddOrEven(5)).to.equal(undefined);
        expect(isOddOrEven([5, 6])).to.equal(undefined);
    })

    it('Function should return odd if the parameter is with odd length', () => {
        expect(isOddOrEven('das')).to.equal('odd');
    })
    it('Function should return even if the parameter is with even length', () => {
        expect(isOddOrEven('dass')).to.equal('even');
    })
})