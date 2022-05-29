class Textbox {
    constructor(selector, reg) {
        this._value = '';
        this._elements = document.querySelectorAll(selector);
        this._invalidSymbols = reg;
    }
    
    get elements() {
        return this._elements;
    }

    get value() {
        return this._value;
    }
    set value(newValue) {
        Array.from(this.elements).forEach(x => {
            x.value = newValue;
        })
        this._value = newValue;
    }

    isValid() {
        if (this.value.match(this._invalidSymbols)) {
            return false;
        }
        return true;
    }
}

let textbox = new Textbox(".textbox",/[^a-zA-Z0-9]/);
let inputs = document.getElementsByClassName('.textbox');

inputs.addEventListener('click',function(){console.log(textbox.value);});
// •	property value (has getters and setters) 
// •	property _elements containing the set of elements matching the selector
// •	getter elements for the _elements property – return as NodeList
// •	property _invalidSymbols - a regex used for validating the textbox value
// •	method isValid() - if the _invalidSymbols regex can be matched in any of the _elements values return false, otherwise, return true.
