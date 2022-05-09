import {CONFIG} from "../../config/config";
import {Route, Routes} from "react-router-dom";
import {Auth} from "../server/auth/auth";
import {Callback} from "../server/auth/callback/callback";
import {SilentSignIn} from "../server/auth/silent-sign-in/silent-sign-in";

export const AuthRoutes = () => {
    return (
        <Routes>
            <Route path={CONFIG["auth-routes"].callback} element={<Callback/>}/>
            <Route path={'*'} element={<Auth/>}/>
            <Route path={CONFIG["auth-routes"]["silent-sign-in"]} element={<SilentSignIn/>}/>
        </Routes>
    )
}
