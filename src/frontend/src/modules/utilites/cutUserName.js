export const cutUserName = (userName, length) => {
    if (userName.length <= length) {
        return userName;
    }
    if (userName.length > length) {
        return userName.slice(0, length) + '...';
    }
}
