import {Navigate} from "react-router-dom";
import {UserManager, WebStorageStateStore} from "oidc-client";

export const SilentSignIn = () => {
    debugger;
    new UserManager({
        userStore: new WebStorageStateStore({store: localStorage})
    }).signinSilentCallback().then();
    return (
        <>
            <Navigate to={'../'} replace={true}/>
            Redirect...
        </>
    )
}
