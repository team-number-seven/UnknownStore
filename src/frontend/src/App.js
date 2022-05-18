import React from "react";
import './App.css';
import {Header} from "./modules/components/permanent/header/header";
import {AuthRoutes} from "./routes/auth-routes";
import {Auth} from "./server/auth/auth";
import {jwtParser} from "./modules/utilites/jwt-parser";

export class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isAuth: false,
            useAuthSignIn: false,
            useAuthSignOut: false,
            useAuthIsAuth: true,
            useAuthRefresh: false,
            userData: {},
            userAccessToken: '',
        }

        this.handleSignInClick = this.handleSignInClick.bind(this);
        this.handleSignOutClick = this.handleSignOutClick.bind(this);
        this.handleAuthStatusChange = this.handleAuthStatusChange.bind(this);
        this.handleAccessTokenChange = this.handleAccessTokenChange.bind(this);
        this.handleUserDataChange = this.handleUserDataChange.bind(this);
    }
    

    handleSignInClick() {
        if (!this.state.useAuthSignIn) {
            this.setState(() => ({useAuthSignIn: true}));
        }
    }

    handleSignOutClick() {
        if (!this.state.useAuthSignOut) {
            this.setState(() => ({useAuthSignOut: true}));
        }
    }

    handleAuthStatusChange(authStatus) {
        this.setState(() => ({
            isAuth: authStatus,
            useAuthIsAuth: false,
        }));
    }

    handleAccessTokenChange(accessToken) {
        this.setState(() => ({
            userAccessToken: accessToken,
            userData: jwtParser(accessToken),
        }));

    }

    handleUserDataChange(userData) {
        debugger;
        this.setState(() => ({
            userData: userData
        }));
    }


    render() {
        return (
            <div className={'App'}>
                {this.state.useAuthIsAuth &&
                    <>
                        <AuthRoutes userData={this.handleUserDataChange}/>
                        <Auth
                            useAuthSignIn={this.state.useAuthSignIn}
                            useAuthSignOut={this.state.useAuthSignOut}
                            useAuthIsAuth={this.state.useAuthIsAuth}
                            useAuthRefresh={this.state.useAuthRefresh}
                            accessToken={this.handleAccessTokenChange}
                            authStatus={this.handleAuthStatusChange}
                        />
                    </>
                }
                <Header
                    onSignInClick={this.handleSignInClick}
                    onSignOutClick={this.handleSignOutClick}
                    isAuth={this.state.isAuth}
                />

            </div>
        );
    }
}
