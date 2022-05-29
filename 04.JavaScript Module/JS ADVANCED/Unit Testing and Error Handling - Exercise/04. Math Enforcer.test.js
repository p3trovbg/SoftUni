const mathEnforcer = require('./04. Math Enforcer');
const expect = require('chai').expect;

describe('Math Enforcer object', () => {
  describe('addFive function', () => {
        it('Function should return undefined if the input is not number', () => {
            expect(mathEnforcer.addFive('y')).to.equal(undefined);
            expect(mathEnforcer.addFive('5')).to.equal(undefined);
            expect(mathEnforcer.addFive()).to.equal(undefined);
            expect(mathEnforcer.addFive([5, 6])).to.equal(undefined);
            expect(mathEnforcer.addFive({name: "gosho"})).to.equal(undefined);
        })
        it('function with positive number', () => {
            expect(mathEnforcer.addFive(5)).to.equal(10);
        })
        it('function with negative number', () => {
            expect(mathEnforcer.addFive(-10)).to.equal(-5);
        })
        it('function with floating number', () => {
            expect(mathEnforcer.addFive(5.555)).to.be.closeTo(10.55, 0.01);
        })
    })

    describe('subtractTen Function', () => {
        it('Function should return undefined if the input is not number', () => {
            expect(mathEnforcer.subtractTen('y')).to.equal(undefined);
            expect(mathEnforcer.subtractTen('5')).to.equal(undefined);
            expect(mathEnforcer.subtractTen()).to.equal(undefined);
            expect(mathEnforcer.subtractTen([5, 6])).to.equal(undefined);
            expect(mathEnforcer.subtractTen({name: "gosho"})).to.equal(undefined);
        })
        it('function with positive number', () => {
            expect(mathEnforcer.subtractTen(10)).to.equal(0);
        })
        it('function with negative number', () => {
            expect(mathEnforcer.subtractTen(-20)).to.equal(-30);
        })
        it('function with floating number', () => {
            expect(mathEnforcer.subtractTen(-5.55)).to.be.closeTo(-15.55, 0.01);
        })
    })

    describe('sum function', () => {
        it('Function sum should return undefined if one of parameters is not number', () => {
            expect(mathEnforcer.sum('y', 6)).to.equal(undefined);
            expect(mathEnforcer.sum('5', [1, 2])).to.equal(undefined);
            expect(mathEnforcer.sum()).to.equal(undefined);
            expect(mathEnforcer.sum(5, {name: "gosho"})).to.equal(undefined);
            expect(mathEnforcer.sum(false,{name: "gosho"})).to.equal(undefined);
        })
        it('function with positive number', () => {
            expect(mathEnforcer.sum(5, 5)).to.equal(10);
        })
        it('function with negative number', () => {
            expect(mathEnforcer.sum(-10, -10)).to.equal(-20);
        })
        it('function with floating number', () => {
            expect(mathEnforcer.sum(5.55, 5.55)).to.be.closeTo(11.1, 0.01);
        })
    })
})