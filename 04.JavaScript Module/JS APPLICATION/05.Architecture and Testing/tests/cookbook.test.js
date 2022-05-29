const { chromium } = require('playwright-chromium');
const { expect } = require('chai');


let browser, page;

describe('E2E tests', function () {
    this.timeout(12222);
    before(async () => {
        browser = await chromium.launch({ handless: false, slowMo: 1000 });
    });
    after(async () => {
        await browser.close();
    });
    beforeEach(async () => {
        page = await browser.newPage();
    });
    afterEach(async () => {
        await page.close();
    });


    describe('Catalog', () =>{
        it('Navigation', async () => {
            await page.goto('http://127.0.0.1:5500/index.html');
             const content = await page.textContent('header');
             expect(content).to.contains('Catalog');
             expect(content).to.contains('Login');
             expect(content).to.contains('Register');
             expect(content).to.contains('My Cookbook');
        });
        it('The catalog page should load and render the content of the API', async () => {
            await page.goto('http://127.0.0.1:5500/index.html');
            await page.waitForSelector('#catalog> .preview');
            const contentVisible = await page.isVisible('#catalog> .preview');
            expect(contentVisible).to.be.true;
        });
        //const pictureVisible = await page.isVisible('#catalog>article:first-child >>.small');
        it('Displays the recipe details', async () => {
            await page.goto('http://127.0.0.1:5500/index.html');
            await page.click('#catalog> .preview');
            await page.waitForSelector('#details> article');
            expect(await page.isVisible('#details> article > h2')).to.be.true;
            expect(await page.isVisible('#details> article > .band')).to.be.true;
            expect(await page.isVisible('#details> article > .description')).to.be.true;
        });  
    })

    describe('Authentication', () => {
        it('Login', async() => {
            const email = 'peter@abv.bg';
            const password = '123456';
        
            await page.goto('http://127.0.0.1:5500/index.html');
            await page.click('header> nav > #guest > #loginLink');
            await page.waitForSelector('form');
        
            await page.fill('[name="email"]', email);
            await page.fill('[name="password"]', password);
        
            let [response] = await Promise.all([
                page.waitForResponse('http://localhost:3030/users/login'),
                page.click('[type="submit"]')
            ]);

            const user = JSON.parse(response.request().postData());
            expect(user.email).to.equal(email);
            expect(user.password).to.equal(password);

        })

        it('Register', async() => {
            const email = 'gosho@abv.bg';
            const password = '123456';

            await page.goto('http://127.0.0.1:5500/index.html');
            await page.click('header> nav > #guest > #registerLink');
            await page.waitForSelector('form');

            await page.fill('[name="email"]', email);
            await page.fill('[name="password"]', password);
            await page.fill('[name="rePass"]', password);

            const [response] = await Promise.all([
                page.waitForResponse('http://localhost:3030/users/register'),
                page.click('[type="submit"]')
            ]);

            const user = JSON.parse(response.request().postData());
            expect(user.email).to.equal(email);
            expect(user.password).to.equal(password);

        })
    })

    describe('CRUD operations', () => {
        it('create" makes correct API call for logged in user', async() => {
            login();

            let recipe = {
                name: 'Octopus(Fried)',
                img: 'https://assets.kulinaria.bg/attachments/pictures-images/0000/1408/MAIN-oktopod-na-tigan.jpg?1431614709',
                ingredients: ['oil', 'octopous', 'limon', 'etc...'],
                steps: ['step1', 'step2'],
                _id: '0002',
                _ownerId: '0001'
            }

            await page.click('#createLink');
            await page.waitForSelector('form');

            await page.fill('[name="name"]', recipe.name);
            await page.fill('[name="img"]', recipe.img);
            await page.fill('[name="ingredients"]', recipe.ingredients.join('\n'));
            await page.fill('[name="steps"]', recipe.steps.join('\n'));

            const [response] = await Promise.all([
                page.waitForResponse('http://localhost:3030/data/recipes'),
                page.click('[type="submit"]')
            ]);

            const data = JSON.parse(response.request().postData());
            
            expect(data.name).to.equal(recipe.name);
            expect(data.img).to.equal(recipe.img);
            expect(data.ingredients).to.deep.equal(recipe.ingredients);
            expect(data.steps).to.deep.equal(recipe.steps);

        })

        it('The author should see Delete and Edit buttons', async() => {
            login();

            let recipe = {
                name: 'Octopus(Fried)',
                img: 'https://assets.kulinaria.bg/attachments/pictures-images/0000/1408/MAIN-oktopod-na-tigan.jpg?1431614709',
                ingredients: ['oil', 'octopous', 'limon', 'etc...'],
                steps: ['step1', 'step2'],
                _id: '0002',
                _ownerId: '0001'
            }

            await page.click('#createLink');
            await page.waitForSelector('form');

            await page.fill('[name="name"]', recipe.name);
            await page.fill('[name="img"]', recipe.img);
            await page.fill('[name="ingredients"]', recipe.ingredients.join('\n'));
            await page.fill('[name="steps"]', recipe.steps.join('\n'));

            await Promise.all([
                page.waitForResponse('http://localhost:3030/data/recipes'),
                page.click('[type="submit"]')
            ]);

            await page.waitForSelector('#details> article');
            expect(await page.isVisible('#details> article > .controls')).to.be.true;
            

        })
    })

     async function login() {
            const email = 'peter@abv.bg';
            const password = '123456';
        
            await page.goto('http://127.0.0.1:5500/index.html');
            await page.click('header> nav > #guest > #loginLink');
            await page.waitForSelector('form');
        
            await page.fill('[name="email"]', email);
            await page.fill('[name="password"]', password);
        
            let [response] = await Promise.all([
                page.waitForResponse('http://localhost:3030/users/login'),
                page.click('[type="submit"]')
            ]);
        }
})
