
export async function showSelection(sectionName) {
    document.querySelectorAll('section').forEach(x => {
        if(x.id == sectionName) {
            x.style.display = 'block';
        } else {
            x.style.display = 'none';
        }
    })
    
}