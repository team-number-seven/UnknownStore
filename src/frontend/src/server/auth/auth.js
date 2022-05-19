import {UserManager} from "oidc-client";
import {AuthConfig} from "../../configs/auth-config";


export const Auth = ({
                         useAuthIsAuth,
                         useAuthSignOut,
                         useAuthRefresh,
                         useAuthSignIn,
                         authStatus,
                         accessToken,
                     }) => {

    const mgr = new UserManager(AuthConfig);

    const signIn = () => {
        mgr.signinRedirect().then().catch(error => console.log(error));
    }

    const signOut = () => {
        mgr.signoutRedirect().then().catch(error => console.log(error));
    }

    const refresh = () => {
        mgr.signinRedirect()
            .then((user) => {
                console.log("Token refreshed", user);
            })
            .catch((error) => {
                console.log(error);
            });
    }


    const isAuth = () => {
        mgr.getUser().then((user) => {
            if (user) {
                accessToken(user.access_token);
                authStatus(true);
            } else {
                authStatus(false);
            }
        }).catch(error => console.log(error));
    }

    if (useAuthIsAuth) {
        isAuth();
    }
    if (useAuthSignIn) {
        signIn();
    }
    if (useAuthSignOut) {
        signOut();
    }
    if (useAuthRefresh) {
        refresh();
    }


    return (
        <></>
    )
}
