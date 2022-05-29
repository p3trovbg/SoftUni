(function solve() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };
    Array.prototype.skip = function(n) {
        return this.slice(n);
    };
    Array.prototype.take = function(n) {
        return this.slice(0, n);
    };
    Array.prototype.sum = function() {
        return this.reduce((pV, cV) => pV + cV);
    };
    Array.prototype.average = function() {
        return this.reduce((pV, cV) => pV + cV) / this.length;
    };
})()


