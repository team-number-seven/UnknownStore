import './header.css';
import {Link} from "react-router-dom";
import {useAuth} from "../../hook/useAuth";

export const Header = () => {
    const {isAuthenticated, signIn, signOut} = useAuth();
    return (
        <header className={"color-change-4x-blue"}>
            <span><Link className={"fake-link"} to={"/"}>UnknownStore</Link></span>
            {!isAuthenticated ?
                <span><button className={"link"} onClick={signIn}>Sign In</button></span>
                : <span><button className={"link"} onClick={signOut}>Sign Out</button></span>
            }
        </header>
    )
}
