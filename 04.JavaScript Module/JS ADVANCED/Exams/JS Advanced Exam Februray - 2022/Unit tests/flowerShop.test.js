let expect = require('chai').expect;
let flowerShop = require('./Unit tests/flowerShop');

describe("Tests on object flower shop", () => {
    describe("Test on calculate price of flowers function", () =>{
        it("Should throw error if inputs is not correct format", () =>{
            expect(() => {flowerShop.calcPriceOfFlowers(5, 20, 30)}).to.throw('Invalid input!');
            expect(() => {flowerShop.calcPriceOfFlowers('Gosho', 'Pesho', 30)}).to.throw('Invalid input!');
            expect(() => {flowerShop.calcPriceOfFlowers(5, 20, '30')}).to.throw('Invalid input!');
        });

        it('Should return total sum about flowers', () => {
            expect(flowerShop.calcPriceOfFlowers('Rose', 5, 10)).to.equal(`You need $${(5 * 10).toFixed(2)} to buy ${'Rose'}!`);
        })
     });
     //checkFlowersAvailable
     describe("Test on function which check about flowers avaliable", () =>{
         it('Should return that it finds avaliable flower on current index', () => {
             let flowers = ['Rose', 'Jasmine'];
             expect(flowerShop.checkFlowersAvailable('Rose', flowers)).to.equal(`The ${'Rose'} are available!`);
         })

         it('Should return that it not find avaliable flower on current index', () => {
            let flowers = ['Rose', 'Jasmine'];
            expect(flowerShop.checkFlowersAvailable('Lilly', flowers)).to.equal(`The Lilly are sold! You need to purchase more!`);
        })
    });

    describe("Test on function that sell flowers", () =>{
        it('Should throw exception if parameters are not correct', () => {
            let flowers = ['Rose', 'Jasmine'];
            expect(() => {flowerShop.sellFlowers(5, 1)}).to.throw('Invalid input!');
            expect(() => {flowerShop.sellFlowers(flowers, '5')}).to.throw('Invalid input!');
            expect(() => {flowerShop.sellFlowers(flowers, -5)}).to.throw('Invalid input!');
            expect(() => {flowerShop.sellFlowers(flowers, 2)}).to.throw('Invalid input!');
            expect(() => {flowerShop.sellFlowers(flowers, 5)}).to.throw('Invalid input!');
        })

        it('Should return array with flowers', () => {
           let flowers = ['Rose', 'Jasmine', 'Lilly'];
           let output = flowers.join(' / ');
            expect(flowerShop.sellFlowers(flowers, 2)).to.equal(`Rose / Jasmine`);
       })
   });

});
