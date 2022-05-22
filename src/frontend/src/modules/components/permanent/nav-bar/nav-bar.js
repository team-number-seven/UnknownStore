import {Link} from "react-router-dom";
import {ROUTES_CONFIG} from "../../../../configs/routes-config";
import {cutUserName} from "../../../utilites/cutUserName";
import {userNameFromUserData} from "../../../utilites/userNameFromUserData";
import './nav-bar.css';

export const NavBar = ({userData}) => {
    return (
        <div className={'nav-bar-container'}>
            <div className={'nav-bar'}>
                <div className={'nav-filters'}>
                    <Link className={'link'} to={ROUTES_CONFIG.public.men}>Men</Link>
                    <Link className={'link'} to={ROUTES_CONFIG.public.women}>Women</Link>
                    <Link className={'link'} to={ROUTES_CONFIG.public.kids}>Kids</Link>
                </div>
                <div className={'user-panel'}>
                    <span><Link className={'link'} to={ROUTES_CONFIG.public.bag}>Bag</Link></span>

                    <Link className={'link'} to={ROUTES_CONFIG.public.profile}>
                        {userData ? cutUserName(userNameFromUserData(userData), 8) : 'Guest'}
                    </Link>
                </div>
            </div>

        </div>
    )
}

/*userNameFromUserData(userData)*/
