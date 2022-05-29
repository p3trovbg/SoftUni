function solve(input) {
    let collection = [];
    let operations = {
        add: (x) => collection.push(x),
        remove: (x) => collection = collection.filter(e => e !== x),
        print: () => console.log(collection.join(','))
    }

    input.forEach(x => {
        let[command, string] = x.split(' ');  
        operations[command](string);         
    });
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);

