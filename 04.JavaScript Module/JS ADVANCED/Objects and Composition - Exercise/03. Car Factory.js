function assemblesCar(order) {
    const storage = {
        'Small engine': { power: 90, volume: 1800 },
        'Normal engine': { power: 120, volume: 2400 },
        'Monster engine': { power: 200, volume: 3500 },
        Hatchback: { type: 'hatchback', color: '' },
        Coupe: { type: 'coupe', color: '' },
    };
    
    let car = {};  
    car['model'] = order.model;
    let flag = false;
    for (const key in storage) {
        if (storage[key].power >= order.power && !flag) {
            car['engine'] = storage[key];
            flag = true;
        }

        if(storage[key].type === order.carriage) {
            storage[key].color = order.color;
            car['carriage'] = storage[key];
        }
    }
    let size = order.wheelsize % 2 == 0 ? order.wheelsize - 1 :order.wheelsize;
    let wheels = [size, size, size, size];
    car['wheels'] = wheels;
    return car;
}

assemblesCar({ model: 'Opel Vectra',
power: 110,
color: 'grey',
carriage: 'coupe',
wheelsize: 17 }
);
