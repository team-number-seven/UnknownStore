import {UserManager} from "oidc-client";
import {createContext, useEffect, useState} from "react";
import {AuthConfig} from "../../configs/auth-config";

export const AuthContext = createContext(null);
export const AuthProvider = ({children}) => {
    const [user, setUser] = useState(null);
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    useEffect(() => authenticationCheck(), []);

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
                debugger;
                setUser(userData.profile);
                setIsAuthenticated(true);
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



