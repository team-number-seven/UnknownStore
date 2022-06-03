import './header.css';
import {useAuth} from "../../hook/useAuth";

export const Header = () => {
    const {isAuthenticated, signIn, signOut} = useAuth();
    return (
        <header>
            <span>UnknownStore</span>
            {!isAuthenticated ?
                <span><button className={'link'} onClick={signIn}>Sign In</button></span>
                : <span><button className={'link'} onClick={signOut}>Sign Out</button></span>
            }
        </header>
    )
}
