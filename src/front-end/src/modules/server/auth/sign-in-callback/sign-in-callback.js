import {Navigate} from "react-router-dom";
import {UserManager, WebStorageStateStore} from "oidc-client";

export const SignInCallback = () => {
    new UserManager({
        response_mode: "query",
        loadUserInfo: true,
        userStore: new WebStorageStateStore({store: localStorage})
    }).signinRedirectCallback()
        .then((user) => {
            console.log(user.profile);
            // eslint-disable-next-line no-restricted-globals
            location.reload();
        }).catch((e) => console.log("NE log"));

    return (
        <>
            <Navigate to={'../'} replace={true}/>
            Redirect...
        </>
    )
}