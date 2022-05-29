function solve() {
  let text = document.getElementById('input').value;
  let array = text.split('. ');
  let paragraphs = Math.ceil(array.length / 3); 
  let div = document.createElement('div');
  div.setAttribute("id", "output");
  document.body.appendChild(div);
  for (let i = 0; i < paragraphs; i++) {
    let senteces = [];
    for (let i = 0; i < 3; i++) {
      if (array.length == 0) {
        break;
      }
      senteces.push(array.shift());
    }    
    let newText = senteces.join('. ');
    let newParagraph = document.createElement("p"); 
	  let textNode = document.createTextNode(newText); 
    newParagraph.appendChild(textNode);
    document.getElementById("output").appendChild(newParagraph);
  }
}