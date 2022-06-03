import {useContext} from "react";
import {Link} from "react-router-dom";
import {ROUTES_CONFIG} from "../../configs/routes-config";
import {useAuth} from "../../hook/useAuth";
import {cutUserName} from "../../components/utilites/cutUserName";
import {userNameFromUserData} from "../../components/utilites/userNameFromUserData";
import './nav-bar.css';

export const NavBar = ({userData, onSearch}) => {

    const {user} = useAuth();

    const handleSearchSubmit = (e) => {
        if (e.code === "Enter") {
            onSearch(e.target.value);
        }
    }

    return (
        <div className={'nav-bar-container'}>
            <div className={'nav-bar'}>
                <div className={'nav-filters'}>
                    <Link className={'link'} to={ROUTES_CONFIG.public.men}>Men</Link>
                    <Link className={'link'} to={ROUTES_CONFIG.public.women}>Women</Link>
                    <Link className={'link'} to={ROUTES_CONFIG.public.kids}>Kids</Link>
                </div>
                <div className={'user-panel'}>
                    <div className={'form-field-container'} style={{height:'100%'}}>
                        <input type={'text'} style={{height: '100%', maxWidth: '7vw', margin: '0'}}
                               className="form-control"
                               onKeyDown={handleSearchSubmit}
                               placeholder={'Search...'}
                        />
                    </div>
                    <span><Link className={'link'} to={ROUTES_CONFIG.public.bag}>Bag</Link></span>

                    <Link className={'link'} to={ROUTES_CONFIG.public.profile}>
                        {user ? cutUserName(userNameFromUserData(user), 8) : 'Guest'}
                    </Link>
                </div>
            </div>

        </div>
    )
}

/*userNameFromUserData(userData)*/
