import {UserManager, WebStorageStateStore} from "oidc-client";
import {Navigate} from "react-router-dom";

export const SignOutCallback = () => {
    const userFavorites = JSON.parse(localStorage.getItem("guestFavorites"));
    new UserManager({userStore: new WebStorageStateStore({store: localStorage})}).signoutRedirectCallback().then(() => {
        localStorage.clear();
        localStorage.setItem("guestFavorites", JSON.stringify(userFavorites));
    });
    return (
        <Navigate to={'../'} replace={true}/>
    )
}
