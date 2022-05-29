export function loadView(section) {
    document.querySelector('#container').replaceChildren(...section)
}