class Point {
    constructor(p1, p2) {
        this.p1 = p1;
        this.p2 = p2;
    }

    static distance(firstPoint, secondPoint ) {
        let a = firstPoint.p1 - secondPoint.p1;
        let b = firstPoint.p2 - secondPoint.p2;
        return Math.sqrt(a ** 2 + b ** 2);
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
