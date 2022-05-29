let baseUrl = "http://localhost:3030/jsonstore/forecaster/locations";
let locationElement = document.getElementById('location');

let forecastElement = document.getElementById('forecast');
let currentConditions = document.getElementById('current');
let upcomingConditions = document.getElementById('upcoming');

const typeTime = {
    'Sunny': '&#x2600',
    'Partly sunny': '&#x26C5',
    'Overcast': '&#x2601',
    'Rain': '&#x2614',
    'Degrees': '&#176'

}

async function solution() {
    let currentLocation = '';
    try{
        clearChildren();
        //First request
        const response = await fetch(baseUrl);
        isValidStatus(response.status);
        const data = await response.json();
        currentLocation = data.find(x => x.name === locationElement.value);
        isValidParameter(currentLocation);
        //Second request
        const secondResponse = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${currentLocation.code}`);
        isValidStatus(secondResponse.status);
        const dataSecondResponse = await secondResponse.json();
    
        let divCondition = document.createElement('div');
        divCondition.className = 'forecasts';

        let spanConditionSymbol = document.createElement('span');
        spanConditionSymbol.classList = 'condition symbol';
        let condition = dataSecondResponse.forecast.condition;
        spanConditionSymbol.innerHTML = typeTime[condition];

        let spanCondition = document.createElement('span');
        spanCondition.className = 'condition';

        let spanCity = document.createElement('span');
        spanCity.className = 'forecast-data';
        spanCity.textContent = dataSecondResponse.name;

        let spanDegrees = document.createElement('span');
        spanDegrees.className = 'forecast-data';
        let degreesSymbol = typeTime.Degrees;
        spanDegrees.innerHTML = `${dataSecondResponse.forecast.low}${degreesSymbol}/${dataSecondResponse.forecast.high}${degreesSymbol}`;

        let spanTypeTime = document.createElement('span');
        spanTypeTime.className = 'forecast-data';
        spanTypeTime.textContent = dataSecondResponse.forecast.condition;

        spanCondition.appendChild(spanCity);
        spanCondition.appendChild(spanDegrees);
        spanCondition.appendChild(spanTypeTime);

        divCondition.appendChild(spanConditionSymbol);
        divCondition.appendChild(spanCondition);

        currentConditions.appendChild(divCondition);

        //Third request
        const thirdResponse = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${currentLocation.code}`);
        isValidStatus(thirdResponse);
        const dataThirdResponse = await thirdResponse.json();
        let divUpComing = document.createElement('div', 'forecast-info');
        for (const current of dataThirdResponse.forecast) {
            let spanUpComing = document.createElement('span', 'upcoming');

            let symbolElement = document.createElement('span');
            symbolElement.className = 'symbol';
            symbolElement.innerHTML = typeTime[current.condition];

            let degreesElement = document.createElement('span');
            degreesElement.className = 'forecast-info';
            let degreesSymbol = typeTime.Degrees;
            degreesElement.innerHTML = `${current.low}${degreesSymbol}/${current.high}${degreesSymbol}`;

            let type = document.createElement('span');
            type.className = 'forecast-info';
            type.textContent = current.condition;

            spanUpComing.appendChild(symbolElement);
            spanUpComing.appendChild(degreesElement);
            spanUpComing.appendChild(type);
            divUpComing.appendChild(spanUpComing);
        }
        
        upcomingConditions.appendChild(divUpComing);

        forecastElement.style.display = 'block';
    }
    catch(error){
        clearChildren();
        let liErrorElement = document.createElement('li');
        liErrorElement.className = 'label';
        liErrorElement.textContent = error.message;
        forecastElement.style.display = 'block';
        currentConditions.appendChild(liErrorElement);
    }  
    
};

function clearChildren() {
    let currCondition = currentConditions.children[0];
    let upComing = upcomingConditions.children[0];

    while(currCondition && currCondition.nextSibling)
    {
        currCondition.parentNode.removeChild(currCondition.nextSibling);
    }

    while(upComing && upComing.nextSibling)
    {
        upComing.parentNode.removeChild(upComing.nextSibling);
    }
}

 function isValidStatus(status) {
    if(status.ok == false) {
        throw new Error('Error');
    }
}

 function isValidParameter(parameter) {
    if(!parameter) {
        throw new Error('Invalid city');
    }
}


function attachEvents() {
    let submitButton = document.getElementById('submit');
    submitButton.addEventListener('click', solution);
}

attachEvents();