import {Outlet} from "react-router-dom";
import {Header} from "./header/header";
import {NavBar} from "./nav-bar/nav-bar";

export const Layout = () => {
    return (
        <div className={"main-background color-change-8x-white"}>
            <div className={'app-head'}>
                <Header/>
                <NavBar/>
            </div>
            <div className={'page-container color-change-8x-white'}>
                <Outlet/>
            </div>
        </div>
    )
}
