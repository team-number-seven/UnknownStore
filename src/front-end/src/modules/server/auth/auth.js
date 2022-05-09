
import {UserManager} from "oidc-client";
import {useState} from "react";
import {Navigate} from "react-router-dom"
import {CONFIG} from "../../../config/config";
import {AuthConfig} from "../../../config/auth-config";




export const Auth = () => {

    const [userIsAuth, setUserIsAuth] = useState(false);


    const mgr = new UserManager(AuthConfig);

    const signIn = () => {
        mgr.signinRedirect().then();
    }

    const signOut = () => {
        mgr.signoutRedirect().then();
    }

    const refresh = () => {
        mgr.signinRedirect()
            .then((user) => {
                console.log("Token refreshed", user);
            })
            .catch((error) => {
                console.log("Something went wrong");
            })
    }


    const isAuth = () => {
        mgr.getUser().then((user) => {
            if (user) {
                console.log("User logged in", user.access_token);
                setUserIsAuth(true);
            } else {
                console.log("User not logged in");
                setUserIsAuth(false);
            }
        })
    }


    isAuth();
    return (
        <div id={'auth-component'}>
            {userIsAuth?<p>aaaa</p>:<p>no</p>}
            <button onClick={signIn}>Sign In</button>
            <button onClick={isAuth}>Auth?</button>
            <button onClick={signOut}>Sign Out</button>
            <button onClick={refresh}>Refresh</button>
        </div>
    )
}
