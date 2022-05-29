const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

let host = 'http://localhost:3030';

let browser, page;
// You should change test name as test.js

describe('E2E tests', function () {
    this.timeout(10000);
    before(async () => {
        browser = await chromium.launch({ handless: false, slowMo: 2000 });
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


    it('Should load all comments', async () => {
        let messages = ["-Spami: Hello, are you there?",
            "-Garry: Yep, whats up :?",
            "-Spami: How are you? Long time no see? :)",
            "-George: Hello, guys! :))",
            "-Spami: Hello, George nice to see you! :)))"]

        await page.goto('http://127.0.0.1:5500/index.html');
        await page.waitForSelector('#main');

        await Promise.all([
            page.waitForResponse(`${host}/jsonstore/messenger`),
            page.click('#refresh')
        ]);

        let messagesArea = await page.locator('#messages').textContent();
        messagesArea = messages.join('\n');
        let allMess = messages.join('\n');
        expect(allMess).to.equal(messagesArea);
    });   

    it('Should send message', async() => {
        const author = 'Ivan';
        const content = 'What are you going?';

        await page.goto('http://127.0.0.1:5500/index.html');
        await page.waitForSelector('#main');

            await page.fill('#author', author);
            await page.fill('#content', content);

        const[response] = await Promise.all([
            page.waitForResponse(`${host}/jsonstore/messenger`),
            page.click('#submit')
        ]);

        const data = JSON.parse(response.request().postData());

        expect(author).to.equal(data.author);
        expect(content).to.equal(data.content);
    })
})
