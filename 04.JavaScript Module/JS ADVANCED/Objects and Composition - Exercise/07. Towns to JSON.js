function townsToJSON(array) {
    const towns = [];
    array.shift(0, 1);
    for (const line of array) {
        let newLine = line.replace(/\|/g, '');
        let[Town, Latitude, Longitude] = newLine.split('  ');
        Town = Town.trimStart();
        Longitude = Longitude.trimEnd();
        Latitude = Number(Latitude).toFixed(2);
        Longitude = Number(Longitude).toFixed(2);

        Latitude = Number(Latitude)
        Longitude = Number(Longitude)
        towns.push({Town, Latitude, Longitude});
    }
    console.log(JSON.stringify(towns));
}

townsToJSON(['| Town | Latitude | Longitude |',
'| Veliko Turnovo | 43.0757 | 25.6172 |',
'| Monatevideo | 34.50 | 56.11 |']
);