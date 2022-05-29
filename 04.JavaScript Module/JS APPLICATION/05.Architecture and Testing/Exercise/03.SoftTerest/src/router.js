export function initial(links) {
    const main = document.querySelector('main');
    document.querySelector('nav').addEventListener('click', onNav);

    const context = {
        showSection,
        goTo,
        typeNav
    }

    return context;


    function onNav(event) {
        let targetElement = event.target;
        if(targetElement.tagName == 'IMG') {
            targetElement = targetElement.parentElement;
        }

        if(targetElement.tagName == 'A') {
            event.preventDefault();
            const url = new URL(targetElement.href);
            goTo(url.pathname);
        }
    }


    function goTo(link) {
        const currentSection = links[link];
        if(typeof currentSection == 'function') {
            currentSection(context);
        }
    }

    function showSection(section) {
        main.replaceChildren(section);
    }

    function typeNav() {
        let token = sessionStorage.getItem('userToken');
        if(token == null) {
            document.querySelectorAll('.user').forEach(x => x.style.display = 'none')
            document.querySelectorAll('.guest').forEach(x => x.style.display = 'block')
        } else {
            document.querySelectorAll('.user').forEach(x => x.style.display = 'block')
            document.querySelectorAll('.guest').forEach(x => x.style.display = 'none')
        }
    }
}
