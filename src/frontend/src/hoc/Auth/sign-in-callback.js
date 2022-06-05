import {Navigate} from "react-router-dom";
import {UserManager, WebStorageStateStore} from "oidc-client";
import {CONFIG} from "../../configs/config";
import {useAuth} from "../../hook/useAuth";
import API from "../../server/API";

export const SignInCallback = ({userData}) => {
    const {setUser, setIsAuthenticated} = useAuth();
    new UserManager({
        response_mode: "query",
        loadUserInfo: true,
        userStore: new WebStorageStateStore({store: localStorage})
    }).signinRedirectCallback()
        .then((user) => {
            if(user){
                const userData = user.profile;
                userData.access_token = user.access_token;
                userData.favorites = [];

                if (!userData.favorites.length) {
                    API.get(CONFIG.GET.user["get-favorites"],
                        {
                            headers: {"Authorization": `Bearer ${userData.access_token}`},
                            params: {userId: userData.id}
                        })
                        .then(result => {
                            userData.favorites = result.data.modelDtos.map((favourite => favourite.id));
                        })
                }
                setUser(userData);
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
