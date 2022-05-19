import {Link} from "react-router-dom";
import {ROUTES_CONFIG} from "../../../../configs/routes-config";
import {userNameFromUserData} from "../../../utilites/userNameFromUserData";

export const NavBar = ({userData}) => {
    return (
        <div className={'nav-bar-container'}>
            <div className={'nav-bar'}>
                <Link to={ROUTES_CONFIG.public.men}>Men</Link>
                <Link to={ROUTES_CONFIG.public.women}>Women</Link>
                <Link to={ROUTES_CONFIG.public.kids}>Kids</Link>
                <Link to={ROUTES_CONFIG.public.bag}>Bag</Link>
                <span>
                    Hello,
                    <Link to={ROUTES_CONFIG.public.profile}>
                        {userData ? userNameFromUserData(userData) : 'Guest'}
                    </Link>!
                </span>
            </div>

        </div>
    )
}
