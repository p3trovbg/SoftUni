function solve(carsInput) {
    let cars = {};
    for (const car of carsInput) {
        [carMark, carModel, producedCar] = car.split(' | ');
        producedCar = Number(producedCar);
        let currentCar = {
            carModel,
            producedCar
        }
        if(!cars[carMark]){
            cars[carMark] = [];
            cars[carMark].push(currentCar);
        } else if (cars[carMark].some(x => x.carModel === carModel)) {
            cars[carMark].filter(x => x.carModel == carModel).map(x => x.producedCar += producedCar);
        } else {
            cars[carMark].push(currentCar);
        }
    }

    for (const carMark in cars) {
        console.log(carMark);
        cars[carMark].forEach(x => {
            console.log(`###${x.carModel} -> ${x.producedCar}`);
        })
    }
}

solve(['Audi | Q7 | 1000',
'Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
);