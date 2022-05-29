function sortingNumbers(array) {
    let ascendingOrder  = array.sort((a, b) => a - b);
    let sorting = [];
    while (ascendingOrder.length > 0) {
        sorting.push(ascendingOrder.shift());
        sorting.push(ascendingOrder.pop());
    }

    return sorting;
}

sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);