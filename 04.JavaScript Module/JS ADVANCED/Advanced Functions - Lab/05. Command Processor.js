function solution() {
    let result = '';
        return {
            append: (x) => result += x,
            removeStart: (x) => (result = result.substring(x)),
            removeEnd: (x) => (result = result.substring(0, result.length - x)),
            print: () => console.log(result) 
        }
    }

let firstZeroTest = solution();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();


