import {CONFIG} from "../../configs/config";
import {Route, Routes} from "react-router-dom";
import {SignInCallback} from "../server/auth/sign-in-callback/sign-in-callback";
import {SignOutCallback} from "../server/auth/sign-out-callback/sign-out-callback";
import {SilentSignIn} from "../server/auth/silent-sign-in/silent-sign-in";

export const AuthRoutes = ({userData}) => {

    const userDataHandler = (data) => {
        userData(data);
    }
    return (
        <Routes>
            <Route path={CONFIG["auth-routes"]["sign-in-callback"]}
                   element={<SignInCallback userData={userDataHandler}/>}/>
            <Route path={CONFIG["auth-routes"]["sign-out-callback"]} element={<SignOutCallback/>}/>
            <Route path={CONFIG["auth-routes"]["silent-sign-in"]} element={<SilentSignIn/>}/>
        </Routes>
    )
}
