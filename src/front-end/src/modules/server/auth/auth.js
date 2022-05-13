import {UserManager} from "oidc-client";
import {useState} from "react";
import {Navigate} from "react-router-dom"
import {CONFIG} from "../../../configs/config";
import {AuthConfig} from "../../../configs/auth-config";


export const Auth = ({useAuthIsAuth, useAuthSignOut, useAuthIsRefresh, useAuthSignIn, authStatus, accessToken}) => {

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
                console.log(error);
            })
    }


    const isAuth = () => {
        mgr.getUser().then((user) => {
            if (user) {
                accessToken(user.access_token);
                authStatus(true);
            } else {
                authStatus(false);
            }
        })
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
    if (useAuthIsRefresh) {
        refresh();
    }


    return (
        <></>
    )
}
