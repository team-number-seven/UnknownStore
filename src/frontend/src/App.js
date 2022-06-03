import {AppRoutes} from "./components/app-routes";
import {AuthProvider} from "./hoc/Auth/AuthProvider";
import "./App.css";


export const App = () => {

    return (
        <>
            <AuthProvider>
               <AppRoutes/>
            </AuthProvider>
        </>
    )
}


/*
import React from "react";
import './App.css';
import {Navigate, Route, Routes} from "react-router-dom";
import {CONFIG} from "./configs/config";
import {PagesRoutes} from "./components/components/pages/pages-routes";
import {Page} from "./components/components/pages/public-pages/page";
import {Header} from "./components/components/permanent/header/header";
import {NavBar} from "./components/components/permanent/nav-bar/nav-bar";
import {AuthRoutes} from "./routes/auth-routes";
import API from "./server/API";
import {Auth} from "./server/auth/auth";
import {jwtParser} from "./components/utilites/jwt-parser";

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

            searchTitleFromNavBar: false,
            filterFromNavBar: false,
        }


        this.handleSignInClick = this.handleSignInClick.bind(this);
        this.handleSignOutClick = this.handleSignOutClick.bind(this);
        this.handleAuthStatusChange = this.handleAuthStatusChange.bind(this);
        this.handleAccessTokenChange = this.handleAccessTokenChange.bind(this);
        this.handleUserDataChange = this.handleUserDataChange.bind(this);
        this.handleSearchFromNavBar = this.handleSearchFromNavBar.bind(this);
    }

    componentDidMount() {
        API.get(CONFIG.GET.model["get-models"], {params: {title: 'te'}})
            .then(result => console.log(result.data));
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

    handleSearchFromNavBar(title) {
        debugger
        this.setState(() => ({searchTitleFromNavBar: title}));
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

                <div className={'app-head'}>
                    <Header
                        onSignInClick={this.handleSignInClick}
                        onSignOutClick={this.handleSignOutClick}
                        isAuth={this.state.isAuth}
                    />
                    <NavBar userData={this.state.userData} onSearch={this.handleSearchFromNavBar}/>
                </div>

                <PagesRoutes userData={this.state.userData}/>
                {this.state.searchTitleFromNavBar &&
                    <Page searchTitle={this.state.searchTitleFromNavBar} filter={this.state.filterFromNavBar}/>
                }


            </div>
        );
    }
}
*/
