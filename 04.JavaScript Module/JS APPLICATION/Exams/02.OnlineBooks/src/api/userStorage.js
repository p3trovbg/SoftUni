const tokenName = 'userToken'; // That name can be modfied!

export function setToken(userInfo) {
    sessionStorage.setItem(tokenName, JSON.stringify(userInfo));
}

export function getToken() {
    return sessionStorage.getItem(tokenName);
}

export function removeToken() {
    sessionStorage.removeItem(tokenName);
}

export function getUserId() {
    let token = getToken();
    if(token) {
        token = JSON.parse(token);
        return token._id;
    }
    return null;
}