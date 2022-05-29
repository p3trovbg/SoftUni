class Company {
    constructor() {
        this.departments =  {};
    }
    addEmployee(name, salary, position, department) {
        if(!name || !salary || !position || !department) {
            throw new Error("Invalid input!");
        }
        salary = Number(salary);
        if (salary < 0) {
            throw new Error("Invalid input!")
        }
        let employee = {
            name,
            salary,
            position
        }

        if (!this.departments[department]) {
            this.departments[department] = [];
        }
        this.departments[department].push(employee);

        return (`New employee is hired. Name: ${name}. Position: ${position}`);   
    }

    bestDepartment() {
        let result = '';
        let averageSum = 0;
        let bestDepartment = {};
        for (const [key, value] of Object.entries(this.departments)) {
            let sum = 0;
             for (const employee of value) {
                sum += employee.salary;                 
             }
             sum /= value.length;
             if (averageSum < sum) {
                 averageSum = sum;
                 bestDepartment[key] = value;
            }
        }
        result += `Best Department is: ${Object.keys(bestDepartment)}\n`
        result += `Average salary: ${averageSum.toFixed(2)}\n`
        for (const key in bestDepartment) {
           let sortArray = bestDepartment[key].sort(function (a, b) {
            if (a.salary > b.salary) return -1;
            if (a.salary < b.salary) return 1;
            if (a.name > b.name) return 1;
            if (a.name < b.name) return -1;
        
        });
           sortArray.forEach(employee => {
               result += `${employee.name} ${employee.salary} ${employee.position}\n`;
           });
        }

        return result.trimEnd();
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());

