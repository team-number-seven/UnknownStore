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
                    <span><Link className={'link'} to={ROUTES_CONFIG.public.men}>Men</Link></span>
                    <span><Link className={'link'} to={ROUTES_CONFIG.public.women}>Women</Link></span>
                    <span><Link className={'link'} to={ROUTES_CONFIG.public.kids}>Kids</Link></span>
                </div>
                <div className={'user-panel'}>
                    <span><Link className={'link'} to={ROUTES_CONFIG.public.bag}>Bag</Link></span>
                    <span>
                    Hello,
                    <Link className={'link'} to={ROUTES_CONFIG.public.profile}>
                        {userData ? cutUserName( '12345678',8) : 'Guest'}
                    </Link>!
                </span>
                </div>
            </div>

        </div>
    )
}

/*userNameFromUserData(userData)*/
