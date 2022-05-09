import {CONFIG} from "../../config/config";
import {Route, Routes} from "react-router-dom";
import {Auth} from "../server/auth/auth";
import {SignInCallback} from "../server/auth/sign-in-callback/sign-in-callback";
import {SignOutCallback} from "../server/auth/sign-out-callback/sign-out-callback";
import {SilentSignIn} from "../server/auth/silent-sign-in/silent-sign-in";

export const AuthRoutes = () => {
    return (
        <Routes>
            <Route path={'*'} element={<Auth/>}/>
            <Route path={CONFIG["auth-routes"]["sign-in-callback"]} element={<SignInCallback/>}/>
            <Route path={CONFIG["auth-routes"]["sign-out-callback"]} element={<SignOutCallback/>}/>
            <Route path={CONFIG["auth-routes"]["silent-sign-in"]} element={<SilentSignIn/>}/>
        </Routes>
    )
}
