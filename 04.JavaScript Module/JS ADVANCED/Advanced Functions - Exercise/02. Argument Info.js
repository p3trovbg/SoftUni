function solve() {
    let result = {};
    for (const element of arguments) {
        let type = typeof(element);
        console.log(`${type}: ${element}`);
        if(!result[type]) {
            result[type] = 0;
        }
        result[type] += 1;
    }
    Object.keys(result)
    .sort((a, b) => result[b] - result[a])
    .forEach((x) => {
        console.log(`${x} = ${result[x]}`)
    })
}


solve('cat', 42, function () { console.log('Hello world!'); }, 'dog', 44);