function extract(content) {
 let text = document.getElementById(content);
 let pattern = /\(([^(]+)\)/g;
 let matches = text.textContent.matchAll(pattern);
 const arr = [];
 for (const match of matches) {
     arr.push(match[0]);
 }
return arr.join('; ');
}