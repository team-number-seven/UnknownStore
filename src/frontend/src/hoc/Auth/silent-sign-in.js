import {useEffect} from "react";
import {Navigate} from "react-router-dom";
import {UserManager, WebStorageStateStore} from "oidc-client";
import {useAuth} from "../../hook/useAuth";

export const SilentSignIn = () => {
    const {refreshUser} = useAuth();
    useEffect(()=>{
        refreshUser();
    },[]);
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
