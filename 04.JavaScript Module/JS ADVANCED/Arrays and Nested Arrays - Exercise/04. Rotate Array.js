function rotateArray(array, time) {
    for (let i = 0; i < time; i++) {
        array.unshift(array.pop());
    }
    
    console.log(array.join(' '));
}

rotateArray(['1', 
'2', 
'3', 
'4'], 
2
);