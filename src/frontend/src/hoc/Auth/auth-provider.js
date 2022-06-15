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
        refreshUser();
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
        if (user && Date.now() >= user?.expires_at * 1000) {
            try {
                mgr.signinRedirect()
                    .then((userAfterRedirect) => {
                        console.log("Token refreshed", userAfterRedirect);
                        mgr.getUser().then((userDataAfterRefresh) => {
                            let tempUser = user;
                            tempUser.access_token = userDataAfterRefresh.access_token;
                            tempUser.expires_at = userDataAfterRefresh.expires_at;
                            setUser(tempUser);
                        })
                    })
                    .catch((error) => {
                        console.log(error);
                    });
            } catch (e) {
                signIn();
            }
        }
    }
    const authenticationCheck = () => {
        mgr.getUser().then((userData) => {
            if ((!user && userData) || (!isAuthenticated && userData)) {
                const userInfo = userData.profile;
                userInfo.access_token = userData.access_token;
                userInfo.expires_at = userData.expires_at;
                setUser(userInfo);
                setIsAuthenticated(true);
                getUserFavorites();



            } else {
                let favorites = JSON.parse(localStorage.getItem("guestFavorites"));
                setUser({
                    name: 'Guest',
                    favorites: favorites ? favorites : [],
                })
            }
        }).catch(error => console.log(error));
    }

    const getUserFavorites = () => {
        debugger;
        if (user) {
            debugger;
            API.get(CONFIG.GET.user["get-favorites"],
                {
                    headers: {"Authorization": `Bearer ${user.access_token}`},
                    params: {userId: user.id}
                })
                .then(result => {
                    let tempUser = user;
                    tempUser.favorites = result.data["modelDtos"].map((favourite => favourite.id));
                    setUser(tempUser);
                });
        }
    }


    const providerValues = {
        user,
        setUser,
        isAuthenticated,
        setIsAuthenticated,
        signIn,
        signOut,
        refreshUser,
        authenticationCheck,
        getUserFavorites
    };

    return (
        <AuthContext.Provider value={providerValues}>
            {children}
        </AuthContext.Provider>
    )
}



