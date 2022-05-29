//This way is very stupid. Don't try! Just it was interesting to me how to do like old way. :D 
function toStringExtension() {
    function Person(name, email) {
        this.name = name;
        this.email = email;
    }

    Person.prototype.toString = function () {
            return `${this.constructor.name} (name: ${this.name}, email: ${this.email})`;  
    }

    function Teacher(name, email, subject) {
        Person.call(this, name, email);
        this.subject = subject;
    }
    Teacher.prototype = Object.create(Person.prototype);
    Teacher.prototype.constructor = Teacher
    Teacher.prototype.toString = function(){
        let result = Person.prototype.toString.call(this);
        result = result.substring(0, result.toString().length - 1) + `, subject: ${this.subject})`;
        return result;
      }
      
    function Student(name, email, course) {
        Person.call(this, name, email);
        this.course = course;
    }
    Student.prototype = Object.create(Person.prototype);
    Student.prototype.constructor = Student;
    Student.prototype.toString = function(){
        let result = Person.prototype.toString.call(this);
        result = result.substring(0, result.toString().length - 1) + `, course: ${this.course})`;
        return result;
      }
    return {
        Person,
        Teacher,
        Student
    }
}


let objs = toStringExtension();
const Teacher = objs['Teacher'];
let teacher = new Teacher('Gosho', 'gosho@abv.bg', 'English');
console.log(teacher.toString());
