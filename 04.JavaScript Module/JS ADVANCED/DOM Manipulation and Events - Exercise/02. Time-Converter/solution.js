function attachEventsListeners() {

    let divElements = document.querySelectorAll('div');
    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');
    for (const div of divElements) {
        let button = div.children[2];
        let id = div.children[1].id;
            button.addEventListener('click', (e) => {
                let valueInput = Number(div.children[1].value);
                switch(id) {
                    case "days":
                        days.value = valueInput;
                        hours.value = valueInput * 24;
                        minutes.value = hours.value * 60;
                        seconds.value = minutes.value * 60;
                        break;
                    case "hours":
                        hours.value = valueInput;
                        minutes.value = hours.value * 60;
                        seconds.value = minutes.value * 60;
                        days.value = valueInput / 24;
                        break;
                    case "minutes":
                        minutes.value = valueInput;
                        seconds.value = minutes.value * 60;
                        hours.value = valueInput / 60;
                        days.value = hours.value / 24;
                        break;
                    case "seconds": 
                    seconds.value = valueInput;
                    minutes.value = seconds.value / 60;
                    hours.value = minutes.value / 60;
                    days.value = hours.value / 24;
                        break;
                }     
        });
    }
}