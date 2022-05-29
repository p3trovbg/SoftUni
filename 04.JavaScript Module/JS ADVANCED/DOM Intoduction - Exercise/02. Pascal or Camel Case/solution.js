function solve() {
  let text = document.getElementById('text').value;
  let convetion = document.getElementById('naming-convention').value;
  let result = document.getElementById('result');
  let textArray = text.split(' ');
  switch(convetion) {
    case 'Camel Case':
      let mapText = textArray.splice(1).map(x => x.charAt(0).toUpperCase() + x.slice(1).toLowerCase());
      mapText.unshift(textArray[0].charAt(0).toLowerCase() + textArray[0].slice(1).toLowerCase());
      result.textContent = mapText.join('');
      break;
      case 'Pascal Case':
        result.textContent = textArray.map(x => x.charAt(0).toUpperCase() + x.slice(1).toLowerCase()).join('');
        break;
        case 'Another Case':
          result.textContent = 'Error!';
          break;
  }
}