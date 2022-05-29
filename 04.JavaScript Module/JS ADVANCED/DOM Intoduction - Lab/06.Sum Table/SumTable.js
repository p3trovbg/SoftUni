function sumTable() {
    let myElement = document.getElementsByTagName('tr');
    let arr = Array.of(myElement);
    let sum = 0;
    for (const e of arr[0]) {
       if(Number(e.children[1].textContent)) {
           sum += Number(e.children[1].textContent);
       }
    }

    let result = document.getElementById('sum');
    result.textContent = sum; 
}