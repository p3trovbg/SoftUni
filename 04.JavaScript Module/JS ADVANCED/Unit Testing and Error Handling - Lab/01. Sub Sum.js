function solve(array, startIdx, lastIdx) {
    if(!Array.isArray(array)) {
        return NaN;
    }
    let digits = array.map(x => Number(x));
     if(startIdx < 0) {
        startIdx = 0;
    } else if(lastIdx >= digits.length) {
        lastIdx = digits.length - 1;
    }

    let sum = 0;
    if(digits.length > 0) {
        sum = digits.slice(startIdx, lastIdx + 1).reduce((a, cV) => a + cV);
    }
    return sum;
}


 console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));
 console.log(solve([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(solve([10, 'twenty', 30, 40], 0, 2));
console.log(solve([], 1, 2));
console.log(solve('text', 0, 2));