class Stringer {

    constructor(innerString , innerLength ) {
       this.innerString = innerString;
       this.innerLength = innerLength;
       this.initialString = innerString;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        if(this.innerLength - length < 0) {
            this.innerLength = 0;
        } else {
            this.innerLength -= length;
        }
       
    }

    toString() {
        if(this.initialString.length > this.innerLength && this.innerLength != 0) {
            let piece = this.innerString.substring(this.initialString.length - this.innerLength, this.initialString.length);
            let result = this.innerString.replace(piece, '...');
            return result;
        } else if (this.innerLength == 0) {
            return `...`;
        } else {
            return this.initialString;
        }
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
