import {html, render} from '../lit-html/lit-html.js';

let tBody = document.querySelector('tbody');

start();
async function start() {
   const table = await getTable();
   let students = Object.values(table);
   render(students.map(student => studentTamplate(student)), tBody);
   document.querySelector('#searchBtn').addEventListener('click', onClick);
}

function onClick() {
      let search = document.querySelector('#searchField').value;
      tBody.querySelectorAll('tr').forEach(tr => {
         tr.classList.remove('select');
            tr.querySelectorAll('td').forEach(td => {
               if(td.textContent.includes(search)) {
                  tr.classList.add('select');
                  return;
               }
            })
      });


}

async function getTable() {
   const response = await fetch(`http://localhost:3030/jsonstore/advanced/table`);
   let data = await response.json();
   return data;
}


function studentTamplate(student) {
   return html`
      <tr>
         <td>${student.firstName + ' ' + student.lastName}</td>
         <td>${student.email}</td>
         <td>${student.course}</td>
   </tr>`
}