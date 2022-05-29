function square(input)  {
    for (let i = 0; i < input; i++) {
        let result = '';
        for (let j = 0; j < input; j++) {
           result += '* ';
        }
        console.log(result);
    }
}
square(5);