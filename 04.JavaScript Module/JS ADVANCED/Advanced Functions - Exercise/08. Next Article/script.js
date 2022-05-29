function getArticleGenerator(articles) {
    let output = document.getElementById('content');
    return () =>{
         if(articles.length > 0) {
            let element = articles.shift();
            let article = document.createElement('article');
            article.textContent = element;
           output.appendChild(article);  
         } 
    }
}
