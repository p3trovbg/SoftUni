function arrangement(array) {
    let arrangementArray = [];
    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        if (element < 0)
        {
            arrangementArray.unshift(element);
        } else {
            arrangementArray.push(element);
        }
    }

    for (const digit of arrangementArray) {
        console.log(digit);
    }
}

arrangement([3, -2, 0, -1]);