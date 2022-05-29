class Hex {
    constructor(value) {
        this.value = Number(value);
    }

    valueOf() {
        return this.value
    }
    
    toString() {
        return `0x${this.value.toString(16).toUpperCase()}`;
    }

    plus(number) {
        return `0x${(this.value + number).toString(16).toUpperCase()}`;
    }

    minus(number) {
        return `0x${(this.value - number).toString(16).toUpperCase()}`;
    }

    parse(string) {
        return this.value = parseInt(string, 16);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');
console.log(FF.parse('AAA'));
