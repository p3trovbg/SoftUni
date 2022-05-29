const lookupChar = require('./03. Char Lookup');
const expect = require('chai').expect;

describe('lookupChar', () => {
    it('Function should returns undefined if first parameter is not string and second parameter is not integer', () => {
        expect(lookupChar(5, 5)).to.equal(undefined);
        expect(lookupChar('5', '5')).to.equal(undefined);
        expect(lookupChar('5', 5.5)).to.equal(undefined);
    })

    it('Function should return undefined if value is less by 0 or most of string length', () => {
        expect(lookupChar('gosho', 5)).to.equal("Incorrect index");
        expect(lookupChar('gosho', 10)).to.equal("Incorrect index");
        expect(lookupChar('gosho', -5)).to.equal("Incorrect index");
    }) 
    it('Function should return current char from the string', () => {
        expect(lookupChar('gosho', 0)).to.equal("g");
        expect(lookupChar('gosho', 4)).to.equal("o");
    })
})