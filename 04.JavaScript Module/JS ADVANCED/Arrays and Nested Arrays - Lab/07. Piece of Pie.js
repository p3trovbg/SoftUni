function pie(flowers, firstFlower, lastFlower) {
    let firstIdx = flowers.indexOf(firstFlower);
    let secondIdx = flowers.indexOf(lastFlower);
    let array = flowers.slice(firstIdx, secondIdx + 1);

    return array;
}

pie(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
);