function townPopulation(info) {
    let towns = {};
    for (const town of info) {
        let [townName, townPopulation] = town.split(' <-> ');
        let population = Number(townPopulation);
       if (!towns[townName]) {
        towns[townName] = 0;
       } 
        towns[townName] += population;
    }

    for (const key in towns) {
       console.log(`${key} : ${towns[key]}`);
    }
}

townPopulation(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
);