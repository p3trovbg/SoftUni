function attachEvents() {
    let controller = document.getElementById('controls');
    let authorInput = controller.children[1];
    let contentInput = controller.children[4];
    document.getElementById('submit').addEventListener('click', submit);
    document.getElementById('refresh').addEventListener('click', refresh);
    const url = `http://localhost:3030/jsonstore/messenger`;
    let messages = document.querySelector('#messages');
    async function submit(e) {
       let author = authorInput.value.trim();
        let content = contentInput.value.trim();
        
        if(!author || !content) {
            alert('You should fill all fields!');
            return;
        }
        let result = {author, content};
        authorInput.value = '';
        contentInput.value = '';

        try{
            const response = await fetch(url, {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(result)
            })

            if(!response.ok) {
                const error = await response.json();
                throw new Error(error.message);
            }

            await response.json();
        }
        catch(error) {
            alert(error.message);
        }
        
    
    }
    
    async function refresh() {

        try{    
            const response = await fetch(url);          
            if(response.status !== 200) {
                const error = await response.json();
                throw new Error(error.message);
            }

            const data = await response.json();
            messages.innerHTML = '';
            for (const objKey in data) {
               let obj = data[objKey];
                let author = obj.author;
                let message = obj.content;
                messages.textContent += `${author}: ${message}\n`;
            }

        }   
        catch(error){
            alert(error.message);
        }
    }
}


attachEvents();