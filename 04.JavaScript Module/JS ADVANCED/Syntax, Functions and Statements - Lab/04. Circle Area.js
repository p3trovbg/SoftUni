function circleArea(input){
    let typeInput = typeof(input);
    if (typeInput != 'number')
    {
        console.log(`We can not calculate the circle area, because we receive a ${typeInput}.`);
    } else {
        let result = Math.pow(input, 2) * Math.PI;
        console.log(result.toFixed(2));
    }
}

circleArea('name');