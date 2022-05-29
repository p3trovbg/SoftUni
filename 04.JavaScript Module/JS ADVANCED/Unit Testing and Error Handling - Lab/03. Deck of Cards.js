function printDeckOfCards(cards) {
    let result = '';
    try {
        result = cards.map(createCard).join(' ');
        
    } catch (error) {
        result = error.message;
    }  

    console.log(result);  
    function createCard (input){
        let validFaces = [2, 3, 4, 5, 6, 7, 8, 9, 10, 'J', 'Q', 'K', 'A', 'S', 'H', 'D', 'C'];
        let validSuits = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663'
        }
        let face = input.slice(0, input.length - 1);
        let suit = input[input.length - 1];
        if(Number(face)){
            face = Number(face);
        }

        if (!validFaces.includes(face) || !validFaces.includes(suit)) {
            throw new Error(`Invalid card: ${input}`);
        }

        let card =  {
            face: face, 
            suit: validSuits[suit],
            toString: function() {
                return `${this.face}${this.suit}`;
            } 
        }
        return card;
    }
  }

  console.log(printDeckOfCards(['AS', '10D', 'KH', '2C']).toString());
  console.log(printDeckOfCards(['5S', '3D', 'QD', '1C']).toString());
  