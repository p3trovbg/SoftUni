function addAndRemoveElements(commands) {
    let elements = [];
    let digit = 0;
    for (const command of commands) {
        digit++;
        if (command === 'add') {
         elements.push(digit);
        } else if (command === 'remove') {
                elements.pop();
            }
    }
    elements == 0 ? console.log('Empty') : 
    elements.forEach(element => {
        console.log(element);
    });
}

// addAndRemoveElements(['add', 
// 'add', 
// 'add', 
// 'add']
// );

addAndRemoveElements(['add', 
'add', 
'remove', 
'add', 
'add']
);

addAndRemoveElements(['remove', 
'remove', 
'remove']
);