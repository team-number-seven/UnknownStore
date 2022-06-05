import {UserManager} from "oidc-client";
import {createContext, useEffect, useState} from "react";
import {AuthConfig} from "../../configs/auth-config";
import {CONFIG} from "../../configs/config";
import API from "../../server/API";

export const AuthContext = createContext(null);
export const AuthProvider = ({children}) => {
    const [user, setUser] = useState(null);
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    useEffect(() => {
        authenticationCheck();
    }, []);

    const mgr = new UserManager(AuthConfig);
    const signIn = () => {
        mgr.signinRedirect().then().catch(error => console.log(error));
    }
    const signOut = () => {
        mgr.signoutRedirect().then().catch(error => console.log(error));
    }
    const refreshUser = () => {
        mgr.signinRedirect()
            .then((user) => {
                console.log("Token refreshed", user);
            })
            .catch((error) => {
                console.log(error);
            });
    }
    const authenticationCheck = () => {
        mgr.getUser().then((userData) => {
            if ((!user && userData) || (!isAuthenticated && userData)) {

                const userInfo = userData.profile;
                userInfo.access_token = userData.access_token
                userInfo.favorites = [];
                if (!userInfo.favorites.length) {
                    API.get(CONFIG.GET.user["get-favorites"],
                        {
                            headers: {"Authorization": `Bearer ${userInfo.access_token}`},
                            params: {userId: userInfo.id}
                        })
                        .then(result => {
                            userInfo.favorites = result.data.modelDtos.map((favourite => favourite.id));
                        })
                }
                setUser(userInfo);
                setIsAuthenticated(true);
            } else {
                let favorites = JSON.parse(localStorage.getItem("guestFavorites"));
                setUser({
                    name: 'Guest',
                    favorites: favorites ? favorites : [],
                })
            }
        }).catch(error => console.log(error));
    }

    const providerValues = {
        user,
        setUser,
        isAuthenticated,
        setIsAuthenticated,
        signIn,
        signOut,
        refreshUser,
        authenticationCheck
    };

    return (
        <AuthContext.Provider value={providerValues}>
            {children}
        </AuthContext.Provider>
    )
}


