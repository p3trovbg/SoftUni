function getDay(month, year) {
    let date = new Date(year, month, null);
    const dayOfMonth = date.getDate();
    console.log(dayOfMonth);
}

getDay(1, 2012);