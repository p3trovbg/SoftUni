
export function createElement(element, textCon, type, className, value, parent, src, attribute) {
    let domElement = document.createElement(element);

    if (textCon) {
        domElement.textContent = textCon;
    }
    if (type) {
        domElement.type = type;
    }
    if (className) {
        domElement.className = className;
    }
    if (value) {
        domElement.value = value;
    }
    if (parent) {
        parent.appendChild(domElement);
    }
    if(src) {
        parent.src = src;
    }
    if(attribute) {
        parent.setAttribute("alt", attribute)
    }
    return domElement;
}