(function solve() {
    String.prototype.ensureStart = function (str) {
        let part = this.search(str);
        return part !== 0 ? 'hello' + ' ' + this : this.toString();
    };
    String.prototype.ensureEnd = function(str) {
        let part = this.search(str);
        return this.length - str.length == part - 1 ?  this + ' ' + 'hello' : this.toString();
    };
    String.prototype.isEmpty = function(n) {
        return this.length === 0 ? true : false;
    };
    String.prototype.truncate = function(n) {
        if (this.length < n) {
            return this.toString();
        } else if(this.length > n && n >= 4) {
            let lastSpace = this.toString().substring(0, n - 2).lastIndexOf(" ");
            if (lastSpace != -1) {
                return `${this.toString().substring(0, lastSpace)}...`;
            } else {
                return `${this.toString().substring(0, n - 3)}...`;
                }
        } else if (n < 4) {
            let result = '';
            return result.padStart(n, '.');
        }
    };
    String.format = function (str, ...params) {
        for (let i = 0; i < params.length; i++) {
            str = str.replace(`{${i}}`, params[i]);
        }
        return str;
    }

//     let str = 'my string';
// str = str.ensureStart('my');
// str = str.ensureStart('hello ');
// str = str.truncate(16); 
// str = str.truncate(14); 
// str = str.truncate(8);
// str = str.truncate(4);
// str = str.truncate(2);
// str = String.format('The {0} {1} fox',
//   'quick', 'brown');
// str = String.format('jumps {0} {1}',
//   'dog');
})()


