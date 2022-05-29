function biggerHalfFromArray(array) {
    let biggerHalf = array.sort((a, b) => a - b).slice(array.length / 2);
    return biggerHalf;
}

biggerHalfFromArray([4, 7, 2, 5]);
biggerHalfFromArray([3, 19, 14, 7, 2, 19, 6]);
