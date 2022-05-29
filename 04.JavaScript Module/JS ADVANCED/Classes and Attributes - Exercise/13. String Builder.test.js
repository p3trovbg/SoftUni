const expect = require('chai').expect;
const StringBuilder = require('./13. String Builder');

describe("Test of StringBuilder object", () =>{
    describe("Test on constructor", () =>{
        it('Should set empty array if input also is empty', () => {
            let obj = new StringBuilder();
            expect(obj.toString()).to.equal('');
        })

        it('Should throw exception if argument is not string', () => {
            expect(function () { new StringBuilder(5) }).to.throw('Argument must be a string');
            expect(function () { new StringBuilder(true) }).to.throw('Argument must be a string');
            expect(function () { new StringBuilder(false) }).to.throw('Argument must be a string');
            expect(function () { new StringBuilder({}) }).to.throw('Argument must be a string');
            expect(function () { new StringBuilder([]) }).to.throw('Argument must be a string');
        })

        it('Should adds element to array', () => {
            let obj = new StringBuilder('gosho');
            expect(obj.toString()).to.equal('gosho');
        })
    });
    describe('Test on methods', () =>{
        it('Append function should adds element to array', () => {
            let obj = new StringBuilder('gosho');
            obj.append('petrov');
            expect(obj.toString()).to.equal('goshopetrov');
        })
        it('Append function should returns error if pass as not string', () => {
            let obj = new StringBuilder('gosho');
            expect(function () { obj.append(5) }).to.throw('Argument must be a string');
            expect(function () { obj.append(true) }).to.throw('Argument must be a string');
            expect(function () { obj.append(false) }).to.throw('Argument must be a string');
        })

        it('Prepend function should adds element from zero index on right', () => {
            let obj = new StringBuilder('gosho');
            obj.prepend('petrov');
            expect(obj.toString()).to.equal('petrovgosho');
        })
        it('Prepend function should returns error if pass as not string', () => {
            let obj = new StringBuilder('gosho');
            expect(function () { obj.prepend(5) }).to.throw('Argument must be a string');
            expect(function () { obj.prepend(true) }).to.throw('Argument must be a string');
            expect(function () { obj.prepend(false) }).to.throw('Argument must be a string');
        })

        it('Insert At function, should inserts element on current index', () => {
            let obj = new StringBuilder('gosho');
            obj.insertAt('petrov', 2);
            expect(obj.toString()).to.equal('gopetrovsho');
        })

        it('Insert At function, should inserts element on start if index is less than 0', () => {
            let obj = new StringBuilder('gosho');
            obj.insertAt('petrov', -10);
            expect(obj.toString()).to.equal('petrovgosho');
        })

        it('Insert At function, should inserts element on end if index is more than string length', () => {
            let obj = new StringBuilder('gosho');
            obj.insertAt('petrov', 10);
            expect(obj.toString()).to.equal('goshopetrov');
        })
        it('Insert At function, should throws exception if pass as not string', () => {
            let obj = new StringBuilder('gosho');
            obj.insertAt('petrov', 2);
            expect(function () { obj.insertAt(5, 2) }).to.throw('Argument must be a string');
            expect(function () { obj.insertAt(true, 3) }).to.throw('Argument must be a string');
            expect(function () { obj.insertAt(false, 1) }).to.throw('Argument must be a string');
        })

        it('Remove function should cuts array with pass range', () => {
            let obj = new StringBuilder('gosho');
            obj.remove(0, 2);
            expect(obj.toString()).to.equal('sho');
        })

        it('toString function should returns string with elements', () => {
            let obj = new StringBuilder('gosho');
            expect(obj.toString()).to.equal('gosho');
        })
    })

});
