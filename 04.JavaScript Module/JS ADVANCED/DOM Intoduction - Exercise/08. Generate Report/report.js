function generateReport() {
    let inputs = Array.from(document.querySelectorAll('input[type=checkbox]'));
    let columns = Array.from(document.querySelectorAll("tbody tr"));
    let output = document.querySelector("#output");
    let targetColumns = [];

    for (let i = 0; i < columns.length; i++) {
        let result = {}
        for (let j = 0; j < inputs.length; j++) {
            if(inputs[j].checked) {
                let name = inputs[j].name;
                let data = columns[i].textContent
                .split("\n")
                .map(x => x.trim())
                .filter(x => x !== "")[j];
                result[name] = data;
            }
        }

        targetColumns.push(result);
    }
    
    output.value = JSON.stringify(targetColumns);
}