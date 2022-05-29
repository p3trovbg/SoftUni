function subtract() {
    let firstNumber = document.getElementById('firstNumber').value;
    let secondNumber = document.getElementById('secondNumber').value;
    let result = document.getElementById('result');
    firstNumber = Number(firstNumber);
    secondNumber = Number(secondNumber);
    result.textContent = firstNumber - secondNumber;
}