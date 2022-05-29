function encodeAndDecodeMessages() {
    let mainElement = document.getElementById('main');
    //Encode
    let encodeElement = mainElement.children[0];
    let textEncode = encodeElement.children[1]; 
    let buttonEncode = encodeElement.children[2];
    //Decode
    let decodeElement = mainElement.children[1];
    let textDecode = decodeElement.children[1]; 
    let buttonDecode = decodeElement.children[2];

    buttonEncode.addEventListener('click', (e) => {
        let newDecodeText = [];
        for (const currentChar of Array.from(textEncode.value)) {
            let increaseChar = String.fromCharCode(currentChar.charCodeAt(0) + 1);
            newDecodeText.push(increaseChar);
        }
        textEncode.value = "";
        textEncode.placeholder = 'Write your message here...';
        textDecode.value = newDecodeText.join('');
    });

    buttonDecode.addEventListener('click', (e) => {
        let newDecodeText = [];
        for (const currentChar of Array.from(textDecode.value)) {
            let increaseChar = String.fromCharCode(currentChar.charCodeAt(0) - 1);
            newDecodeText.push(increaseChar);
        }
        textDecode.value = newDecodeText.join('');
    });
}