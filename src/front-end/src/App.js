import {useState} from "react";
import {Link} from "react-router-dom";
import {ROUTES_CONFIG} from "./configs/routes-config";
import {Pages} from "./modules/common/components/pages/pages";
import {Header} from "./modules/common/components/permanent/header/header";
import {ModelCreate} from "./modules/common/components/temporary/model-create/model-create";
import {AuthRoutes} from "./modules/routes/auth-routes";
import {Auth} from "./modules/server/auth/auth";
import {jwtParser} from "./modules/utilites/jwt-parser";

export const App = () => {

    const [isAuth, setIsAuth] = useState(undefined);
    const [userAccessToken, setUserAccessToken] = useState(false);
    const [userData, setUserData] = useState(false);

    const [useAuthSignIn, setUseAuthSignIn] = useState(false);
    const [useAuthSignOut, setUseAuthSignOut] = useState(false);
    const [useAuthIsAuth, setUseAuthIsAuth] = useState(true);
    const [useAuthRefresh, setUseAuthRefresh] = useState(false);

    const onSignInClickHandler = () => {
        if (!useAuthSignIn) {
            setUseAuthSignIn(true);
        }
    }

    const onSignOutClickHandler = () => {
        if (!useAuthSignOut) {
            setUseAuthSignOut(true);
        }
    }

    const authStatusHandler = (authStatus) => {
        if (typeof isAuth === "undefined") {
            setIsAuth(authStatus);
            setUseAuthIsAuth(false);
        }
    }


    const accessTokenHandler = (accessToken) => {
        if (!userAccessToken) {
            setUserAccessToken(accessToken);
        }
        if (!userData) {
            setUserData(jwtParser(accessToken));
        }
    }
    const userDataHandler = (data) => {
        if (!userData) {
            setUserData(data);
        }
    }


    return (
        <>
            <AuthRoutes userData={userDataHandler}/>
            <Auth
                useAuthSignIn={useAuthSignIn}
                useAuthSignOut={useAuthSignOut}
                useAuthIsAuth={useAuthIsAuth}
                useAuthIsRefresh={useAuthRefresh}
                authStatus={authStatusHandler}
                accessToken={accessTokenHandler}
            />
            <Header onSignInClick={onSignInClickHandler} onSignOutClick={onSignOutClickHandler} isAuth={isAuth}/>
            <Pages isAuth={isAuth} userAccessToken={userAccessToken} userData={userData}/>
            <Link to={ROUTES_CONFIG.private.manager["create-model"]}>Create model</Link>
        </>
    )
}
