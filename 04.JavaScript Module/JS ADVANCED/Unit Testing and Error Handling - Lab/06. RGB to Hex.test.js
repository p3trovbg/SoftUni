const expect = require('chai').expect;
const rgbToHexColor = require('./06. RGB to Hex');

describe('Convert RGB to Hex', () => {
    describe('Input elements', () => {
        it('Should return undefined if input is out of range', () => {
            expect(rgbToHexColor(-1,5,3)).to.equal(undefined);
            expect(rgbToHexColor(3,-7,4)).to.equal(undefined);
            expect(rgbToHexColor(3,5,-3)).to.equal(undefined);
    
            expect(rgbToHexColor(256,5,6)).to.equal(undefined);
            expect(rgbToHexColor(3,300,7)).to.equal(undefined);
            expect(rgbToHexColor(2,5,400)).to.equal(undefined);
        })
    
        it('Should return undefined if input are not numbers', () => {
            expect(rgbToHexColor('9',5,6)).to.equal(undefined);
            expect(rgbToHexColor(3,'d',3)).to.equal(undefined);
            expect(rgbToHexColor(8,5,'x')).to.equal(undefined);
            
        })
    })
    describe('Output', () => {
        it('Should return true Hex', () => {
            expect(rgbToHexColor(27,149,91)).to.equal('#1B955B');
            expect(rgbToHexColor(11,63,38)).to.equal('#0B3F26');
            expect(rgbToHexColor(63,38,11)).to.equal('#3F260B');
            expect(rgbToHexColor(0,0,0)).to.equal('#000000');
            expect(rgbToHexColor(42,42,42)).to.equal('#2A2A2A');
        }) 
    })
})