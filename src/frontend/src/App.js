import React from "react";
import './App.css';
import {Pages} from "./modules/components/pages/pages";
import {Header} from "./modules/components/permanent/header/header";
import {NavBar} from "./modules/components/permanent/nav-bar/nav-bar";
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

            userData: false,
            userAccessToken: false,
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
        if (authStatus) {
            this.setState(() => ({
                isAuth: authStatus,
                useAuthIsAuth: false,
            }));
        }
    }

    handleAccessTokenChange(accessToken) {
        this.setState(() => ({
            userAccessToken: accessToken,
            userData: jwtParser(accessToken),
        }));

    }

    handleUserDataChange(userData) {
        this.setState(() => ({
            userData: userData
        }));
    }


    render() {
        return (
            <div className={'App'}>

                <AuthRoutes userData={this.handleUserDataChange}/>
                <Auth
                    useAuthSignIn={this.state.useAuthSignIn}
                    useAuthSignOut={this.state.useAuthSignOut}
                    useAuthIsAuth={this.state.useAuthIsAuth}
                    useAuthRefresh={this.state.useAuthRefresh}
                    accessToken={this.handleAccessTokenChange}
                    authStatus={this.handleAuthStatusChange}
                />

                <Header
                    onSignInClick={this.handleSignInClick}
                    onSignOutClick={this.handleSignOutClick}
                    isAuth={this.state.isAuth}
                />
                <NavBar userData={this.state.userData}/>
                <Pages userData={this.state.userData}/>
            </div>
        );
    }
}
