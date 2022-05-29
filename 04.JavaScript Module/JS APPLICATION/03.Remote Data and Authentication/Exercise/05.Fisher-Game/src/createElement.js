function createElement(element, textCon, type, className, value, parent) {
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
    return domElement;
}


module.exports = createElement;