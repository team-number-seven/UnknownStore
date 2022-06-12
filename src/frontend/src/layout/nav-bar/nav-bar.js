import {Link} from "react-router-dom";
import {ROUTES_CONFIG} from "../../configs/routes-config";
import {useAuth} from "../../hook/useAuth";
import {cutString} from "../../components/utilites/cutString";
import {userNameFromUserData} from "../../components/utilites/userNameFromUserData";
import './nav-bar.css';
import {Search} from "./search";

export const NavBar = ({onSearch}) => {

    const {user} = useAuth();

    return (
        <div className={'nav-bar-container'}>
            <div className={'nav-bar'}>
                <div className={'nav-filters'}>
                    <Link className={'link'} to={ROUTES_CONFIG.public.men}>Men</Link>
                    <Link className={'link'} to={ROUTES_CONFIG.public.women}>Women</Link>
                    <Link className={'link'} to={ROUTES_CONFIG.public.kids}>Kids</Link>
                </div>
                <div className={'user-panel'}>
                    <Search/>
                    <span><Link className={'link'} to={ROUTES_CONFIG.public.bag}>Bag</Link></span>

                    <Link className={'link'} to={ROUTES_CONFIG.public.profile}>
                        {user?.id ? cutString(userNameFromUserData(user), 8) : user?.name}
                    </Link>
                </div>
            </div>

        </div>
    )
}

/*userNameFromUserData(userData)*/
