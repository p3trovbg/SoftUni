function uppercase(input = String) {
    let words = input.match(/[\w]+/g).join(", ").toUpperCase();
    console.log(words);
}

uppercase('Hi, how are you?');
uppercase('Functions in JS can be nested, i.e. hold other functions');