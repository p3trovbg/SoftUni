function calculator() {
    let[firstDigit, secondDigit, result] = '';
    return {
        init: (selector1, selector2, resultSelector) => {
            firstDigit = document.querySelector(selector1);
            secondDigit = document.querySelector(selector2);
            result = document.querySelector(resultSelector);
        },
        add: () =>  result.value = Number(firstDigit.value) + Number(secondDigit.value),
        subtract: () => result.value = Number(firstDigit.value) - Number(secondDigit.value) 
    }
}

const calculate = calculator (); 
calculate.init('#num1', '#num2', '#result'); 
calculate.add(); 




