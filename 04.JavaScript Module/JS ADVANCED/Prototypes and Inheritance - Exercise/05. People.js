function solve() {
    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this._tasks = [];
        }

        get task() {
            let currTask = this._tasks.shift();
            this._tasks.push(currTask);
            return currTask;
        }

        work() {
            let currentTask = this.task;
            console.log(`${this.name} ${currentTask}`); 
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this._tasks = ['is working on a simple task.'];
        }
        collectSalary() {
            super.collectSalary();
        }
    }
    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this._tasks = ['is working on a complicated task.', 'is taking time off work.', 'is supervising junior workers.'];
        }
        collectSalary() {
            super.collectSalary();
        }
    }
    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.dividend = 0;
            this._tasks = ['scheduled a meeting.', 'is preparing a quarterly report.'];
        }
        collectSalary() {
            console.log(`${this.name} received ${this.salary + this.dividend} this month.`);
        }
    }
    return {Employee, Junior, Senior, Manager};
}

const classes = solve (); 

const manager = new classes.Manager('Tom', 55); 
 
manager.salary = 15000; 
manager.collectSalary();  
manager.dividend = 2500; 
manager.collectSalary();  



