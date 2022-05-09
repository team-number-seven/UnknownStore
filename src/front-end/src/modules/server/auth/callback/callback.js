import {Navigate} from "react-router-dom";
import {UserManager, WebStorageStateStore} from "oidc-client";

export const Callback = () => {
    new UserManager({
        response_mode: "query",
        loadUserInfo: true,
        userStore: new WebStorageStateStore({store: localStorage})
    }).signinRedirectCallback()
        .then((user) => {
            console.log(user.profile);
        }).catch((e) => console.log("NE log"));

    return (
        <>
            <Navigate to={'../'} replace={true}/>
            Redirect...
        </>
    )
}
