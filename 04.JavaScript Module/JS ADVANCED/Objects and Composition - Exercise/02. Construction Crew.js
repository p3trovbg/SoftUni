function crew(worker) {
 if(worker.dizziness === true) {
     worker.levelOfHydrated += 0.1 * worker.weight * worker.experience; 
     worker.dizziness = false;
 }
 return worker;
}


crew({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }
  );

  crew({ weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false }
  );