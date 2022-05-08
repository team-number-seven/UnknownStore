import {UserManager} from "oidc-client";
import {AuthConfig} from "../../../../../../config/auth-config";

const mgr = new UserManager(AuthConfig);

const signIn = () => {
    mgr.signinRedirect().then();
}

const signOut = () => {
    mgr.signoutRedirect().then();
}

const refresh = () => {
    mgr.signinRedirect()
        .then((user)=>{
            console.log("Token refreshed", user);
        })
        .catch((error)=>{
            console.log("Something went wrong");
        })
}


const isAuth = () => {
    mgr.getUser().then((user) => {
        if (user) {
            console.log("User logged in", user.access_token);
            return true;
        } else {
            console.log("User not logged in");
            return false;
        }
    })
}


export const Auth = () => {

    return (
        <div id={'auth-component'}>
            <button onClick={signIn}>Sign In</button>
            <button onClick={isAuth}>Auth?</button>
            <button onClick={signOut}>Sign Out</button>
            <button onClick={refresh}>Refresh</button>
        </div>
    )
}
