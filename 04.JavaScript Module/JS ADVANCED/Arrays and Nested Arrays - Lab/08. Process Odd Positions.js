function odd(array) {
    const oddArr = array.filter((x, i) => i % 2 == 1).map(x => x * 2).reverse();
    console.log(oddArr.join(' '));
}

odd([10, 15, 20, 25]);
odd([3, 0, 10, 4, 7, 3]);