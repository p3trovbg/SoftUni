function solve(input) {
    const digits = [];
        for (const element of input) {
            if(Number(element)) {
                digits.push(element);
            } else if (digits.length >= 2) {
                let first = digits.pop();
                let second = digits.pop();
                switch(element) {
                    case '+': digits.push(second + first); break;
                    case '*': digits.push(second * first); break;
                    case '/': digits.push(second / first); break;
                    case '-': digits.push(second - first); break;
                }
            } else {
                console.log('Error: not enough operands!');
                return;
            }
        }

        digits.length > 1 ?  console.log(`Error: too many operands!`) :  console.log(digits[0]);
}

solve([5,
    3,
    4,
    '*',
    '-']
   );