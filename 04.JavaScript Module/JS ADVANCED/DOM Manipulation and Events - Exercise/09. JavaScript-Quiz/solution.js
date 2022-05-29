function solve() {
  let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let sections = document.getElementsByTagName('section');
  let quiz = Array.from(document.querySelectorAll('.quiz-answer'));
  let results = document.querySelector("#results");
  let lastResult = document.querySelector('#results li h1');
  let correctPoints = 0;
  let idx = 0;
  for (const element of quiz) {
        element.addEventListener('click',(e) => {
        if (correctAnswers.includes(e.target.textContent)) {
          correctPoints++;
        }
        sections[idx].style.display = 'none';
        sections[idx].classList.add('hidden');
        idx++;
        if (idx == 3) {
          results.style.display = 'block';
          if (correctPoints == 3) {
            lastResult.textContent = 'You are recognized as top JavaScript fan!';
          } else {
            lastResult.textContent = `You have ${correctPoints} right answers`;
          }
        } else {
          sections[idx].style.display = 'block';
        }
    });
  }
}