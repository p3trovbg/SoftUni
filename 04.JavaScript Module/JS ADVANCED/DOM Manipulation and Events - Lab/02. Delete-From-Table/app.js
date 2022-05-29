function deleteByEmail() {
    let searchEmailElement = document.querySelector("label input").value;
    let lists = Array.from(document.querySelectorAll("tr td:nth-child(2)"));
    let output = document.getElementById('result');
    for (const row of lists) {
        if(row.textContent === searchEmailElement) {
            row.parentElement.remove();
            output.textContent = 'Deleted.';
            return;
        }
    }
    output.textContent = 'Not found.';
}