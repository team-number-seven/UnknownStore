import './header.css';
import {Link} from "react-router-dom";
import {useAuth} from "../../hook/useAuth";

export const Header = () => {
    const {isAuthenticated, signIn, signOut} = useAuth();
    return (
        <header className={"header"}>
            <span id={"logo"}><Link className={"fake-link"} to={"/"}>UnkStr</Link></span>
            {!isAuthenticated ?
                <span><button className={"link"} onClick={signIn}>Sign In</button></span>
                : <span><button className={"link"} onClick={signOut}>Sign Out</button></span>
            }
        </header>
    )
}
