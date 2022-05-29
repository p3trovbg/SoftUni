async function getInfo() {

    // read input value
    // request to server
    // parse data
    // display data
    // check error

    const stopNameElement = document.getElementById('stopName');
    const timeTableElement = document.getElementById('buses');
    const stopId = document.getElementById('stopId').value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;

    const res = fetch(url)
        .then((response) => {
            stopNameElement.textContent = 'Loading...';
            timeTableElement.replaceChildren();
            response.json().then(result => {
                stopNameElement.textContent = result.name;
                Object.entries(result.buses).forEach(b => {
                    const liElement = document.createElement('li');
                    liElement.textContent = `Bus ${b[0]} arrives in ${b[1]} minutes`;
                    timeTableElement.appendChild(liElement);
                })
            })
            if (response.status !== 200) {
                throw new Error('Stop Id not found!')
            }

        })
        .catch((error) => {
            stopNameElement.textContent = 'Error';
        })

}