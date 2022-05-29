function attachEventsListeners() {
    let inputUnitsElements = Array.from(document.getElementById('inputUnits').children);
    let outputUnitsElements = Array.from(document.getElementById('outputUnits').children);
    let buttonElement = document.getElementById('convert');
    let inputDistanceElement = document.getElementById('inputDistance');
    let outputDistance = document.getElementById('outputDistance');

    buttonElement.addEventListener('click', (e) => {
        let selectInput = inputUnitsElements.find(x => x.selected);
        let selectOutput = outputUnitsElements.find(x => x.selected);
        let distance = Number(inputDistanceElement.value);
        let result = 0;

        switch(selectInput.value) {
            case 'km': distance *= 1000; break;
            case 'm': distance = distance; break;
            case 'cm': distance *= 0.01; break;
            case 'mm': distance *= 0.001; break;
            case 'mi': distance *= 1609.34; break;
            case 'yrd': distance *= 0.9144; break;
            case 'ft': distance *= 0.3048; break;
            case 'in': distance *= 0.0254; break;
        }

        switch(selectOutput.value) {
            case 'km': result = distance / 1000; break;
            case 'm': result = distance; break;
            case 'cm': result = distance / 0.01; break;
            case 'mm': result = distance / 0.001; break;
            case 'mi': result = distance / 1609.34; break;
            case 'yrd': result = distance / 0.9144; break;
            case 'ft': result = distance / 0.3048; break;
            case 'in': result = distance / 0.0254; break;
        }
        outputDistance.value = result;
    });
}