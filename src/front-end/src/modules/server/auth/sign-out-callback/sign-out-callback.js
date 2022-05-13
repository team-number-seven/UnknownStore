import {UserManager, WebStorageStateStore} from "oidc-client";
import {Navigate} from "react-router-dom";

export const SignOutCallback = () => {
    new UserManager({userStore:new WebStorageStateStore({store:localStorage})}).signoutRedirectCallback().then(() => {
        localStorage.clear();
    });
    return (
        <Navigate to={'../'} replace={true}/>
    )
}
