export function createElement(element, textCon, type, className, value, parent, src, attributeValue, attributeType, href) {
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
        domElement.setAttribute('src', src)
    }
    if(attributeValue && attributeType) {
        domElement.setAttribute(attributeType, attributeValue)
    }
    if(href) {
        domElement.href = href;
    }
    return domElement;
}