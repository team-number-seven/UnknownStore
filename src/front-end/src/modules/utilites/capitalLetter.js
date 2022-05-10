export const capitalLetter = (string) => {
    if (string !== undefined) {
        string = string.toLowerCase();
        const firstLetter = string[0].toUpperCase();
        const anotherString = string.slice(1);
        return firstLetter + anotherString;
    }
    return null;
}
