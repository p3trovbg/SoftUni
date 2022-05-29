function solve() {
    let state = 'depot';
    let departButton = document.getElementById('depart');
    let arriveButton = document.getElementById('arrive');
    let infoElement = document.getElementById('info');

    let url = `http://localhost:3030/jsonstore/bus/schedule/${state}`;
    function depart() {
        arriveButton.disabled = false;
        departButton.disabled = true;
        fetch(url)
        .then(response => {
            if(response.status !== 200) {
                throw new Error('Error');
            }
            return response.json();
        })
        .then(data => {
            infoElement.textContent = `Next stop ${data.name}`;
        })
        .catch(error => {
            arriveButton.disabled = false;
            departButton.disabled = false;
            infoElement.textContent = error.message;
        })
    }

    function arrive() {
        arriveButton.disabled = true;
        departButton.disabled = false;

        fetch(url)
        .then(response => {
            if(response.status !== 200) {
                throw new Error('Error');
            }
            return response.json();
        })
        .then(data => {
            infoElement.textContent = `Arriving at ${data.name}`;
            url = `http://localhost:3030/jsonstore/bus/schedule/${data.next}`;
        })
        .catch(error => {
            arriveButton.disabled = false;
            departButton.disabled = false;
            infoElement.textContent = error.message;
        })

    }

    return {
        depart,
        arrive
    };
}

let result = solve();