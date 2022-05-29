class List {
    constructor() {
        this.list = [];
        this.size = 0;
    };
    validation(idx) {
        if(this.list[idx] == undefined) {
            throw new Error;
        }
    }
    add(element) {
            this.list.unshift(element);
            this.list.sort((a, b) => a - b);
            this.size++;
    }

    remove(index) {
            this.validation(index);
            this.list.splice(index, 1);
            this.list.sort((a, b) => a - b);
            this.size--;
    }

    get(index) {
            this.validation(index);
            return this.list[index];
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.size);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));

