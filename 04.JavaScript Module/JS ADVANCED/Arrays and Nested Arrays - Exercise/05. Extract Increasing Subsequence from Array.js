function extractIncreasingSubsequnce(array) {
    let subsequnce = array.reduce(function(previousValue, currentValue){
        let currentDigit = previousValue.length == 0 ? 0 : previousValue[previousValue.length - 1];
        if (currentDigit <= currentValue) {
            previousValue.push(currentValue);
        }
        return previousValue;
      }, []);

    return subsequnce;
}

// extractIncreasingSubsequnce([1, 
//     3, 
//     8, 
//     4, 
//     10, 
//     12, 
//     3, 
//     2, 
//     24]
//     );

    extractIncreasingSubsequnce([20, 
        3, 
        2, 
        15,
        6, 
        1]
        );

        extractIncreasingSubsequnce([1, 
            2, 
            3,
            4]
            );