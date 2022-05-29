function solve() {
    class Figure{
        constructor(value = 'cm') {
            this.value = value;
        }
    
        get area () {
        }
    
        changeUnits(newValue) {
            this.value = newValue;
        } 
    
        toString() {
            return `Figures units: ${this.value}`;
        }
    
        convertValue(radius) {
            switch(this.value) {
                case 'mm': return radius *= 10;
                case 'm': return radius /= 10;
            }
            return radius;
        }
    }
    
    class Circle extends Figure {
        constructor(radius) {
            super();
            this._radius = Number(radius);
        }
    
        get area() {
            this.radius = this.convertValue(this._radius);
            return (Math.PI) * this.radius * this.radius;    
        }
    
        toString() {
            return `${super.toString()} Area: ${this.area} - radius: ${this.radius}`;
        }
    }
    
    class Rectangle extends Figure {
        constructor(width, height, value) {
            super();
            this._width = width;
            this._height = height;
            super.value = value;
        }
    
        get area() {
            this.width = this.convertValue(this._width);
            this.height = this.convertValue(this._height);
            return this.height * this.width;    
        }
    
        toString() {
            return `${super.toString()} Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
        }
    }
    return { Figure, Circle, Rectangle };
}
let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200 
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50
