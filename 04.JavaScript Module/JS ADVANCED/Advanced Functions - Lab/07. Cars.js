function solution(input) {
    let objects = {};
    let creator = {
            create: (x) => objects[x] = {},
            inherit: (childName, parentName) => {
                creator.create(childName);
                let child = objects[childName];
                child = Object.setPrototypeOf(child, objects[parentName]);
            },
            set: (objName, prop, value) => {
                objects[objName][prop] = value;
            },
            print: (objName) => {
                let result = '';
                let obj = objects[objName];
                for (const car in obj) {           
                    result += `${car}:${obj[car]},`;
                }

                console.log(result.slice(0, -1));
            }
        }
    input.forEach(x => {
        let commands = x.split(' ');
        if(commands.includes('inherit')) {
            creator[commands[2]](commands[1], commands[3]);   
        } else if (commands.includes('create')) {
            creator[commands[0]](commands[1]);    
        } else if(commands.includes('set')) {
            creator[commands[0]](commands[1], commands[2], commands[3]);  
        }  else {
            creator[commands[0]](commands[1]);   
        }         
    });
}

solution(['create c1',
'create c2 inherit c1',
'set c1 color red',
'set c2 model new',
'print c1',
'print c2']
);