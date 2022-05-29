class SummerCamp {
    constructor (organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            child: 150,
            student: 300,
            collegian: 500
        }
        this.listOfParticipants = []; 
    }

    registerParticipant (name, condition, money) {
        if(!this.priceForTheCamp[condition]) {
            throw new Error("Unsuccessful registration at the camp.");
        }

        if(this.listOfParticipants.find(x => x.name === name)) {
            return `The ${name} is already registered at the camp.`;
        }

        let sum = this.priceForTheCamp[condition];
        if(sum > money) {
            return `The money is not enough to pay the stay at the camp.`;
        } else {
            this.listOfParticipants.push({name, condition, power: 100, wins: 0});
            return `The ${name} was successfully registered.`;
        }
    }

    unregisterParticipant (name){
        if(!this.listOfParticipants.find(x => x.name === name)) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        this.listOfParticipants = this.listOfParticipants.filter(x => x.name !== name);
        return `The ${name} removed successfully.`;
    }

    timeToPlay (typeOfGame, participant1, participant2) {
        let firstPlayer = this.listOfParticipants.find(x => x.name === participant1);
        let secondPlayer = this.listOfParticipants.find(x => x.name === participant2);
        if(typeOfGame == "WaterBalloonFights") {
           if(!firstPlayer || !secondPlayer) {
               throw new Error(`Invalid entered name/s.`);
           } else if (firstPlayer.condition !== secondPlayer.condition) {
               throw new Error(`Choose players with equal condition.`);
           }

           let result = '';
           if (firstPlayer.power > secondPlayer.power) {
                firstPlayer.wins += 1;
                result = `The ${firstPlayer.name} is winner in the game ${typeOfGame}.`; 
           } else if(secondPlayer.power > firstPlayer.power) {
               secondPlayer.wins +=1;
            result = `The ${secondPlayer.name} is winner in the game ${typeOfGame}.`; 
           } else {
               result = `There is no winner.`;
           }
           return result;
        } else {
            if(!firstPlayer) {
                throw new Error(`Invalid entered name/s.`);
            }
            firstPlayer.power += 20;
            return `The ${firstPlayer.name} successfully completed the game ${typeOfGame}.`;
        }
    }

    toString() {
        let result = '';
        result += `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}\n`;
        for (const participant of this.listOfParticipants.sort((a, b) => b.wins - a.wins)) {
            result += `${participant.name} - ${participant.condition} - ${participant.power} - ${participant.wins}\n`;
        }
        return result.trimEnd();
    }
} 

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));


