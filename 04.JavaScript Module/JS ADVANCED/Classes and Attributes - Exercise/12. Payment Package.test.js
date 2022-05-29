const expect = require('chai').expect;
const PaymentPackage = require('./12. Payment Package');

describe("Payment package object", () => {
    describe("Constructor", () => {
        it("Should receives two parameters which must set them and set default values",() => {
            let testPackage = new PaymentPackage('Consultation', 800);
            expect(testPackage.name).to.equal('Consultation');
            expect(testPackage.value).to.equal(800);
            expect(testPackage.VAT).to.equal(20);
            expect(testPackage.active).to.equal(true);
        });
    });

    describe('Test on getters and setters', () => {
        it('Should throw exception if name is not string or is empty', () => {
            expect(function () { new PaymentPackage('', 500) }).to.throw('Name must be a non-empty string');
            expect(function () { new PaymentPackage(5, 500) }).to.throw('Name must be a non-empty string');
            expect(function () { new PaymentPackage(true, 500) }).to.throw('Name must be a non-empty string');
            expect(function () { new PaymentPackage(false, 500) }).to.throw('Name must be a non-empty string');
        })

        it('Name should be change if set new value', () => {
            var obj = new PaymentPackage('Gosho', 1000);
            obj.name = "pesho";
            expect(obj.name).to.equal('pesho');
        })

        it('Should throw exception if value is not digit or less than 0', () => {
            expect(function () { new PaymentPackage('Pesho', -5) }).to.throw('Value must be a non-negative number');
            expect(function () { new PaymentPackage("pesho", "tito") }).to.throw('Value must be a non-negative number');
            expect(function () { new PaymentPackage("pesho", false) }).to.throw('Value must be a non-negative number');
            expect(function () { new PaymentPackage("gosho", true) }).to.throw('Value must be a non-negative number');
        })

        it('Value should be change if set new value', () => {
            var obj = new PaymentPackage('Gosho', 1000);
            obj.value = 5000;
            expect(obj.value).to.equal(5000);
        })

        it('Should throw exception if VAT is not digit or less than 0', () => {
            let obj = new PaymentPackage('Pesho', 5);
            expect(function () { obj.VAT = -50 }).to.throw('VAT must be a non-negative number');
            expect(function () { obj.VAT = 'Gosho' }).to.throw('VAT must be a non-negative number');
            expect(function () { obj.VAT = false }).to.throw('VAT must be a non-negative number');
            expect(function () { obj.VAT = true }).to.throw('VAT must be a non-negative number');
        })

        it('VAT should be change if set new value', () => {
            var obj = new PaymentPackage('Gosho', 1000);
            obj.VAT = 50;
            expect(obj.VAT).to.equal(50);
            expect(obj.VAT).not.equal(20);
        })

        it('Should throw exception if ACTIVE is not boolean', () => {
            let obj = new PaymentPackage('Pesho', 5);
            expect(function () { obj.active = 50 }).to.throw('Active status must be a boolean');
            expect(function () { obj.active = 'Gosho' }).to.throw('Active status must be a boolean');
            expect(function () { obj.active = {} }).to.throw('Active status must be a boolean');
            expect(function () { obj.active = [] }).to.throw('Active status must be a boolean');
        })

        it('Active should be change if set new value', () => {
            var obj = new PaymentPackage('Gosho', 1000);
            obj.active = true;
            expect(obj.active).to.equal(true);
        })
    });

    describe('Behaviour on toString function', () => {
        it('Should return result every row on new line', () => {
            let obj = new PaymentPackage('Pesho', 2000);
            const output = [
                `Package: ${obj.name}` + (obj.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${obj.value}`,
                `- Value (VAT ${obj.VAT}%): ${obj.value * (1 + obj.VAT / 100)}`
              ];
              let result = output.join('\n');
              expect(obj.toString()).to.equal(result);
        })

        it('If obj is not active, on name must append inactive', () => {
            let obj = new PaymentPackage('Pesho', 2000);
            obj.active = false;
            const output = [
                `Package: ${obj.name}` + ' (inactive)',
                `- Value (excl. VAT): ${obj.value}`,
                `- Value (VAT ${obj.VAT}%): ${obj.value * (1 + obj.VAT / 100)}`
              ];
              let result = output.join('\n');
              expect(obj.toString()).to.equal(result);
        })
    })
});
