export const userNameFromUserData = (userData) => {
    if (userData) {
        return userData.name.split('|')[1];
    }
}
