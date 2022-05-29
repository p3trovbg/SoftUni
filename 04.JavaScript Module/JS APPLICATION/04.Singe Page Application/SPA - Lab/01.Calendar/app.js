let years = ['2020', '2021', '2022', '2023']
let months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

import { showSelection as showSection } from "./home.js";
let sectionName = 'years';
document.addEventListener('click', onNavigate);

showSection(sectionName);

function onNavigate(event) {
    let target;
    let element = event.target;
    if (element.tagName === 'TD') {
        target = element.children[0].textContent;
    } else if (element.tagName === 'DIV') {
        target = element.textContent;
    } else if (element.id === 'homeBtn') {
        showSection('years');
        return;
    }

    if(years.includes(target)) {
        let currentSec = `year-${target}`;
        showSection(currentSec);
    } else if(months.includes(target)) {
        let idx = months.indexOf(target);
        let currentMonth = element.parentElement.parentElement.parentElement.parentElement.id.split('-');
        currentMonth = `month-${currentMonth[1]}-${idx + 1}`;
        showSection(currentMonth);
    }
}