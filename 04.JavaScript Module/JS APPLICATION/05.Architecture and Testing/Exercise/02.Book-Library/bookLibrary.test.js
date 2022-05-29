const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

let host = 'http://localhost:3030';

let browser, page;
// You should change test name as test.js

describe('E2E tests', function () {
    this.timeout(15000);
    before(async () => {
        browser = await chromium.launch();
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


    it('Should load all books', async () => {
        await page.goto('http://127.0.0.1:5500/index.html');
    
        await page.click('#loadBooks');
        await page.waitForSelector('table>tbody>tr');
        const visible = await page.isVisible('table>tbody>tr');
        expect(visible).to.be.true;
    });
    
    it('Should add book', async() => {
        const title = 'Левски'; 
        const author = 'Иван Вазов'
        //Знам, че е ода!
        await page.goto('http://127.0.0.1:5500/index.html');

        await page.fill('[name="title"]', title);
        await page.fill('[name="author"]', author);

        await page.click('text=Submit');
        await page.click('#loadBooks');

        const bookTitle = await page.textContent('tbody tr:nth-child(3) :nth-child(1)');
        const authorName = await page.textContent('tbody tr:nth-child(3) :nth-child(2)');

        expect(title).to.equal(bookTitle);
        expect(author).to.equal(authorName);
    })

    it('Should edit book', async() => {
        const title = 'Епопея на забравените'; 
        const author = 'Иван Вазов'
        await page.goto('http://127.0.0.1:5500/index.html');
        await page.click('#loadBooks');

        await page.click('table tbody tr:nth-child(3) td:nth-child(3) .editBtn');

        await page.fill('#editForm > [name="title"]', title);

        await page.click('text=Save');
        await page.click('#loadBooks');

        const bookTitle = await page.textContent('tbody tr:nth-child(3) :nth-child(1)');
        const authorName = await page.textContent('tbody tr:nth-child(3) :nth-child(2)');

        expect(title).to.equal(bookTitle);
        expect(author).to.equal(authorName);
    })

    it('Should delete book', async() => {
        await page.goto('http://127.0.0.1:5500/index.html');
        await page.click('#loadBooks');

        page.on('dialog', (dialog) => {
            dialog.accept();
        });

        await page.click('table tbody tr:nth-child(3) td:nth-child(3) .deleteBtn');

        await page.click('#loadBooks');
        const bookTitle = await page.isVisible('tbody tr:nth-child(3) :nth-child(1)');
        const authorName = await page.isVisible('tbody tr:nth-child(3) :nth-child(2)');

        expect(bookTitle).to.be.false;
        expect(authorName).to.be.false;
    })
})
