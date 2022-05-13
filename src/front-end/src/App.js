import {useState} from "react";
import {Header} from "./modules/common/components/permanent/header/header";
import {ModelCreate} from "./modules/common/components/temporary/model-create/model-create";
import {AuthRoutes} from "./modules/routes/auth-routes";
import {Auth} from "./modules/server/auth/auth";

export const App = () => {

    const [isAuth, setIsAuth] = useState(false);
    const [userAccessToken, setUserAccessToken] = useState(undefined);
    const [userData, setUserData] = useState(undefined);

    const [useAuthSignIn, setUseAuthSignIn] = useState(false);
    const [useAuthSignOut, setUseAuthSignOut] = useState(false);
    const [useAuthIsAuth, setUseAuthIsAuth] = useState(true);
    const [useAuthRefresh, setUseAuthRefresh] = useState(false);

    const onSignInClickHandler = () => {
        setUseAuthSignIn(true);
    }

    const onSignOutClickHandler = () => {
        setUseAuthSignOut(true);
    }

    const authStatusHandler = (authStatus) => {
        setIsAuth(authStatus);
    }

    const accessTokenHandler = (accessToken) => {
        setUserAccessToken(accessToken);
    }

    const userDataHandler = (userData) => {
        setUserData(userData);
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
            <ModelCreate/>

        </>
    )
}
