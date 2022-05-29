// ⦁	chop - divide the number by two
// ⦁	dice - square root of a number
// ⦁	spice - add 1 to the number
// ⦁	bake - multiply number by 3
// ⦁	fillet - subtract 20% from the number
function cooking(number, op1, op2, op3, op4, op5) {
    let digit = Number(number);
    let operations = [op1, op2, op3, op4, op5];
    for (let i = 0; i < operations.length; i++) {
        let operation = operations[i];
        switch (operation) {
            case 'chop': digit /= 2; break;
            case 'dice': digit = Math.sqrt(digit); break;
            case 'spice': digit += 1; break;
            case 'bake': digit *= 3; break;
            case 'fillet': digit = digit * 0.8; break;
        }
        console.log(digit);   
    }
}

cooking('32', 'chop', 'chop', 'chop', 'chop', 'chop')
cooking('9', 'dice', 'spice', 'chop', 'bake', 'fillet')