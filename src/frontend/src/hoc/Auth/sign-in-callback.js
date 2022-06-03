import {Navigate} from "react-router-dom";
import {UserManager, WebStorageStateStore} from "oidc-client";
import {useAuth} from "../../hook/useAuth";
import {jwtParser} from "../../components/utilites/jwt-parser";

export const SignInCallback = ({userData}) => {
    const {setUser, setIsAuthenticated} = useAuth();
    new UserManager({
        response_mode: "query",
        loadUserInfo: true,
        userStore: new WebStorageStateStore({store: localStorage})
    }).signinRedirectCallback()
        .then((user) => {
            if(user){
                debugger;
                setUser(jwtParser(user.access_token));
                setIsAuthenticated(true);
            }
        }).catch((e) => e);

    return (
        <>
            <Navigate to={'../'} replace={true}/>
            Redirect...
        </>
    )
}
