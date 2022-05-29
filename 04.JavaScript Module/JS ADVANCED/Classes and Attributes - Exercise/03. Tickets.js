function solve(array, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    let tickets = [];
    for (const element of array) {
       let[destination, price, status] = element.split('|');
        tickets.push(new Ticket(destination, Number(price), status));
    }
    let sortArray = tickets.sort((a, b) => typeof a[criteria] === 'string'
    ? a[criteria].localeCompare(b[criteria])
    : a[criteria] - b[criteria]);
    return sortArray;
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));
