function getSmallestTwoNumbers(array) {
    let sortArray = array.sort((a, b) => a - b).slice(0, 2);
    console.log(sortArray.join(' '));
}

getSmallestTwoNumbers([30, 15, 50, 5]);