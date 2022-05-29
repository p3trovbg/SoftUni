const expect = require('chai').expect;
const createCalculator = require('./07.Add-Subtract');

describe('Behaviour on calculator', () => {
    it('Function should return object', () => {
      expect(typeof createCalculator()).to.equal('object');
    })

    it('The method should return object with three properties', () => {
        let calculatorObj = createCalculator();
        expect(calculatorObj).to.have.own.property('add');
        expect(calculatorObj).to.have.property('subtract');
        expect(calculatorObj).to.have.own.property('get');
    })

    it('The get function should return value', () => {
        let calculatorObj = createCalculator();
        calculatorObj.add(5);
        expect(calculatorObj.get()).to.equal(5);
    })

    it('The add function should return NaN if parameter is different by number', () => {
        let calculatorObj = createCalculator();
        calculatorObj.add("pet");
        expect(calculatorObj.get()).to.be.NaN; 
    })
    
}) 
 