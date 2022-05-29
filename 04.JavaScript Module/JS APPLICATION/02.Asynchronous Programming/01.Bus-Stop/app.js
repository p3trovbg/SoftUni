function getInfo() {
    let busID = document.getElementById('stopId');
    let stopName = document.getElementById('stopName');
    let buses = document.getElementById('buses');

    const url = `http://localhost:3030/jsonstore/bus/businfo/${busID.value}`;

    fetch(url)
    .then(response => {
        if(response.status != 200) {
            throw new Error('Error');
        }
        return response.json();
    })
    .then(data => {
        buses.replaceChildren();
        stopName.textContent = data.name;

        let allBuses = data.buses;
       for (const key in allBuses) {
        let liElement = document.createElement('li');
        liElement.textContent = `Bus ${key} arrives in ${allBuses[key]} minutes`;
        buses.appendChild(liElement);        
       }
    })
    .catch(error => {
        buses.replaceChildren();
        stopName.textContent = error.message; 
    });

}