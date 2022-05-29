function solve(digits, criteria) {
    criteria == 'asc' ? digits.sort((a, b) => a - b) : digits.sort((a, b) => b - a)
    return digits;
}


solve([14, 7, 17, 6, 8], 'desc');