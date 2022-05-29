function sortArray(array) {
    let sortedArray = array.sort(function(a, b) {
        if (a.length > b.length) return 1;
        if (a.length < b.length) return -1;
        if (a > b) return 1;
        if (a < b) return -1;
    });
    sortedArray.forEach(element => {
        console.log(element);
    });
}

sortArray(['test', 
'Deny', 
'omen', 
'Default']
);


sortArray(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']
);