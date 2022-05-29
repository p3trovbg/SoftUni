function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let input = document.getElementById('inputs').children[1].value;
      let array = JSON.parse(input);    
      const arr = [];
      for (const restaurant of array) {
         let info = restaurant.split(/\W+\s/);
         let name = info[0];
         let workersArray = info.splice(1);
         let workers = [];
         let bestSalary = 0;
         let averageSum = 0;
         for (let i = 0; i < workersArray.length; i++) {
            let workerInfo = workersArray[i].split(' ');
            let workerName = workerInfo[0];
            let salary = Number(workerInfo[1]);

            averageSum += salary;
            workers.push({workerName, salary});
            bestSalary = bestSalary < salary ? bestSalary = salary : bestSalary;
         }

         averageSum /= workers.length;
         if(arr.some(x => x.name === name)) {
            arr.filter(x => x.name === name)
            .map(function(obj) {
               obj.workers = workers;
               obj.averageSum = averageSum;
               obj.bestSalary = bestSalary;
            });
         } else {
            arr.push({name, workers, averageSum, bestSalary});
         }    
      }
      let bestRestaurant = {};
      arr.forEach(x=>{
         if (x.averageSum > 0) {
          bestRestaurant = x;  
         }}); 

      let bestRestResult = document.getElementById('bestRestaurant').children[2];
      bestRestResult.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSum.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

      let bestWorkers = document.getElementById('workers').children[2];
      bestRestaurant.workers.sort(function(a, b){return b.salary - a.salary});

      const bestRestaurantWorkers = bestRestResult.workers;
      Array.from(bestRestaurantWorkers).forEach(function (worker) {
         bestWorkers.textContent += `Name: ${worker.workerName} With Salary: ${worker.salary} `;
     });
     bestWorkers.textContent().trim();
   }
}