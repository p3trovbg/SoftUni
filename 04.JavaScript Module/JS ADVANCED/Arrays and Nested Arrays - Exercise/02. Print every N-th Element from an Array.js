function printArray(array, n) {
    let collection = [];
    for (let i = 0; i < array.length; i+= n) {
        const element = array[i];
        collection.push(element);
    }

    return collection;
}

printArray(['5', 
'20', 
'31', 
'4', 
'20'], 
2
);