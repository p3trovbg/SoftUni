function colorize() {
    let elements = document.getElementsByTagName('tr');
    let elementsArray = Array.of(elements);
    let count = 0;
    for (const element of elementsArray[0]) {
        if (count >= 0 && count % 2 != 0) {
            element.style.backgroundColor = "teal";
        }
        count++;
    }
}